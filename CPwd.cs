using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DQF_30_01_15
{
    public partial class CPwd : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=Abraham");

        public CPwd()
        {
            InitializeComponent();
        }

        //button controls
        private void button1_Click_1(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, "");
            if (textBox2.Text.Trim().Equals(""))
            {
                errorProvider1.SetError(textBox2, "Password is mandatory");
            }
            else
            {
                if (textBox2.TextLength >= 8)
                {
                    try
                    {
                        con.Open();

                        SqlCommand cmd = new SqlCommand("update users set pswd='" + textBox2.Text + "' where usid='" + textBox1.Text + "'", con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Password Updated!");
                        con.Close();
                        this.Close();
                    }

                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message);
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox2, "Password should be atleast 8 characters");
                }

            }
        }
        
        
        private void CPwd_Load(object sender, EventArgs e)
        {
            textBox1.Text = DB.lusid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
