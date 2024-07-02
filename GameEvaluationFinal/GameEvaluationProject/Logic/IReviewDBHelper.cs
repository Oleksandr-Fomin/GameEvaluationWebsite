using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic
{
    public interface IReviewDBHelper
    {
        List<Review> GetReviewsByGameId(int gameId);
        void AddReview(int gameId, string userId, int rating, string comment);
        double GetAverageScore(int gameId);
        void AddReport(int reviewId, string userId, string reportText);
        List<Report> GetAllReports();
        void DeleteReportedReview(int reviewId);
        void DeleteReport(int reportId);
        Review GetReviewById(int id);
        public Report GetReportByReportText(string reportText);


    }
}
