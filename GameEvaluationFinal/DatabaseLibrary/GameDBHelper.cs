using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Logic;
using Logic.Exceptions;
using System.Data;
using Microsoft.Extensions.Configuration;
using Logic.Entities;


namespace DatabaseLibrary
{
    public class GameDBHelper : IGameDBHelper
    {

        private SqlConnection _conn;

        public GameDBHelper(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _conn = new SqlConnection(connectionString);
            _conn.Open();
        }

        public void ExportGames(List<Game> games)
        {
            foreach (Game game in games)
            {
                try
                {
                    SaveGame(game);
                }
                catch (CustomException e)
                {
                    Console.WriteLine($"An error occurred while saving the game: {e.Code}");
                }
            }
        }
        public void SaveGame(Game game)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Game (title, description, imageURL, releaseDate, genre) OUTPUT INSERTED.game_id VALUES (@title, @description, @imageURL, @releaseDate, @genre)", _conn);
                cmd.Parameters.AddWithValue("@title", game.GetTitle());
                cmd.Parameters.AddWithValue("@description", game.GetDescription());
                cmd.Parameters.AddWithValue("@imageURL", game.GetImage());
                cmd.Parameters.AddWithValue("@releaseDate", game.GetReleaseDate());
                cmd.Parameters.AddWithValue("@genre", game.GetGenres());

