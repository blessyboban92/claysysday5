using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace loginproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1VKUE0I\SQLEXPRESS;Initial Catalog=pankali;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(username.Text.Trim()))
            {
                errorProvider1.SetError(username, "Username is required");
                return;
            }
            else if (!Regex.IsMatch(username.Text, "^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(username, "Username should contain only letters");
                return;
            }
            else
            {
                errorProvider1.SetError(username, string.Empty);
            }
            if (string.IsNullOrEmpty(password.Text.Trim()))
            {
                errorProvider1.SetError(password, "password is required");
                return;
            }
            else if (password.Text.Length < 8)
            {
                errorProvider1.SetError(password, "Password must be at least 8 characters long");
                return;
            }
            else
            {
                errorProvider1.SetError(password, string.Empty);
            }
            string userName = username.Text;
            string passWord = password.Text;


            string query = "SELECT * FROM logintbl WHERE username = @username AND password = @password";



            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@username", userName);
            cmd.Parameters.AddWithValue("@password", passWord);

// con.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sda.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
            {
                success s = new success();
                s.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid sign-in details.");
            }
        }
    }
}
