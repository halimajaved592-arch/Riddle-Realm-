using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class RiddleForm1 : Form
    {
        private int score = 0;
        private int riddleNumber = 0;
        private string correctAnswer = "";
        private string hint = "";
        private string difficulty;
        private List<(string Question, string Answer, string Hint)> riddles = new List<(string, string, string)>();

        public RiddleForm1()
        {
            if (!TestDatabaseConnection())
            {
                MessageBox.Show("Cannot connect to database. The application will close.");
                this.Close(); // Close form if DB connection fails
                return;
            }
            InitializeComponent();
            difficulty = "easy";
            LoadRiddlesFromDatabase();
        }
      

        public RiddleForm1(string difficultyLevel)
        {
            InitializeComponent();
            difficulty = difficultyLevel.ToLower();
            LoadRiddlesFromDatabase();
        }

        private void LoadRiddlesFromDatabase()
        {
            riddles.Clear();
            string connStr = ConfigurationManager.ConnectionStrings["RRDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = @"
                    SELECT R.Question, R.Answer, R.Hint
                    FROM Riddles R
                    JOIN Levels L ON R.LevelID = L.LevelID
                    WHERE L.LevelName = @levelName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@levelName", difficulty);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            riddles.Add((
                                reader["Question"].ToString(),
                                reader["Answer"].ToString(),
                                reader["Hint"].ToString()
                            ));
                        }
                    }
                }
            }

            if (riddles.Count > 0)
            {
                riddleNumber = 0;
                LoadNextRiddle();
            }
            else
            {
                MessageBox.Show("No riddles found for this level.");
            }
        }

        private void LoadNextRiddle()
        {
            if (riddleNumber < riddles.Count)
            {
                lblRiddleNumber.Text = $"RIDDLE: {riddleNumber + 1}";
                lblQuestion.Text = riddles[riddleNumber].Question;
                correctAnswer = riddles[riddleNumber].Answer;
                hint = riddles[riddleNumber].Hint;
            }
            else
            {
                MessageBox.Show($"All riddles completed! Your score is {score}.");
                LevelForm levelForm = new LevelForm();
                levelForm.Show();
                this.Hide();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string userAnswer = txtAnswer.Text.Trim().ToLower();

            if (userAnswer == correctAnswer.ToLower())
            {
                score++;
                lblScore.Text = "Score: " + score.ToString();
                MessageBox.Show("Correct!");

                riddleNumber++;

                if (riddleNumber >= riddles.Count)
                {
                    // All riddles answered
                    MessageBox.Show($"You completed all riddles with score {score}!");
                    LevelForm levelForm = new LevelForm();
                    levelForm.Show();
                    this.Hide();
                }
                else
                {
                    txtAnswer.Clear();
                    LoadNextRiddle();
                }
            }
            else
            {
                MessageBox.Show("Incorrect. Try again!");
            }
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hint: " + hint);
        }
        private void label3_Click(object sender, EventArgs e)
        {
            // This method is intentionally left empty to handle label click without error
        }
        private void lblScore_Click(object sender, EventArgs e)
        {
            // You can leave this empty if you don't want anything on click
        }
        private bool TestDatabaseConnection()
        {
            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["RRDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();  // Try to open the connection
                    return true;  // Success
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message);
                return false;
            }
        }

        private void RiddleForm1_Load(object sender, EventArgs e)
        {

            
        }
    }
}
