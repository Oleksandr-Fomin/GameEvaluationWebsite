using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEvaluationProject;

namespace Logic
{
    public interface IReviewAdministration
    {
        List<Review> GetReviewsByGameId(int gameId);
        bool AddReview(int gameId, string userId, int rating, string comment);
        double GetAverageScore(int gameId);
    }
}
