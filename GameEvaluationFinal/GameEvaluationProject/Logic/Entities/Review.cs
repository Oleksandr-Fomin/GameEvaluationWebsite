using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Logic.Entities
{
    public class Review
    {
        public int reviewId;
        public int gameId;
        public string userId;
        public string author;
        public int rating;
        public string comment;
        public DateTime reviewDate;


        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public DateTime ReviewDate
        {
            get { return reviewDate; }
            set { reviewDate = value; }
        }

        


        public Review(int reviewId, int gameId, string userId, string author, int rating, string comment, DateTime reviewDate)
        {
            this.reviewId = reviewId;
            this.gameId = gameId;
            this.userId = userId;
            this.author = author;
            this.rating = rating;
            this.comment = comment;
            this.reviewDate = reviewDate;
        }

        
    }
}
