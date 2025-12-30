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
using WindowsFormsApp1;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security.Cryptography;

namespace WindowsFormsApp1
{
    public partial class LoginFor: Form
    {
        public LoginFor()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
      

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            try
            {
                string connStr = ConfigurationManager.ConnectionStrings["RRDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                   
                    string query = "SELECT Role FROM Users WHERE Username = @username AND PasswordHash = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username",username);
                        cmd.Parameters.AddWithValue("@password",password); // replace with hashed version later

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string role = result.ToString();

                            MessageBox.Show("Login successful!");

                            if (role == "Admin")
                            {
                                AdminForm adminForm = new AdminForm();
                                adminForm.Show();
                            }
                            else
                            {
                                LevelForm levelForm = new LevelForm();
                                levelForm.Show();
                            }

                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                            txtPassword.Clear();
                            txtUsername.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message);
            }
        }
        
        

        private void btnOpenReg_Click(object sender, EventArgs e)
        {
            RegForm regForm = new RegForm();
            regForm.Show();
            this.Hide();
        }
    }
}
