using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEvaluationProject
{
    public class Review
    {
        public int reviewId;
        public int gameId;
        private string userId;
        private string author;
        public int rating;
        public string comment;
        private DateTime reviewDate;


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

        public string ReviewText
        {
            get { return comment; }
            set { comment = value; }
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

        public int getReviewId()
        {
            return reviewId;
        }

        public int getGameId()
        {
            return gameId;
        }

        public string getUserId()
        {
            return userId;
        }

        public string getAuthor()
        {
            return author;
        }

        public int getRating()
        {
            return rating;
        }

        public string getComment()
        {
            return comment;
        }

        public DateTime getReviewDate()
        {
            return reviewDate;
        }
    }
}
