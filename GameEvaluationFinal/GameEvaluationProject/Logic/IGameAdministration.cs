using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Filtering_and_Sorting;
using Logic.Entities;

namespace Logic
{
    public interface IGameAdministration
    {
        List<Game> GetAllGames();
        Game GetGameById(int gameId);
        bool AddGame(Game game);
        public double GetAverageScore(int gameId);
        void DeleteGame(int gameId);
        int GetNextGameId();
        void ExportGames(List<Game> games);
        List<Game> GetGamesSortedByAverageScore();
        List<Game> GetAllGamesSorted(IFiltering<Game> filter = null, IComparer<Game> comparer = null);
        void AddGameToPlatformGameTable(Game game, int numberOfLevels);
        void AddGameToSurvivalGameTable(Game game, string environmentType);
        void AddGameToMOBAGameTable(Game game, int numberOfHeroes);
        void AddGameToActionGameTable(Game game, string combatSystem);
        void AddGameToStealthGameTable(Game game, string stealthMechanics);
        void AddGameToBattleRoyaleGameTable(Game game, int playerCapacity);
        void AddGameToShooterGameTable(Game game, string weaponTypes);
    }
}
