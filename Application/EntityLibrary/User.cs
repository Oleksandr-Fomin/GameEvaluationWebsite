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
       
        public List<string> reviews;

        public User(string id, string username, string password, string email)
     : base(id, username, password, email)
        {
            reviews = new List<string>();
        }


        public override bool IsAdmin()
        {
            return false;
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
