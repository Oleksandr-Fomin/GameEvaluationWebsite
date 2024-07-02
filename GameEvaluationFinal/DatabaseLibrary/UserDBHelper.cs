using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Logic;
using Logic.Exceptions;
using System.Data;
using Logic.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;


namespace DatabaseLibrary
{
    public class UserDBHelper : IUserDBHelper
    {
        private SqlConnection _conn;
        private List<User> _users;
        public UserDBHelper(IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _conn = new SqlConnection(connectionString);
            _conn.Open();
            _users = new List<User>();

        }
        public User GetUser(string username)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.User WHERE Username=@username", _conn);
                cmd.Parameters.AddWithValue("@username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string id = reader.GetString(reader.GetOrdinal("Id"));
                    string password = reader.GetString(reader.GetOrdinal("Password"));
                    string email = reader.GetString(reader.GetOrdinal("Email"));
                    reader.Close();
                    return new User(id, username, password, email);
                }
                else
                {
                    reader.Close();
                    return null;
                }


            }
            catch (SqlException)
            {
                throw new CustomException(ErrorCode.UserRetrievalError);
            }
        }

        public User VerifyUser(string username, string password)
        {
            User user = null;
            try
            {
                if (_conn.State == ConnectionState.Closed)
                {
                    _conn.Open();
                }

                string query = "SELECT user_id, Email FROM [User] WHERE Username=@username AND Password=@password";

                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string userId = reader.GetString(0);
                            string email = reader.GetString(1);

                            user = new User(userId, username, password, email);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw new CustomException(ErrorCode.UserRetrievalError);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new CustomException(ErrorCode.GeneralError);
            }

            return user;
        }


        public void SaveUser(User user)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[User] (user_id, Username, Password, Email) VALUES (@user_id, @username, @password, @email)", _conn))
                {
                    cmd.Parameters.AddWithValue("@user_id", user.GetId());
                    cmd.Parameters.AddWithValue("@username", user.GetUsername());
                    cmd.Parameters.AddWithValue("@password", user.GetPassword());
                    cmd.Parameters.AddWithValue("@email", user.GetEmail());
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new CustomException(ErrorCode.UserSavingError);
            }
        }

        public User GetUserById(string userId)
        {
            User user = null;

            try
            {
                string query = "SELECT user_id, username, password, email FROM [User] WHERE user_id=@UserId";

                using (SqlCommand command = new SqlCommand(query, _conn))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string id = reader.GetString(0);
                            string username = reader.GetString(1);
                            string password = reader.GetString(2);
                            string email = reader.GetString(3);

                            user = new User(id, username, password, email);
                        }
                    }
                }

                return user;
            }

            catch (SqlException)
            {
                throw new CustomException(ErrorCode.UserRetrievalError);
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            string sql = "SELECT * FROM [User]";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader.GetString(reader.GetOrdinal("user_id"));
                        string username = reader.GetString(reader.GetOrdinal("Username"));
                        string password = reader.GetString(reader.GetOrdinal("Password"));
                        string email = reader.GetString(reader.GetOrdinal("Email"));
                        User user = new User(id, username, password, email);
                        users.Add(user);
                    }
                }
            }

            return users;
        }

        public Account GetAccountByUsername(string username)
        {
            string sql = "SELECT * FROM User WHERE Username = @username";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@username", username);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string id = reader.GetString(reader.GetOrdinal("user_id"));
                        string password = reader.GetString(reader.GetOrdinal("Password"));
                        string email = reader.GetString(reader.GetOrdinal("Email"));
                        bool isAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin"));
                        if (isAdmin)
                        {
                            return new Admin(id, username, password, email);
                        }
                        else
                        {
                            return new User(id, username, password, email);
                        }
                    }
                }
            }

            return null;
        }

        public bool UpdateUsername(string currentUsername, string newUsername)
        {
            string sql = "UPDATE [User] SET Username = @newUsername WHERE Username = @currentUsername";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@currentUsername", currentUsername);
                command.Parameters.AddWithValue("@newUsername", newUsername);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Username updated successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("No rows affected. Update failed.");
                    return false;
                }
            }
        }

        public void AddMessage(string userId, string text)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Message (user_id, Text) VALUES (@userId, @text)", _conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@text", text);
            cmd.ExecuteNonQuery();
        }

        public List<Message> GetUnreadMessages(string userId)
        {
            List<Message> messages = new List<Message>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Message WHERE UserId = @userId AND IsRead = 0", _conn);
            cmd.Parameters.AddWithValue("@userId", userId);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Message message = new Message();
                message.Id = reader.GetInt32(0);
                message.UserId = reader.GetString(1);
                message.Text = reader.GetString(2);
                message.IsRead = reader.GetBoolean(3);
                message.CreatedAt = reader.GetDateTime(4);
                messages.Add(message);
            }

            return messages;
        }

        public async Task MarkMessageAsRead(int messageId)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Message SET IsRead = 1 WHERE Id = @messageId", _conn);
            cmd.Parameters.AddWithValue("@messageId", messageId);
            await cmd.ExecuteNonQueryAsync();
        }


        public List<Message> GetMessagesByUserId(string userId)
        {
            List<Message> messages = new List<Message>();

            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Message WHERE user_id = @userId AND IsRead = 0", _conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int messageId = reader.GetInt32(reader.GetOrdinal("Id"));
                        string messageText = reader.GetString(reader.GetOrdinal("Text"));

                        Message message = new Message
                        {
                            Id = messageId,
                            UserId = userId,
                            Text = messageText
                        };

                        messages.Add(message);
                    }
                }
            }

            return messages;
        }

        public bool UpdateUser(User user)
        {
            bool isUpdated = false;

            string query = "UPDATE [User] SET Username = @Username, Password = @Password, Email = @Email WHERE user_id = @Id";

            using (SqlCommand cmd = new SqlCommand(query, _conn))
            {
                cmd.Parameters.AddWithValue("@Username", user.username);
                cmd.Parameters.AddWithValue("@Password", user.password);
                cmd.Parameters.AddWithValue("@Email", user.email);
                cmd.Parameters.AddWithValue("@Id", user.id);

                int rowsAffected = cmd.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }

            return isUpdated;
        }

    }
}
