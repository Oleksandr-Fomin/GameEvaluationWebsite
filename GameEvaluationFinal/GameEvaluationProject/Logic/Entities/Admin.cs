using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Logic.Entities
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


        
    }
}
