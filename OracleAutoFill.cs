﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace DQF_30_01_15
{
    public partial class OracleAutoFill : Form
    {
        SqlConnection con1 = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=Abraham");
        SqlConnection con = null;

        OdbcConnection con2 = new OdbcConnection("Dsn=oradsn;uid=system;pwd=Abraham");
                

        public OracleAutoFill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int fg = 0;

            try
            {
                
                try
                {
                    
                    con2.Open();
                }
                catch (Exception e2)
                {
                    fg = 1;
                    
                }
                //MessageBox.Show(fg.ToString());
                if (fg == 0)
                {
                    panel1.Enabled = true;
                    OdbcCommand cmd = new OdbcCommand("SELECT table_name FROM user_catalog", con2);
                    OdbcDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    comboBox1.Items.Clear();
                    while (dr.Read())
                    {
                        comboBox1.Items.Add(dr.GetValue(0).ToString());
                    }
                    dr.Close();
                }
                else
                    MessageBox.Show("Check Server Parameters!");

            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        
            con2.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                comboBox2.Items.Clear();
                con2.Open();
                OdbcCommand cmd = new OdbcCommand(" select column_name from all_tab_columns where table_name = '" + comboBox1.Text.ToUpper() + "'", con2);
                OdbcDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
               
                while (dr.Read())
                {
                    String col=dr.GetValue(0).ToString();
                    checkedListBox1.Items.Add(col);
                    comboBox2.Items.Add(col);
                }
                dr.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
            con2.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int i;
            int fg = 0;
            String data="";
            for (i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked )
                {
                    data = data + checkedListBox1.Items[i].ToString() + ",";
                    fg = 1;
                }
                //MessageBox.Show(data);
            }
            if (fg == 1)
            {
                data = data.Substring(0, data.Length - 1);
                textBox5.Text = "select " + data + " from " + comboBox1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String qry = textBox5.Text.Trim();
            if (!qry.Equals(""))
            {
                try
                {
                    //MessageBox.Show("aaA->" + textBox5.Text + "<-");
                    con2.Open();
                    textBox5.Text = textBox5.Text.Replace("''", "'");
                    MessageBox.Show(textBox5.Text);
                    OdbcCommand cmd = new OdbcCommand(textBox5.Text, con2);
                    OdbcDataAdapter da = new OdbcDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                }
                catch (Exception ee)
                {
                    //MessageBox.Show(ee.Message);

                }
                con2.Close();
                con1.Open();
               
                String rst = "";
                rst = textBox5.Text.Replace("'", "?");
                SqlCommand cmd2 = new SqlCommand("select * from oraqryrank", con1);
                SqlDataReader dr2 = cmd2.ExecuteReader(CommandBehavior.SequentialAccess);

                int fg = 0;
                while (dr2.Read())
                {
                    if (dr2.GetValue(1).ToString().ToLower().Equals(textBox5.Text.ToLower()))
                    {
                        fg = 1;
                    }
                }
                dr2.Close();
                MessageBox.Show("Waiting....." + fg);
                if (fg == 0)
                {
                    SqlCommand cmd20 = new SqlCommand("insert into oraqryrank values('" + DB.lusid + "','" + rst + "','" + DateTime.Today.ToShortDateString() + "',0)", con1);
                    cmd20.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd21 = new SqlCommand("update oraqryrank set rankid = rankid + " + 1 + " where qry='" + rst + "'", con1);
                    cmd21.ExecuteNonQuery();

                }


                con1.Close();

            }
            else
                MessageBox.Show("Query is not specified!");
            //if (con.State == ConnectionState.Open)
            //    con.Close();
            if (con1.State == ConnectionState.Open)
                con1.Close();

           // MessageBox.Show("Error Closed");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String cname, opr, data;
            cname = comboBox2.Text.Trim();
            opr = comboBox3.Text.Trim();
            if (textBox6.Text.IndexOf("'") > 0)
                textBox6.Text = textBox6.Text.Replace("'", "''");
            data = "";
            try
            {
                con2.Open();
                //MessageBox.Show("select DATA_TYPE from all_tab_columns where table_name='" + comboBox1.Text.ToUpper() + " and column_name='" + comboBox2.Text.ToUpper() + "'");
                OdbcCommand cmd = new OdbcCommand("select DATA_TYPE from all_tab_columns where table_name='" + comboBox1.Text.ToUpper()  +"' and column_name='" + comboBox2.Text.ToUpper() + "'", con2);
                OdbcDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr.Read())
                {
                    String ctyp = dr.GetValue(0).ToString().ToLower();
                  //  MessageBox.Show(ctyp);
                    if(ctyp.ToLower().Equals("number"))
                    data = textBox6.Text.Trim();
                    else
                        data = "'" + textBox6.Text.Trim() + "'";

                }
                MessageBox.Show("done");
            }
            catch (Exception ee)
            {

            }

            //MessageBox.Show(cname + ":" + opr + ":" + data);
           

            if(cname.Equals("") || opr.Equals("") || data.Equals(""))
                MessageBox.Show("All Fields are Mandatory!");
            else
            {

                String cdata = "";
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                    cdata = " where ";
                else
                    if (radioButton1.Checked == true)
                        cdata = " and ";
                    else
                        cdata = " or ";
                cdata=cdata + cname + opr + data;

                if (radioButton1.Checked == true || radioButton2.Checked == true)
                {
                    String cond = "";
                    if (radioButton1.Checked == true)
                        cond = " and ";
                    else
                        cond = " or ";

                    int wherepos = textBox5.Text.IndexOf("where");
                    if (wherepos >= 0)
                    {
                        textBox5.Text = textBox5.Text + cdata;
                    }
                    else
                    {
                        MessageBox.Show("Missing 'Where'! 'and,or' can be used only when there is a pre-existing condition");
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                    }

                }
                else
                {
                    int wherepos = textBox5.Text.IndexOf("where");
                    if (wherepos >= 0)
                    {
                        textBox5.Text = textBox5.Text.Substring(1, textBox5.Text.IndexOf("where") + 6);
                        textBox5.Text = textBox5.Text + cdata;
                    }
                    else
                        textBox5.Text = textBox5.Text + cdata;
                }

                
            }
            con2.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            String sqlstmt = textBox5.Text.Trim();
            String wd = "";
            try
            {
                wd = sqlstmt.Substring(0, sqlstmt.IndexOf(" ")).ToLower();
            }
            catch (Exception ee) { }
            try
            {

                //if (wd.Equals("select"))
                {
                    if (con1.State == ConnectionState.Open)
                        con1.Close();
                    con1.Open();
                    //MessageBox.Show("done2");
                    SqlCommand cmd = new SqlCommand("select * from oraqryrank where qry like('" + textBox5.Text + "%') order by rankid desc ", con1);
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                    listBox1.Items.Clear();

                    while (dr.Read())
                    {
                        listBox1.Items.Add(dr.GetValue(1).ToString());
                    }
                    dr.Close();
                    // MessageBox.Show("done3");
                    con1.Close();
                }
            }
            catch (Exception eee) { con1.Close(); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = listBox1.Text;
            MessageBox.Show("Replace ? mark with ' for Strings else remove ? mark");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
