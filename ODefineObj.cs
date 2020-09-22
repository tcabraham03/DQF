using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace DQF_30_01_15
{
    public partial class ODefineObj : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=abraham");
        OdbcConnection con = new OdbcConnection("Dsn=oradsn;uid=System;pwd=Abraham");
        public ODefineObj()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1,"");
            if (!textBox1.Text.Trim().Equals(""))
            {
                try
                {
                    con.Open();
                    String sqlstmt = textBox1.Text.Trim();
                    String wd = sqlstmt.Substring(0, sqlstmt.IndexOf(" ")).ToLower();
                    if (wd.Equals("create") || wd.Equals("alter") || wd.Equals("drop") || wd.Equals("insert"))
                    {
                        OdbcCommand cmd = new OdbcCommand(textBox1.Text, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Object Defined Successfully!");
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                    else
                        MessageBox.Show("Create | Alter | Drop are only supported. Check SQL!");
                    String[] tname = sqlstmt.Split(' ');
                    //SqlCommand cmd2 = new SqlCommand("insert into ownership values('" + DB.lusid + "','" + tname[2].Substring(0,tname[2].IndexOf("(")) + "')", con);
                    //cmd2.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter DDL Statements");
                errorProvider1.SetError(textBox1,"enter DDL Statements");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
