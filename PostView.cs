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
    public partial class PostView : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=Abraham");
        public PostView()
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
                    con.Open();
                    String sqlstmt = textBox1.Text.Trim();
                    String wd = sqlstmt.Substring(0, sqlstmt.IndexOf(" ")).ToLower();
                    if (wd.Equals("insert") || wd.Equals("update") || wd.Equals("delete"))
                    {
                        SqlCommand cmd = new SqlCommand(textBox1.Text, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Object Defined Successfully!");
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                    else
                        if (wd.Equals("select"))
                        {
                            SqlCommand cmd = new SqlCommand(textBox1.Text, con);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new System.Data.DataSet();
                            da.Fill(ds);
                            dataGridView1.DataSource = ds.Tables[0];

                            SqlCommand cmd2 = new SqlCommand("select * from qryrank", con);
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

                            if (fg == 0)
                            {



                                if (con.State == ConnectionState.Closed)
                                    con.Open();
                                //ranking Query
                                SqlCommand cmd20 = new SqlCommand("insert into qryrank values('" + DB.lusid + "','" + qy + "','" + DateTime.Today.ToShortDateString() + "',0)", con);
                                cmd20.ExecuteNonQuery();
                            }
                            else
                            {
                                SqlCommand cmd21 = new SqlCommand("update qryrank set rankid = rankid + " + 1 + " where qry='" + qy + "'", con);
                                cmd21.ExecuteNonQuery();

                            }

                        }
                        else
                            MessageBox.Show("Insert | Update | Delete | Select are only supported. Check SQL!");
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
            String sqlstmt = textBox1.Text.Trim();
            String wd="";
            try
            {
                 wd= sqlstmt.Substring(0, sqlstmt.IndexOf(" ")).ToLower();
            }
            catch (Exception ee) { }
                       //if (wd.Equals("select"))
            try
            {
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from qryrank where qry like('" + textBox1.Text + "%') order by rankid desc ", con);
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
                    con.Close();
                }
            }
            catch (Exception ee) { con.Close(); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
