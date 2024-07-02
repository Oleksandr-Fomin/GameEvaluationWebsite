using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;
using Logic;

namespace AdministrationLibrary
{
    public class ReviewAdministration : IReviewAdministration
    {
        private IReviewDBHelper reviewDbHelper;
        
        public List<Review> reviews = new List<Review>();

        public ReviewAdministration(IReviewDBHelper reviewDbHelper)
        {
            this.reviewDbHelper = reviewDbHelper;
        }

        public List<Review> GetReviewsByGameId(int gameId)
        {
            return reviewDbHelper.GetReviewsByGameId(gameId);
        }

        public bool AddReview(int gameId, string userId, int rating, string comment)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(comment))
            {
                return false;
            }

            try
            {
                reviewDbHelper.AddReview(gameId, userId, rating, comment);
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
            return reviewDbHelper.GetAverageScore(gameId);
        }
        public void ReportReview(int reviewId, string userId, string reportText)
        {
            reviewDbHelper.AddReport(reviewId, userId, reportText);
        }
        public List<Report> GetAllReports()
        {
            return reviewDbHelper.GetAllReports();
        }
        public void DeleteReportedReview(int reviewId)
        {
            reviewDbHelper.DeleteReportedReview(reviewId);
        }
        public void DeleteReport(int reportId)
        {
            reviewDbHelper.DeleteReport(reportId);
        }

        public Review GetReviewById(int id)
        {
            return reviewDbHelper.GetReviewById(id);
        }
        public Report GetReportByReportText(string reportText)
        {

            return reviewDbHelper.GetReportByReportText(reportText);
        }
    }
}
