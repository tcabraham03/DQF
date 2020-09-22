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
    public partial class OraclePostView : Form
    {
        OdbcConnection con = null;

        public OraclePostView()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
            if (!textBox1.Text.Trim().Equals(""))
            {
                try
                {

                    con = new OdbcConnection("Dsn=oradsn;uid=system;pwd=Abraham");
                    con.Open();
                    String Odbcstmt = textBox1.Text.Trim();
                    String wd = Odbcstmt.Substring(0, Odbcstmt.IndexOf(" ")).ToLower();
                    if (wd.Equals("insert") || wd.Equals("update") || wd.Equals("delete"))
                    {
                        OdbcCommand cmd = new OdbcCommand(textBox1.Text, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Object Defined Successfully!");
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                    else
                        if (wd.Equals("select"))
                        {


                            OdbcCommand cmd = new OdbcCommand(textBox1.Text, con);
                            OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                            DataSet ds = new System.Data.DataSet();
                            da.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];

                            SqlConnection con1 = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=Abraham");
                            con1.Open();
                            SqlCommand cmd2 = new SqlCommand("select * from oraqryrank", con1);
                            SqlDataReader dr2 = cmd2.ExecuteReader(CommandBehavior.SequentialAccess);

                            int fg = 0;
                            String tqy = textBox1.Text.Replace("'", "?");
                            while (dr2.Read())
                            {
                                if (dr2.GetValue(1).ToString().ToLower().Equals(tqy.ToLower()))
                                {
                                    fg = 1;
                                }
                            }
                            dr2.Close();
                            String qy = "";
                            if (textBox1.Text.IndexOf("'") > 0)
                                qy = textBox1.Text.Replace("'", "?");
                            else
                                qy = textBox1.Text;
                            con1.Close();
                            if (fg == 0)
                            {



                                if (con.State == ConnectionState.Closed)
                                    con.Open();
                                SqlConnection con2 = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=Abraham");
                                con2.Open();
                                SqlCommand cmd20 = new SqlCommand("insert into oraqryrank values('" + DB.lusid + "','" + qy + "','" + DateTime.Today.ToShortDateString() + "',0)", con2);
                                cmd20.ExecuteNonQuery();
                                con2.Close();
                            }
                            else
                            {
                                SqlConnection con2 = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=Abraham");
                                con2.Open();
                                SqlCommand cmd21 = new SqlCommand("update oraqryrank set rankid = rankid + " + 1 + " where qry='" + qy + "'", con2);
                                cmd21.ExecuteNonQuery();
                                con2.Close();
                            }


                        }
                        else
                            MessageBox.Show("Insert | Update | Delete | Select are only supported. Check Odbc!");
                    con.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message+"\n Enter DML Statement");
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter DML Statement");
                errorProvider1.SetError(textBox1, "Enter DML Statement");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String Odbcstmt = textBox1.Text.Trim();
            String wd="";
            try
            {
                 wd= Odbcstmt.Substring(0, Odbcstmt.IndexOf(" ")).ToLower();
            }
            catch (Exception ee) { }
            //if (wd.Equals("select"))
            try
            {
                //con = new OdbcConnection("Provider=Microsoft.ACE.Odbc.12.0;Data Source=" + textBox2.Text);
                SqlConnection con2 = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=Abraham");
                {
                    con2.Open();
                    SqlCommand cmd = new SqlCommand("select * from oraqryrank where qry like('" + textBox1.Text + "%') order by rankid desc ", con2);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    listBox1.Items.Clear();

                    while (dr.Read())
                    {
                        String qy = dr.GetValue(1).ToString();
                        if (qy.IndexOf("?")>0)
                            qy = qy.Replace("?", "'");
                        listBox1.Items.Add(qy);
                    }
                    dr.Close();
                    con2.Close();
                }
            }
            catch (Exception ee) 
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void OraclePostView_Load(object sender, EventArgs e)
        {

        }
    }
}