                int gameId = (int)cmd.ExecuteScalar();
                game.SetId(gameId);
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameSavingError);
            }
        }

        public List<Game> GetGamesFromDB()
        {
            List<Game> games = new List<Game>();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Game", _conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("game_id"));
                    string title = reader.GetString(reader.GetOrdinal("title"));
                    string description = reader.GetString(reader.GetOrdinal("description"));
                    string imageURL = reader.GetString(reader.GetOrdinal("imageURL"));
                    string releaseDate = reader.GetString(reader.GetOrdinal("releaseDate"));
                    string Genre = reader.GetString(reader.GetOrdinal("genre"));

                    Game game = new Game(title, description, imageURL, releaseDate, Genre);
                    game.SetId(id);
                    games.Add(game);
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameRetrievalError);
            }

            return games;
        }

        public Game GetGameById(int gameId)
        {
            try
            {


                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Game WHERE game_id=@gameId", _conn))
                {
                    cmd.Parameters.AddWithValue("@gameId", gameId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("game_id"));
                            string title = reader.GetString(reader.GetOrdinal("title"));
                            string description = reader.GetString(reader.GetOrdinal("description"));
                            string imageURL = reader.GetString(reader.GetOrdinal("imageURL"));
                            string releaseDate = reader.GetString(reader.GetOrdinal("releaseDate"));
                            string genre = reader.GetString(reader.GetOrdinal("genre"));

                            Game game = new Game(title, description, imageURL, releaseDate, genre);
                            game.SetId(id);
                            return game;
                        }
                        else
                        {
                            throw new Exception($"No game found with ID: {gameId}");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameRetrievalError);
            }
        }
        public int GetNextGameId()
        {
            int nextGameId = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(game_id) as max_game_id FROM dbo.Game", _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("max_game_id")))
                    {
                        nextGameId = reader.GetInt32(reader.GetOrdinal("max_game_id")) + 1;
                    }
                    else
                    {
                        nextGameId = 1;
                    }
                    Console.WriteLine("Next game ID: " + nextGameId);
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameIdRetrievalError);
            }

            return nextGameId;
        }

        public List<Game> GetGamesSortedByAverageScore()
        {
            List<Game> games = new List<Game>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Game", _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("game_id"));
                string title = reader.GetString(reader.GetOrdinal("title"));
                string description = reader.GetString(reader.GetOrdinal("description"));
                string imageURL = reader.GetString(reader.GetOrdinal("imageURL"));
                string releaseDate = reader.GetString(reader.GetOrdinal("releaseDate"));
                string Genre = reader.GetString(reader.GetOrdinal("genre"));
                double averageScore = GetAverageScore(id);

                Game game = new Game(title, description, imageURL, releaseDate, Genre)
                {
                    AverageScore = averageScore
                };

                games.Add(game);
            }
            reader.Close();



            return games;
        }

        public void DeleteGame(int gameId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Game WHERE game_id = @gameId", _conn))
                {
                    cmd.Parameters.AddWithValue("@gameId", gameId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new CustomException(ErrorCode.GameDeletionError);
            }
        }

        public double GetAverageScore(int gameId)
        {
            double averageScore = 0;

            try
            {

                    using (SqlCommand cmd = new SqlCommand("SELECT AVG(CAST(rating as DECIMAL(5, 2))) as AverageScore FROM dbo.Review WHERE game_id=@game_id", _conn))
                    {
                        cmd.Parameters.AddWithValue("@game_id", gameId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal("AverageScore")))
                            {
                                averageScore = (double)reader.GetDecimal(reader.GetOrdinal("AverageScore"));
                            }
                        }
                        reader.Close();
                    }
                
            }
            catch (SqlException)
            {
                throw new CustomException(ErrorCode.ReviewRetrievalError);
            }

            return averageScore;
        }

        public int GetMaxGameId()
        {
            int maxGameId = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MAX(game_id) as max_game_id FROM dbo.Game", _conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (!reader.IsDBNull(reader.GetOrdinal("max_game_id")))
                    {
                        maxGameId = reader.GetInt32(reader.GetOrdinal("max_game_id"));
                    }
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to retrieve the max game ID from the database: " + ex.Message);
                throw;
            }

            return maxGameId;
        }
        public void AddGameToPlatformGameTable(Game game, int numberOfLevels)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.PlatformGame(game_id, number_of_levels) VALUES (@gameId, @numberOfLevels)", _conn);
                cmd.Parameters.AddWithValue("@gameId", game.GameId);
                cmd.Parameters.AddWithValue("@numberOfLevels", numberOfLevels);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameSavingError);
            }
        }

        public void AddGameToSurvivalGameTable(Game game, string environmentType)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.SurvivalGame(game_id, environment_type) VALUES (@gameId, @environmentType)", _conn);
                cmd.Parameters.AddWithValue("@gameId", game.GameId);
                cmd.Parameters.AddWithValue("@environmentType", environmentType);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameSavingError);
            }
        }

        public void AddGameToMOBAGameTable(Game game, int numberOfHeroes)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.MOBAGame(game_id, number_of_heroes) VALUES (@gameId, @numberOfHeroes)", _conn);
                cmd.Parameters.AddWithValue("@gameId", game.GameId);
                cmd.Parameters.AddWithValue("@numberOfHeroes", numberOfHeroes);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameSavingError);
            }
        }
        public void AddGameToActionGameTable(Game game, string combatSystem)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.ActionGame(game_id, combat_system) VALUES (@gameId, @combatSystem)", _conn);
                cmd.Parameters.AddWithValue("@gameId", game.GameId);
                cmd.Parameters.AddWithValue("@combatSystem", combatSystem);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameSavingError);
            }
        }

        public void AddGameToStealthGameTable(Game game, string stealthMechanics)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.StealthGame(game_id, stealth_mechanics) VALUES (@gameId, @stealthMechanics)", _conn);
                cmd.Parameters.AddWithValue("@gameId", game.GameId);
                cmd.Parameters.AddWithValue("@stealthMechanics", stealthMechanics);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameSavingError);
            }
        }

        public void AddGameToBattleRoyaleGameTable(Game game, int playerCapacity)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.BattleRoyaleGame(game_id, player_capacity) VALUES (@gameId, @playerCapacity)", _conn);
                cmd.Parameters.AddWithValue("@gameId", game.GameId);
                cmd.Parameters.AddWithValue("@playerCapacity", playerCapacity);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameSavingError);
            }
        }

        public void AddGameToShooterGameTable(Game game, string weaponTypes)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.ShooterGame(game_id, weapon_types) VALUES (@gameId, @weaponTypes)", _conn);
                cmd.Parameters.AddWithValue("@gameId", game.GameId);
                cmd.Parameters.AddWithValue("@weaponTypes", weaponTypes);
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.GameSavingError);
            }
        }
    }
}
