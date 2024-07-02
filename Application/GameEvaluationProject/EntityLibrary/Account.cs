using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEvaluationProject
{
    public abstract class Account
    {

        protected string id;
        protected string username;
        protected string password;
        protected string email;
        //public string UserType { get; set; }

        public Account(string id, string username, string password, string email/*, string userType*/)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.email = email;
            //this.UserType = userType;
        }

        public abstract bool IsAdmin();


        public string Id
        {
            get { return id; }
        }

        public string Username
        {
            get { return username; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Password
        {
            get { return password; }
        }

        public string GetId()
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
