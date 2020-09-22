using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Data.SqlClient;

namespace DQF_30_01_15
{
    public partial class login : Form
    {
        SqlConnection con = null;
        public login()
        {
            InitializeComponent();
            
            con = new SqlConnection(DB.GetConnectionStringByName("DBName"));
        }



        //button controls
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //validation for Login/Password 
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");

                if (!textBox1.Text.Equals(""))
                {
                    if (!textBox2.Text.Equals(""))
                    {
                        con.Open();
                        SqlCommand cmd = null;
                        cmd = new SqlCommand("select * from users where usid='" + textBox1.Text + "' and pswd='" + textBox2.Text + "'", con);

                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                        if (dr.Read())
                        {
                            DB.lusid = textBox1.Text;
                            MenuOptions m = new MenuOptions();
                            this.Hide();
                            m.ShowDialog();
                        }
                        else
                            MessageBox.Show("User Authentication Failed! Check Parameters");
                    }
                    else
                    {
                        errorProvider1.SetError(textBox2, "Password is mandatory");
                    }
                }
                else
                {
                    errorProvider1.SetError(textBox1, "User ID is mandatory");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

            

    }
}
