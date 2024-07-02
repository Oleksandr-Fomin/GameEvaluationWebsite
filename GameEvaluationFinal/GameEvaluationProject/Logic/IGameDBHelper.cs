using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic
{
    public interface IGameDBHelper
    {
        void ExportGames(List<Game> games);
        void SaveGame(Game game);
        List<Game> GetGamesFromDB();
        Game GetGameById(int gameId);
        int GetNextGameId();
        List<Game> GetGamesSortedByAverageScore();
        void DeleteGame(int gameId);
        int GetMaxGameId();
        double GetAverageScore(int gameId);
        void AddGameToPlatformGameTable(Game game, int numberOfLevels);
        void AddGameToSurvivalGameTable(Game game, string environmentType);
        void AddGameToMOBAGameTable(Game game, int numberOfHeroes);
        void AddGameToActionGameTable(Game game, string combatSystem);
        void AddGameToStealthGameTable(Game game, string stealthMechanics);
        void AddGameToBattleRoyaleGameTable(Game game, int playerCapacity);
        void AddGameToShooterGameTable(Game game, string weaponTypes);
    }
}
