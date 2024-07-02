using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEvaluationProject
{
    public class User : Account
    {
       
        private List<string> reviews;

        public User(int id, string username, string password, string email) : base(id, username, password, email)
        {
            
            this.reviews = new List<string>();
        }

        public void GetMyReviews(string game, double rating, string comment)
        {
            this.reviews.Add($"{game}: {rating}/10 - {comment}");
        }

        public void CreateReview(string game, double rating, string comment)
        {
            this.reviews.Add($"{game}: {rating}/10 - {comment}");
        }

        


    }
}
