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
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Logic.Entities;

namespace DatabaseLibrary
{
    public class ReviewDBHelper : IReviewDBHelper
    {
        private SqlConnection _conn;

        public ReviewDBHelper(IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _conn = new SqlConnection(connectionString);
            _conn.Open();


        }
        public List<Review> GetReviewsByGameId(int gameId)
        {
            List<Review> reviews = new List<Review>();

            try
            {
                string query = @"
        SELECT r.review_id, r.game_id, r.user_id, u.username as author, r.rating, r.comment, r.created_at as reviewDate
        FROM dbo.Review r
        INNER JOIN dbo.[User] u ON r.user_id = u.user_id
        WHERE r.game_id = @game_id";

                using (SqlCommand cmd = new SqlCommand(query, _conn))
                {
                    cmd.Parameters.AddWithValue("@game_id", gameId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int reviewId = reader.GetInt32(reader.GetOrdinal("review_id"));
                        string userId = reader.GetString(reader.GetOrdinal("user_id"));
                        string author = reader.GetString(reader.GetOrdinal("author"));
                        int rating = reader.GetInt32(reader.GetOrdinal("rating"));
                        string comment = reader.GetString(reader.GetOrdinal("comment"));
                        DateTime reviewDate = reader.GetDateTime(reader.GetOrdinal("reviewDate"));

                        reviews.Add(new Review(reviewId, gameId, userId, author, rating, comment, reviewDate));
                    }
                    reader.Close();
                }
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.ReviewRetrievalError);
            }

            return reviews;
        }


        public void AddReview(int gameId, string userId, int rating, string comment)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Review (game_id, user_id, rating, comment, created_at) VALUES (@game_id, @user_id, @rating, @comment, @created_at)", _conn);
                {
                    cmd.Parameters.AddWithValue("@game_id", gameId);
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@rating", rating);
                    cmd.Parameters.AddWithValue("@comment", comment);
                    cmd.Parameters.AddWithValue("@created_at", DateTime.Now);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw new CustomException(ErrorCode.ReviewSavingError);
            }
        }


        public double GetAverageScore(int gameId)
        {
            double averageScore = 0;

            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT AVG(CAST(rating as DECIMAL(5, 2))) as AverageScore FROM dbo.Review WHERE game_id=@game_id", _conn))
                {
                    cmd.Parameters.AddWithValue("@game_id", gameId);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (!reader.IsDBNull(reader.GetOrdinal("AverageScore")))
                        {
                            averageScore = (double)reader.GetDecimal(reader.GetOrdinal("AverageScore"));
                        }
                    }
                    reader.Close();
                }
            }
            catch (SqlException)
            {
                throw new CustomException(ErrorCode.ReviewRetrievalError);
            }

            return averageScore;
        }


        public void AddReport(int reviewId, string userId, string reportText)
        {
            string sql = "INSERT INTO Report (review_id, user_id, ReportText) VALUES (@reviewId, @userId, @reportText)";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@reviewId", reviewId);
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@reportText", reportText);

                command.ExecuteNonQuery();
            }
        }


        public List<Report> GetAllReports()
        {
            List<Report> reports = new List<Report>();

            string sql = "SELECT * FROM Report";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        int reviewId = reader.GetInt32(1);
                        string userId = reader.GetString(2);
                        string reportText = reader.GetString(3);

                        reports.Add(new Report(id, reviewId, userId, reportText));
                    }
                }
            }

            return reports;
        }


        public void DeleteReportedReview(int reviewId)
        {
            string sql = "DELETE FROM Review WHERE review_id = @reviewId";

            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@reviewId", reviewId);

                command.ExecuteNonQuery();
            }
        }


        public void DeleteReport(int reportId)
        {
            string sql = "DELETE FROM Report WHERE report_id = @reportId";
            using (SqlCommand command = new SqlCommand(sql, _conn))
            {
                command.Parameters.AddWithValue("@reportId", reportId);

                command.ExecuteNonQuery();
            }
        }


        public Review GetReviewById(int id)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Review WHERE review_id = @id", _conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int reviewId = reader.GetInt32(reader.GetOrdinal("review_id"));
                        int gameId = reader.GetInt32(reader.GetOrdinal("game_id"));
                        string userId = reader.GetString(reader.GetOrdinal("user_id"));
                        int rating = reader.GetInt32(reader.GetOrdinal("rating"));
                        string comment = reader.GetString(reader.GetOrdinal("comment"));
                        DateTime reviewDate = reader.GetDateTime(reader.GetOrdinal("created_at"));

                        return new Review(reviewId, gameId, userId, string.Empty, rating, comment, reviewDate);
                    }
                }
            }

            return null;
        }

        public Report GetReportByReportText(string reportText)
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Report WHERE ReportText = @ReportText", _conn))
            {
                command.Parameters.AddWithValue("@ReportText", reportText);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int reportId = (int)reader["report_id"];
                        int reviewId = (int)reader["review_id"];
                        string userId = (string)reader["user_id"];

                        Report report = new Report(reportId, reviewId, userId, reportText);


                        return report;
                    }
                }
            }

            return null;
        }
    }
}
