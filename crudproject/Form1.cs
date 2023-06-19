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
using crudproject;

namespace crudproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-1VKUE0I\\SQLEXPRESS;Initial Catalog=pankali;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int regid = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["regid"].Value);

                con.Open();
                SqlCommand cmd = new SqlCommand("exec deleteregister @regid", con);
                 cmd.Parameters.AddWithValue("@regid", regid);
                    MessageBox.Show("Successfully Deleted");
                    cmd.ExecuteNonQuery();

                con.Close();
                GetList();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        void ClearFields()
        {
            fname.Text = string.Empty;
            lname.Text = string.Empty;
            dob.Text = string.Empty;
            age1.Text = string.Empty;
            uname.Text = string.Empty;
            pwd.Text = string.Empty;
            cpwd.Text = string.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            dataGridView1.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetList();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string firstname = fname.Text;
            string lastname = lname.Text;
            DateTime DOB = DateTime.Parse(dob.Text);
            int age = int.Parse(age1.Text);
            string gender = "";
            string username = uname.Text;
            string password = pwd.Text;
            string cpassword = cpwd.Text;
            if (radioButton1.Checked == true)
            {
                gender = "Male";
            }
            else if (radioButton2.Checked == true)
            {
                gender = "Female";
            }
            else
            {
                gender = "Transgender";
            }

            con.Open();
            SqlCommand cmd = new SqlCommand("exec insertregister @fname, @lname, @dob, @age, @gender, @username, @password, @cpassword", con);
            cmd.Parameters.AddWithValue("@fname", firstname);
            cmd.Parameters.AddWithValue("@lname", lastname);
            cmd.Parameters.AddWithValue("@dob", DOB);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@cpassword", cpassword);
            MessageBox.Show("Successfully Inserted");
            cmd.ExecuteNonQuery();

            con.Close();
            GetList();
            ClearFields();

        }
        void GetList()
        {
            SqlCommand cmd = new SqlCommand("exec readregister", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int regid = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["regid"].Value);

                string firstname = fname.Text;
                string lastname = lname.Text;
                DateTime DOB = DateTime.Parse(dob.Text);

                int age;
                if (!int.TryParse(age1.Text, out age))
                {
                    MessageBox.Show("Invalid age input. Please enter a valid integer value.");
                    return;
                }

                string gender = "";
                string username = uname.Text;
                string password = pwd.Text;
                string cpassword = cpwd.Text;

                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton2.Checked)
                {
                    gender = "Female";
                }
                else
                {
                    gender = "Transgender";
                }
                con.Open();
                using (SqlCommand cmd = new SqlCommand("exec updateregister @regid, @fname, @lname, @dob, @age, @gender, @username, @password, @cpassword", con))
                {
                    cmd.Parameters.AddWithValue("@regid", regid);
                    cmd.Parameters.AddWithValue("@fname", firstname);
                    cmd.Parameters.AddWithValue("@lname", lastname);
                    cmd.Parameters.AddWithValue("@dob", DOB);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@cpassword", cpassword);
                    MessageBox.Show("Successfully Updated");
                    cmd.ExecuteNonQuery();
                }

                con.Close();
                GetList();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Please select a row to update.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
    }



    

 