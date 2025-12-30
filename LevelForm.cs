using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LevelForm: Form
    {
        public LevelForm()
        {
            InitializeComponent();
           
        }

        private void btneasy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Easy level selected!");
            RiddleForm1 riddleForm = new RiddleForm1("easy");
            riddleForm.Show();
            this.Hide();
           
        }
        private void btnmedium_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Medium level selected!");
            RiddleForm1 riddleForm = new RiddleForm1("medium");
            riddleForm.Show();
            this.Hide();
        }

        private void btnhard_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Hard level selected!");
            RiddleForm1 riddleForm = new RiddleForm1("hard");
            riddleForm.Show();
            this.Hide();
        }
    }
}
