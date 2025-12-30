using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class User
    {
        public int UserID { get; set; }          // Unique ID from database
        public string Username { get; set; }     // Username
        public string PasswordHash { get; set; } // Password (hashed or plain for now)
        public string Role { get; set; }         // User role, e.g. "Admin" or "Player"
    }
}
