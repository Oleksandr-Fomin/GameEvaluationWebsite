using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEvaluationProject;
using Logic;

namespace AdministrationLibrary
{
    public class GameAdministration : IGameAdministration
    {
        private readonly IDBHelper _dbHelper;

        public GameAdministration(IDBHelper dbHelper)
        {
            _dbHelper = dbHelper ?? throw new ArgumentNullException(nameof(dbHelper));
        }

        public List<Game> GetAllGames()
        {
            return _dbHelper.GetGamesFromDB();
        }

        public Game GetGameById(int gameId)
        {
            return _dbHelper.GetGameById(gameId);
        }

        public void DeleteGame(int gameId)
        {
            _dbHelper.DeleteGame(gameId);
        }

        public void AddGame(Game game)
        {
            if (string.IsNullOrEmpty(game.title) ||
                string.IsNullOrEmpty(game.description) ||
                string.IsNullOrEmpty(game.imageURL) ||
                string.IsNullOrEmpty(game.releaseDate) ||
                string.IsNullOrEmpty(game.Genre))
            {
                return;
            }

            var existingGame = _dbHelper.GetGamesFromDB().FirstOrDefault(g => g.title.Equals(game.title, StringComparison.OrdinalIgnoreCase));

            if (existingGame != null)
            {
                return;
            }

            try
            {
                _dbHelper.ExportGames(new List<Game> { game });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding game: " + ex.Message);
            }
        }

        public int GetNextGameId()
        {
            return _dbHelper.GetNextGameId();
        }

        public void ExportGames(List<Game> games)
        {
            _dbHelper.ExportGames(games);
        }

        public List<Game> GetGamesSortedByAverageScore()
        {
            List<Game> games = _dbHelper.GetGamesFromDB();
            foreach (var game in games)
            {
                game.AverageScore = _dbHelper.GetAverageScore(game.gameId);
            }

            games.Sort((x, y) => y.AverageScore.CompareTo(x.AverageScore));
            return games;
        }
    }
}