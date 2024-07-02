using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;


namespace GameEvaluationProject
{
    public class DBHelper
    {
        private SqlConnection _conn;

        public DBHelper()
        {
            _conn = new SqlConnection("Data Source=LAPTOP-CHLNEN9D\\SQLEXPRESS01; Initial Catalog=GameEvaluationSiteDB; User ID=Oleksandr; Password=12345;");
            _conn.Open();
        }

        
        public void ExportGames(List<Game> games)
        {
            foreach (Game game in games)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Game (title, description, imageURL, releaseDate) VALUES (@title, @description, @imageURL, @releaseDate)", _conn);
                cmd.Parameters.AddWithValue("@title", game.getTitle());
                cmd.Parameters.AddWithValue("@description", game.getDescription());
                cmd.Parameters.AddWithValue("@imageURL", game.getImage());
                cmd.Parameters.AddWithValue("@releaseDate", game.getReleaseDate());
                int rowsAffected = cmd.ExecuteNonQuery();
            }

        }

        public List<Game> GetGamesFromDB()
        {
            List<Game> games = new List<Game>();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Game", _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string title = reader.GetString(reader.GetOrdinal("title"));
                string description = reader.GetString(reader.GetOrdinal("description"));
                string imageURL = reader.GetString(reader.GetOrdinal("imageURL"));
                string releaseDate = reader.GetString(reader.GetOrdinal("releaseDate"));
                games.Add(new Game(title, description, imageURL, releaseDate));
            }
            reader.Close();
            return games;
        }

        public User GetUser(string username)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Users WHERE Username=@username", _conn);
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("Id"));
                string password = reader.GetString(reader.GetOrdinal("Password"));
                string email = reader.GetString(reader.GetOrdinal("Email"));
                reader.Close();
                return new User(id, username, password, email);
            }
            reader.Close();
            return null;
        }

        public void SaveUser(User user)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Users (Username, Password, Email) VALUES (@username, @password, @email)", _conn);
            cmd.Parameters.AddWithValue("@username", user.GetUsername());
            cmd.Parameters.AddWithValue("@password", user.GetPassword());
            cmd.Parameters.AddWithValue("@email", user.GetEmail());
            int rowsAffected = cmd.ExecuteNonQuery();
        }

        public bool ValidateUser(string username, string password)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection("Data Source=LAPTOP-CHLNEN9D\\SQLEXPRESS01; Initial Catalog=GameEvaluationSiteDB; User ID=Oleksandr; Password=12345;"))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM Users WHERE username=@Username AND password=@Password";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }
    }

}

