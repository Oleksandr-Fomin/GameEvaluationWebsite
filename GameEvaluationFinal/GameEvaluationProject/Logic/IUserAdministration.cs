using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic
{
    public interface IUserAdministration
    {
        Account VerifyUser(string username, string password);
        bool SaveUser(User user);
        User GetUserById(string userId);
        List<User> GetAllUsers();
        public Account GetAccountByUsername(string username);
        public bool UpdateUsername(string currentUsername, string newUsername);
        event UserAdministration.UsernameChangedEventHandler UsernameChanged;
        public void AddMessage(string userId, string text);
        public List<Message> GetMessagesByUserId(string userId);
        Task MarkMessageAsRead(int messageId);
        public bool UpdateUser(User user);
    }
}
