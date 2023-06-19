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
using demoproject;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace demoproject
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
       
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-1VKUE0I\SQLEXPRESS;Initial Catalog=pankali;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = username.Text;
            string passWord = password.Text;


            string query = "SELECT * FROM logintbl WHERE username = @username AND password = @password";



            SqlCommand cmd = new SqlCommand(query, con);
                
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@password", passWord);

                    con.Open();

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

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
        }

    

    

