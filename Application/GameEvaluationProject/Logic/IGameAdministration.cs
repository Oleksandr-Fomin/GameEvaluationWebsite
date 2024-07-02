using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEvaluationProject;

namespace Logic
{
    public interface IGameAdministration
    {
        List<Game> GetAllGames();
        Game GetGameById(int gameId);
        void AddGame(Game game);
        void DeleteGame(int gameId);
        int GetNextGameId();
        void ExportGames(List<Game> games);

        List<Game> GetGamesSortedByAverageScore();
    }
}
