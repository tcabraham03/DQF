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
    public partial class DefineObj : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=Abraham");
        public DefineObj()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fg = 1;
            try
            {
                errorProvider1.SetError(textBox1, "");
                con.Open();
                String sqlstmt = textBox1.Text.Trim();
                String wd = sqlstmt.Substring(0, sqlstmt.IndexOf(" ")).ToLower();
                if (wd.Equals("create") || wd.Equals("alter") || wd.Equals("drop") || wd.Equals("insert"))
                {
                    SqlCommand cmd = new SqlCommand(textBox1.Text, con);
                    cmd.ExecuteNonQuery();
                    fg = 2;
                    MessageBox.Show("Object Defined Successfully!");
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                    MessageBox.Show("Create | Alter | Drop are only supported. Check SQL!");
                String []tname=sqlstmt.Split(' ');
                SqlCommand cmd2 = new SqlCommand("insert into ownership values('" + DB.lusid + "','" + tname[2].Substring(0,tname[2].IndexOf("(")) + "')", con);
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                if (fg == 1)
                {
                    MessageBox.Show("Please specify DDL Object /n" + ee.Message);
                    errorProvider1.SetError(textBox1, "Please specify DDL Object");
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
