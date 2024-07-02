using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Logic.Entities
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

       

        


    }
}
