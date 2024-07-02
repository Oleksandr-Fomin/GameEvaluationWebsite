using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEvaluationProject;

namespace Logic
{
    public interface IUserAdministration
    {
        Account VerifyUser(string username, string password);
        bool SaveUser(User user);
        User GetUserById(string userId);
    }
}
