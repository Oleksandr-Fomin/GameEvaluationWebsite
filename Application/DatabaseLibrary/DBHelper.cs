using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using GameEvaluationProject;
using Logic;
using Logic.Exceptions;
using System.Data;

namespace GameEvaluationProject
{
    public class DBHelper : IDBHelper
    {
        

        private SqlConnection _conn;

        public DBHelper()
        {
            
                _conn = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi507406;User Id=dbi507406;Password=12345;");
                _conn.Open();
            
            
        }


        public void ExportGames(List<Game> games)
        {
           
                foreach (Game game in games)
                {
                  
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Game (title, description, imageURL, releaseDate, genre) OUTPUT INSERTED.game_id VALUES (@title, @description, @imageURL, @releaseDate, @genre)", _conn);
                    cmd.Parameters.AddWithValue("@title", game.getTitle());
                    cmd.Parameters.AddWithValue("@description", game.getDescription());
                    cmd.Parameters.AddWithValue("@imageURL", game.getImage());
                    cmd.Parameters.AddWithValue("@releaseDate", game.getReleaseDate());
                    cmd.Parameters.AddWithValue("@genre", game.getGenres());

                    
                    int gameId = (int)cmd.ExecuteScalar();
                    game.setId(gameId);
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
                    games.Add(new Game(title, description, imageURL, releaseDate, Genre));
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to retrieve games from the database: " + ex.Message);
                throw;
            }

            return games;
        }

        public User GetUser(string username)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.User WHERE Username=@username", _conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string id = reader.GetString(reader.GetOrdinal("Id"));
                    string password = reader.GetString(reader.GetOrdinal("Password"));
                    string email = reader.GetString(reader.GetOrdinal("Email"));
                    reader.Close();
                    return new User(id, username, password, email);
                }
                else
                {
                    reader.Close();
                    return null;
                    throw new CustomException("User with the given username not found.");
                }
                
                
            }
            catch (SqlException ex)
            {
                throw new CustomException("An error occurred while trying to retrieve user from the database.", ex);
            }
        }


        public void SaveUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi507406;User Id=dbi507406;Password=12345;"))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[User] (user_id, Username, Password, Email) VALUES (@user_id, @username, @password, @email)", conn))
                    {
                        cmd.Parameters.AddWithValue("@user_id", user.GetId());
                        cmd.Parameters.AddWithValue("@username", user.GetUsername());
                        cmd.Parameters.AddWithValue("@password", user.GetPassword());
                        cmd.Parameters.AddWithValue("@email", user.GetEmail());
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("User saved successfully.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error saving user: " + ex.Message);
            }
        }

        public User VerifyUser(string username, string password)
        {
            User user = null;

            using (SqlConnection conn = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi507406;User Id=dbi507406;Password=12345;"))
            {
                conn.Open();

                string query = "SELECT user_id, email FROM [User] WHERE username=@Username AND password=@Password";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string userId = reader.GetString(0);
                            string email = reader.GetString(1);

                            user = new User(userId, username, password, email);
                        }
                    }
                }
            }

            return user;
        }

        public Game GetGameById(int gameId)
        {
            Game game = null;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Game WHERE game_id=@game_id", _conn);
                cmd.Parameters.AddWithValue("@game_id", gameId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("game_id"));
                    string title = reader.GetString(reader.GetOrdinal("title"));
                    string description = reader.GetString(reader.GetOrdinal("description"));
                    string imageURL = reader.GetString(reader.GetOrdinal("imageURL"));
                    string releaseDate = reader.GetString(reader.GetOrdinal("releaseDate"));
                    string Genre = reader.GetString(reader.GetOrdinal("genre"));

                    game = new Game(title, description, imageURL, releaseDate, Genre);
                }
                else
                {
                    throw new CustomException($"Game with the given id ({gameId}) not found.");
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                throw new CustomException("An error occurred while retrieving game from the database.", ex);
            }
            catch (Exception ex) {
                throw new Exception();
            }
            return game;    
        }

        public List<Review> GetReviewsByGameId(int gameId)
        {
            List<Review> reviews = new List<Review>();

            try
            {
                using (SqlConnection connection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi507406;User Id=dbi507406;Password=12345;"))
                {
                    connection.Open();
                    string query = @"
            SELECT r.review_id, r.game_id, r.user_id, u.username as author, r.rating, r.comment, r.created_at as reviewDate
            FROM dbo.Review r
            INNER JOIN dbo.[User] u ON r.user_id = u.user_id
            WHERE r.game_id = @game_id";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@game_id", gameId);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int reviewId = reader.GetInt32(reader.GetOrdinal("review_id"));
                            string userId = reader.GetString(reader.GetOrdinal("user_id"));
                            string author = reader.GetString(reader.GetOrdinal("author"));
                            int rating = reader.GetInt32(reader.GetOrdinal("rating"));
                            string comment = reader.GetString(reader.GetOrdinal("comment"));
                            DateTime reviewDate = reader.GetDateTime(reader.GetOrdinal("reviewDate"));

                            reviews.Add(new Review(reviewId, gameId, userId, author, rating, comment, reviewDate));
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to retrieve reviews from the database: " + ex.Message);
                throw;
            }

            return reviews;
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
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to retrieve the next game ID from the database: " + ex.Message);
                throw;
            }

            return nextGameId;
        }

        public void AddReview(int gameId, string userId, int rating, string comment)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi507406;User Id=dbi507406;Password=12345;"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Review (game_id, user_id, rating, comment, created_at) VALUES (@game_id, @user_id, @rating, @comment, @created_at)", connection);
                    {
                        cmd.Parameters.AddWithValue("@game_id", gameId);
                        cmd.Parameters.AddWithValue("@user_id", userId);
                        cmd.Parameters.AddWithValue("@rating", rating);
                        cmd.Parameters.AddWithValue("@comment", comment);
                        cmd.Parameters.AddWithValue("@created_at", DateTime.Now); // Add the current timestamp as the created_at value

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to save the review to the database: " + ex.Message);
                throw;
            }
        }

        public double GetAverageScore(int gameId)
        {
            double averageScore = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi507406;User Id=dbi507406;Password=12345;"))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT AVG(CAST(rating as DECIMAL(5, 2))) as AverageScore FROM dbo.Review WHERE game_id=@game_id", connection))
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
            }
            catch (SqlException ex)
            {
                throw new CustomException("An error occurred while trying to get the average score.", ex);
            }

            return averageScore;
        }
        public User GetUserById(string userId)
        {
            User user = null;

          try
          {
             using (SqlConnection conn = new SqlConnection("Server=mssqlstud.fhict.local;Database=dbi507406;User Id=dbi507406;Password=12345;"))
             {
                conn.Open();

                string query = "SELECT user_id, username, password, email FROM [User] WHERE user_id=@UserId";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string id = reader.GetString(0);
                            string username = reader.GetString(1);
                            string password = reader.GetString(2);
                            string email = reader.GetString(3);

                            user = new User(id, username, password, email);
                        }
                    }
                }
             }

            return user;
          }

          catch (SqlException ex)
          {
             throw new CustomException("An error occurred while retrieving the user.", ex);
          }
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
            catch (SqlException ex)
            {
                throw new CustomException("An error occurred while trying to delete a game from the database.", ex);
            }
        }


    }

}

