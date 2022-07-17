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

namespace Loginform2
{
    public partial class Form2 : Form
    {
        string ConnectionString = "Data Source=USER-PC\\MYSQLSERVER2019;Initial Catalog=Hotels;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != textBox6.Text)
                MessageBox.Show("Password do not Match");
            else
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("CustomerRegisterInsert", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    string Gender = "";
                    if(radioButton1.Checked==true)
                    {
                        Gender = radioButton1.Text;
                    }
                    else
                    {
                        Gender = radioButton2.Text;
                    }
                    cmd.Parameters.AddWithValue("@FirstName", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", textBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("Dob", DateTime.Parse(dateTimePicker1.Text));
                    cmd.Parameters.AddWithValue("@Address", textBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhoneNumber", textBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@Passwords", textBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@ConfirmPassword", textBox6.Text.Trim());
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration is Successfull");
                    Clear();

                }
            }
        }
        void Clear()
        {
            textBox1.Text = textBox2.Text = radioButton1.Text = radioButton2.Text =dateTimePicker1.Text= textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            f1 = null;
            this.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
