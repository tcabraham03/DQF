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
    public partial class UserAdmn : Form
    {
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=DQF;User ID=sa;Password=Abraham");

        public UserAdmn()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                button1.Text = "Save";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Text = DateTime.Today.ToShortDateString();
                textBox1.Text = "";
                clear_all();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                button1.Text = "Update";
                textBox1.Enabled = false;                
                textBox1.Text = "";
                clear_all();
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                button1.Text = "Delete";
                textBox1.Enabled = false;
                textBox1.Text = "";
                clear_all();
            }

        }

        private void UserAdmn_Load(object sender, EventArgs e)
        {
            textBox4.Text = DateTime.Today.ToShortDateString();
            show_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.SetError(textBox1, "");
                errorProvider1.SetError(textBox2, "");
                errorProvider1.SetError(textBox3, "");

                if (!textBox1.Text.Trim().Equals(""))
                {
                    
                    if (!textBox2.Text.Trim().Equals(""))
                    {
                        
                        if (!textBox3.Text.Trim().Equals(""))
                        {
                            

                            SqlCommand cmd = null;
                            con.Open();
                            if (radioButton1.Checked == true)
                            {
                                cmd = new SqlCommand("insert into users values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("User Created Successfully!");
                            }
                            if (radioButton2.Checked == true)
                            {
                                cmd = new SqlCommand("update users set usname='" + textBox2.Text + "',pswd='" + textBox3.Text + "' where usid='" + textBox1.Text + "'", con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("User Info Updated Successfully!");
                            }
                            if (radioButton3.Checked == true)
                            {
                                cmd = new SqlCommand("delete from users where usid='" + textBox1.Text + "'", con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("User Info Deleted Successfully!");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(textBox3, "Password is mandatory!");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(textBox2, "User Name is mandatory!");
                    }
                }
                else 
                {
                    errorProvider1.SetError(textBox1, "User ID is mandatory!");
                }
            }


            catch (Exception ee)
            {
                MessageBox.Show("User with this ID already Exists!" + ee.Message);
            }
            con.Close();
            show_data();
            //clear_all();
        }

        public void show_data()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from users", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ee)
            {

            }


        }

        public void clear_all()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int cr = 0;
                cr=dataGridView1.CurrentCell.RowIndex;
                textBox1.Text = dataGridView1[0, cr].Value.ToString();
                textBox2.Text = dataGridView1[1, cr].Value.ToString();
                textBox3.Text = dataGridView1[2, cr].Value.ToString();
                textBox4.Text = dataGridView1[3, cr].Value.ToString();
            }
            catch (Exception ee)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
