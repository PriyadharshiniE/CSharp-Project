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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           if(textBox1.Text == "")
            {
                MessageBox.Show("Enter the Email");
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Enter the Password");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection("Data Source=USER-PC\\MYSQLSERVER2019;Initial Catalog=Hotels;Integrated Security=True");
                    SqlCommand cmd = new SqlCommand("Select * from tbl_customerregister Where Email = @Email and Passwords = @Passwords", con);
                    cmd.Parameters.AddWithValue("@Email", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Passwords", textBox2.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    if(dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login Successfull");
                    }
                    else
                    {
                        MessageBox.Show("Invalid Email/Password");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            f2 = null;
            this.Show();
        }

        

        
    }
}
