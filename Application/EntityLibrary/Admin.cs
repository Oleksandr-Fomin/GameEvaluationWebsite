using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEvaluationProject
{
    public class Admin : Account
    {
        public Admin(string id, string username, string password, string email)
            : base(id, username, password, email)
        {
        }

        public override bool IsAdmin()
        {
            return true;
        }


        public User UpdateUser(User user)
        {
            return user;
        }

        public User DeleteUser(User user)
        {
            return user;
        }

        public List<User> GetUsers(List<User> users)
        {
            return users;
        }
    }
}
