using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Logic.Entities
{
    public class Report
    {
        public int ReportId { get; set; }
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public string ReportText { get; set; }

        public Report(int reportId, int reviewId, string userId, string reportText)
        {
            ReportId = reportId;
            ReviewId = reviewId;
            UserId = userId;
            ReportText = reportText;
        }
    }

}
