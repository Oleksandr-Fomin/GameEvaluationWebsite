using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEvaluationProject;

namespace Logic
{
    public interface IDBHelper
    {
        List<Game> GetGamesFromDB();
        Game GetGameById(int gameId);
        void ExportGames(List<Game> games);
        User GetUser(string username);
        void SaveUser(User user);
        User VerifyUser(string username, string password);
        List<Review> GetReviewsByGameId(int gameId);
        int GetNextGameId();
        void DeleteGame(int gameId);
        void AddReview(int gameId, string userId, int rating, string comment);
        double GetAverageScore(int gameId);
        User GetUserById(string userId);
        List<Game> GetGamesSortedByAverageScore();
    }
}
