using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEvaluationProject;
using Logic;

namespace AdministrationLibrary
{
    public class ReviewAdministration : IReviewAdministration
    {
        private IDBHelper dbHelper;
        public List<Review> reviews = new List<Review>();

        public ReviewAdministration(IDBHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        public List<Review> GetReviewsByGameId(int gameId)
        {
            return dbHelper.GetReviewsByGameId(gameId);
        }

        public bool AddReview(int gameId, string userId, int rating, string comment)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(comment) || rating < 1 || rating > 5)
            {
                return false;
            }

            try
            {
                dbHelper.AddReview(gameId, userId, rating, comment);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding review: " + ex.Message);
                return false;
            }
        }
        public double GetAverageScore(int gameId)
        {
            return dbHelper.GetAverageScore(gameId);
        }
    }
}
