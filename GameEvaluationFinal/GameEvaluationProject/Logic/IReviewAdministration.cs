using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic
{
    public interface IReviewAdministration
    {
        List<Review> GetReviewsByGameId(int gameId);
        bool AddReview(int gameId, string userId, int rating, string comment);
        double GetAverageScore(int gameId);
        public void ReportReview(int reviewId, string userId, string reportText);
        public List<Report> GetAllReports();
        void DeleteReportedReview(int reviewId);
        public void DeleteReport(int reportId);
        Review GetReviewById(int id);
        public Report GetReportByReportText(string reportText);

    }
}
