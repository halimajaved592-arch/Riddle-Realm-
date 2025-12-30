using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
            txtConfirm.UseSystemPasswordChar = true;
        }
       
        private void btnReg_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["RRDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
               
                string query = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@username, @password, @role)";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password); // Later: hash passwords before saving
                    cmd.Parameters.AddWithValue("@role", "Player");

                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registration successful!");

                        LevelForm levelForm = new LevelForm();
                        levelForm.Show();

                        this.Hide();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627) // Unique constraint violation number in SQL Server
                        {
                            MessageBox.Show("Username already exists.");
                        }
                        else
                        {
                            MessageBox.Show("Database error: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
   