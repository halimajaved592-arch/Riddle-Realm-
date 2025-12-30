using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class AdminForm : Form
    {
     
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["RRDB"].ConnectionString;
        public AdminForm()
        {
            InitializeComponent();
        
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUserForm form = new AddUserForm();
            form.ShowDialog();
            LoadUsers(); // Refresh grid after adding
            MessageBox.Show("Add User clicked!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to delete.");
                return;
            }
            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            string username = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete '{username}'?", "Confirm Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Users WHERE Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadUsers();
                MessageBox.Show("User deleted.");
            }
            MessageBox.Show("Delete User clicked!");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to edit.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
            string currentUsername = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();

            string newUsername = Microsoft.VisualBasic.Interaction.InputBox("Edit Username:", "Edit User", currentUsername);

            if (string.IsNullOrWhiteSpace(newUsername))
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Users SET Username = @Username WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", newUsername);
                cmd.Parameters.AddWithValue("@Id", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadUsers();
            MessageBox.Show("User updated.");
            MessageBox.Show("Edit User clicked!");
        }

        private void btnAddlevels_Click(object sender, EventArgs e)
        {
            string levelName = Microsoft.VisualBasic.Interaction.InputBox("Enter level name:", "Add Level");

            if (string.IsNullOrWhiteSpace(levelName))
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Levels (LevelName) VALUES (@name)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", levelName);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Level added!");
            // Call your LoadLevels() method if you add a grid to show levels

        }

        private void btnEditlevels_Click(object sender, EventArgs e)
        {
            if (dgvLevels.SelectedRows.Count == 0) return;

            int levelId = Convert.ToInt32(dgvLevels.SelectedRows[0].Cells["LevelID"].Value);
            string currentName = dgvLevels.SelectedRows[0].Cells["LevelName"].Value.ToString();
            string newName = Interaction.InputBox("Edit Level Name:", "Edit Level", currentName);

            if (string.IsNullOrWhiteSpace(newName)) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Levels SET LevelName = @name WHERE LevelID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@id", levelId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadLevels();
            MessageBox.Show("Level updated!");
        }

        private void btlDellevels_Click(object sender, EventArgs e)
        {
            if (dgvLevels.SelectedRows.Count == 0) return;

            int levelId = Convert.ToInt32(dgvLevels.SelectedRows[0].Cells["LevelID"].Value);
            var result = MessageBox.Show("Delete this level?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Levels WHERE LevelID = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", levelId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadLevels();
                MessageBox.Show("Level deleted!");
            }
        }

        private void btnAddriddles_Click(object sender, EventArgs e)
        {
            
            string question = Interaction.InputBox("Enter riddle question:", "Add Riddle");
            string answer = Interaction.InputBox("Enter riddle answer:", "Add Riddle");
            string hint = Interaction.InputBox("Enter riddle hint:", "Add Riddle");
            int levelId = 0;
            if (cmbLevels.SelectedItem is ComboBoxItem selectedLevel)
            {
               
                if (cmbLevels.SelectedItem is ComboBoxItem selectedLevelitem)
                {
                    levelId = selectedLevelitem.Value;
                }
                else
                {
                    MessageBox.Show("Please select a level.");
                    return; // Stop if no level is selected
                }
             // Proceed with riddle question, answer, and hint as before...
            }
           

            if (string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(answer))
                return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Riddles (LevelID, Question, Answer, Hint) VALUES (@levelId, @question, @answer, @hint)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@levelId", levelId);
                cmd.Parameters.AddWithValue("@question", question);
                cmd.Parameters.AddWithValue("@answer", answer);
                cmd.Parameters.AddWithValue("@hint", hint);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Riddle added!");
            LoadRiddles();
            // Call LoadRiddles(); if you're displaying riddles in a grid
        }
        private void SetupRiddleGrid()
        {
            dgvriddle.ReadOnly = false;               // Allow editing
            dgvriddle.Columns["RiddleId"].ReadOnly = true; // Keep ID read-only
        }
        private void btnEditriddles_Click(object sender, EventArgs e)
        {
            if (dgvriddle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a riddle to edit.");
                return;
            }

            // Allow editing (if your grid was set ReadOnly before)
            dgvriddle.ReadOnly = false;
            dgvriddle.Columns["RiddleId"].ReadOnly = true; // Keep ID read-only

            // Optionally, focus on the selected row and first editable cell
            DataGridViewRow row = dgvriddle.SelectedRows[0];
            dgvriddle.CurrentCell = row.Cells["Question"];
            dgvriddle.BeginEdit(true);
        }

        private void btnDelriddles_Click(object sender, EventArgs e)
        {
            if (dgvriddle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a riddle to delete.");
                return;
            }

            int selectedRowIndex = dgvriddle.SelectedRows[0].Index;
            int riddleId = Convert.ToInt32(dgvriddle.Rows[selectedRowIndex].Cells["RiddleId"].Value);

            var confirmResult = MessageBox.Show("Are you sure to delete this riddle?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // DELETE LOGIC GOES HERE:

                // Example for in-memory list:
                /*
                var riddleToRemove = riddleList.FirstOrDefault(r => r.Id == riddleId);
                if (riddleToRemove != null)
                {
                    riddleList.Remove(riddleToRemove);
                }
                */

                // Example for Entity Framework or DB context:
                /*
                var riddle = dbContext.Riddles.Find(riddleId);
                if (riddle != null)
                {
                    dbContext.Riddles.Remove(riddle);
                    dbContext.SaveChanges();
                }
                */

                // Then reload the grid data
                LoadRiddles();
            }
        }
    

        private void btnRefreashProgress_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
        SELECT 
            up.ProgressID, 
            u.Username, 
            r.Question, 
            up.IsCompleted
        FROM UserProgress up
        JOIN Users u ON up.UserID = u.UserID
        JOIN Riddles r ON up.LevelID = r.LevelID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvProgress.DataSource = table;
            }
        }

        private void btnResetProgress_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["Id"].Value);

            DialogResult result = MessageBox.Show("Are you sure you want to reset progress for this user?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM UserProgress WHERE UserID = @UserID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("User progress reset.");
            }
        }
        private void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT UserID, Username FROM Users";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvUsers.DataSource = table;
            }
        }


        private void LoadLevels()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT LevelID, LevelName FROM Levels";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvLevels.DataSource = table;
            }
        }
        private void LoadRiddles()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT DISTINCT r.RiddleID, l.LevelName, r.Question, r.Answer, r.Hint
                 FROM Riddles r
                 INNER JOIN Levels l ON r.LevelID = l.LevelID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
              
                dgvriddle.DataSource = null;
                dgvriddle.DataSource = table;


            }
        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadLevels();
            LoadUsers();
            LoadRiddles();
            LoadLevelComboBox(); 
            // Optional UI enhancements for better readability
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLevels.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvriddle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProgress.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLevels.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvriddle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProgress.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvUsers.MultiSelect = false;
            dgvLevels.MultiSelect = false;
            dgvriddle.MultiSelect = false;
            dgvProgress.MultiSelect = false;
        }

        private void btnSaveRiddleEdit_Click(object sender, EventArgs e)
        {
            if (dgvriddle.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a riddle to save.");
                return;
            }

            DataGridViewRow selectedRow = dgvriddle.SelectedRows[0];

            int riddleId = Convert.ToInt32(selectedRow.Cells["RiddleID"].Value);
            string updatedQuestion = selectedRow.Cells["Question"].Value?.ToString() ?? "";
            string updatedAnswer = selectedRow.Cells["Answer"].Value?.ToString() ?? "";
            string updatedHint = selectedRow.Cells["Hint"].Value?.ToString() ?? "";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Riddles SET Question = @question, Answer = @answer, Hint = @hint WHERE RiddleID = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@question", updatedQuestion);
                cmd.Parameters.AddWithValue("@answer", updatedAnswer);
                cmd.Parameters.AddWithValue("@hint", updatedHint);
                cmd.Parameters.AddWithValue("@id", riddleId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Riddle updated successfully.");
            LoadRiddles();
            dgvriddle.ReadOnly = true; // Optional: make grid readonly again after saving
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["RRDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Database connected successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to DB: " + ex.Message);
                }
            }
        }
        private void LoadLevelComboBox()
        {
            cmbLevels.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT LevelID, LevelName FROM Levels";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbLevels.Items.Add(new ComboBoxItem
                    {
                        Text = reader["LevelName"].ToString(),
                        Value = Convert.ToInt32(reader["LevelID"])
                    });
                }
            }

            if (cmbLevels.Items.Count > 0)
                cmbLevels.SelectedIndex = 0;
        }

        // Helper class
        private class ComboBoxItem
        {
            public string Text { get; set; }
            public int Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginFor loginForm = new LoginFor();
            loginForm.Show();
            this.Close();  // closes the AdminForm
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            LoginFor loginForm = new LoginFor();
            // Show the login form
            loginForm.Show();
            // Close or hide this admin form
            this.Close(); // or this.Hide();
        }
    }

    }
  