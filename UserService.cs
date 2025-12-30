using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class UserService
    {
        // Replace this with your actual DB connection string
        private string connectionString = @"Data Source=(localdb)\RiddleRealmInstance;Initial Catalog=RiddleRealmDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Register a new user
        public bool RegisterUser(string username, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@username, @password, @role)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password); // For now plain text, consider hashing later
                cmd.Parameters.AddWithValue("@role", role);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0; // True if insert successful
            }
        }

        // Login user and return User object if success, else null
        public User LoginUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @username AND PasswordHash = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    User user = new User
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        Username = reader["Username"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Role = reader["Role"].ToString()
                    };
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }

        // Update user progress (mark level as completed)
        public void UpdateUserProgress(int userID, int levelID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Check if record exists
                string checkQuery = "SELECT COUNT(*) FROM UserProgress WHERE UserID = @userID AND LevelID = @levelID";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@userID", userID);
                checkCmd.Parameters.AddWithValue("@levelID", levelID);

                conn.Open();
                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0)
                {
                    // Insert new progress record
                    string insertQuery = "INSERT INTO UserProgress (UserID, LevelID, IsCompleted) VALUES (@userID, @levelID, 1)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@userID", userID);
                    insertCmd.Parameters.AddWithValue("@levelID", levelID);

                    insertCmd.ExecuteNonQuery();
                }
                else
                {
                    // Update existing progress record to completed
                    string updateQuery = "UPDATE UserProgress SET IsCompleted = 1 WHERE UserID = @userID AND LevelID = @levelID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@userID", userID);
                    updateCmd.Parameters.AddWithValue("@levelID", levelID);

                    updateCmd.ExecuteNonQuery();
                }
            }
        }
    }
}
