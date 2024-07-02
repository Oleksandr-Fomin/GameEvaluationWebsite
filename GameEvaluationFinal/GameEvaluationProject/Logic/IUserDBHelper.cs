using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic
{
    public interface IUserDBHelper
    {
        User GetUser(string username);
        void SaveUser(User user);
        User VerifyUser(string username, string password);
        User GetUserById(string userId);
        List<User> GetAllUsers();
        Account GetAccountByUsername(string username);
        bool UpdateUsername(string currentUsername, string newUsername);
        public void AddMessage(string userId, string text);
        public List<Message> GetMessagesByUserId(string userId);
        Task MarkMessageAsRead(int messageId);
        public bool UpdateUser(User user);
    }
}
