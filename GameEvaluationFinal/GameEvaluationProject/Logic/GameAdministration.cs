using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;
using Logic;
using Logic.Filtering_and_Sorting;

namespace AdministrationLibrary
{
    public class GameAdministration : IGameAdministration
    {
        private readonly IGameDBHelper _gameDbHelper;
        


        public GameAdministration(IGameDBHelper gameDbHelper)
        {
            _gameDbHelper = gameDbHelper ?? throw new ArgumentNullException(nameof(gameDbHelper));
          
        }

        public List<Game> GetAllGames()
        {
            return _gameDbHelper.GetGamesFromDB();
        }

        public Game GetGameById(int gameId)
        {
            return _gameDbHelper.GetGameById(gameId);
        }

        public double GetAverageScore(int gameId)
        {
            return _gameDbHelper.GetAverageScore(gameId);
        }

        

        public void DeleteGame(int gameId)
        {
            _gameDbHelper.DeleteGame(gameId);
        }

        public bool AddGame(Game game)
        {
            if (game == null)
            {
                return false;
            }

            try
            {
                int maxGameId = _gameDbHelper.GetMaxGameId();
                game.GameId = maxGameId + 1;
                _gameDbHelper.SaveGame(game);
                Console.WriteLine("Game saved successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving game: " + ex.Message);
                return false;
            }
        }

        public int GetNextGameId()
        {
            return _gameDbHelper.GetNextGameId();
        }

        public void ExportGames(List<Game> games)
        {
            _gameDbHelper.ExportGames(games);
        }

        public List<Game> GetGamesSortedByAverageScore()
        {
            List<Game> games = _gameDbHelper.GetGamesFromDB();
            foreach (var game in games)
            {
                game.AverageScore = GetAverageScore(game.GameId);
            }

            games.Sort((x, y) => y.AverageScore.CompareTo(x.AverageScore));
            return games;
        }

        public List<Game> GetAllGamesSorted(IFiltering<Game> filter = null, IComparer<Game> comparer = null)
        {
            List<Game> games = _gameDbHelper.GetGamesFromDB();

            foreach (var game in games)
            {
                game.AverageScore = GetAverageScore(game.GameId);
            }

            if (filter != null)
            {
                games = games.Where(filter.Match).ToList();
            }

            if (comparer != null)
            {
                games = games.OrderBy(game => game, comparer).ToList();
            }

            return games;
        }

        public void AddGameToPlatformGameTable(Game game, int numberOfLevels)
        {
            _gameDbHelper.AddGameToPlatformGameTable(game, numberOfLevels);
        }

        public void AddGameToSurvivalGameTable(Game game, string environmentType)
        {
            _gameDbHelper.AddGameToSurvivalGameTable(game, environmentType);
        }

        public void AddGameToMOBAGameTable(Game game, int numberOfHeroes)
        {
            _gameDbHelper.AddGameToMOBAGameTable(game, numberOfHeroes);
        }

        public void AddGameToActionGameTable(Game game, string combatSystem)
        {
            _gameDbHelper.AddGameToActionGameTable(game, combatSystem);
        }

        public void AddGameToStealthGameTable(Game game, string stealthMechanics)
        {
            _gameDbHelper.AddGameToStealthGameTable(game, stealthMechanics);
        }

        public void AddGameToBattleRoyaleGameTable(Game game, int playerCapacity)
        {
            _gameDbHelper.AddGameToBattleRoyaleGameTable(game, playerCapacity);
        }

        public void AddGameToShooterGameTable(Game game, string weaponTypes)
        {
            _gameDbHelper.AddGameToShooterGameTable(game, weaponTypes);
        }
    }
}