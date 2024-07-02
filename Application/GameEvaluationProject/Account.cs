using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEvaluationProject
{
    public class Account
    {

        private int id;
        private string username;
        private string password;
        private string email;

        public Account(int id, string username, string password, string email)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public int GetId()
        {
            return this.id;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public string GetEmail()
        {
            return this.email;
        }

        public string GetPassword()
        {
            return this.password;
        }

        public bool Authenticate(string password)
        {
            return this.password.Equals(password);
        }
    }
}
