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
    public partial class Register : Form
    {
        SqlConnection con = null;

        public Register()
        {
            InitializeComponent();
            con = new SqlConnection(DB.GetConnectionStringByName("DBName"));
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                //validation Initialization
                errorProvider1.SetError(UIDtextBox, "");
                errorProvider1.SetError(UnametextBox, "");
                errorProvider1.SetError(PswdtextBox, "");

                //Initializing variables
                String tcid, tcname, tdor, tpwd;
                tcid = UIDtextBox.Text;
                tcname = UnametextBox.Text.Trim();
                tdor = DatetextBox4.Text;
                tpwd = PswdtextBox.Text;

                //validation + insert into 'USERS' table
                if (!tcid.Equals(""))
                {
                    if (!tpwd.Equals(""))
                    {
                        if (PswdtextBox.TextLength >= 8)
                        {
                            if (!tcname.Equals(""))
                            {
                                int fg = checkname(UnametextBox.Text);
                                if (fg == 0)
                                {
                                    con.Open();
                                    SqlCommand cmd = null;
                                    cmd = new SqlCommand("insert into users values('" + tcid + "','" + tpwd + "','" + tcname + "','" + tdor + "')", con);
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Registration Done! Please Login");
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Check Name");
                                }
                            }
                            else
                            {
                                errorProvider1.SetError(UnametextBox, "User Name is Mandatory!");
                            }
                        }
                        else
                        {
                            errorProvider1.SetError(PswdtextBox, "Password should be atleast 8 characters");
                        }
                    }
                    else
                    {
                        errorProvider1.SetError(PswdtextBox, "Password is Mandatory!");
                    }
                }
                else
                {
                    errorProvider1.SetError(UIDtextBox, "ID is Mandatory!");
                }

            
            }
            catch (Exception ee)
            {
                string a = ee.Message;
                MessageBox.Show("This user id already exists");
            }
            con.Close();

        }

        //validation for User Name
        public int checkname(String name)
        {
            int i = 0;
            int fg = 0;

            for (i = 0; i < name.Length; i++)
            {
                int ch = name[i];
                if ((ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122) || ch == 32)
                { }
                else
                    return 1;
            }
            return fg;

        }


        //Button Controls
        private void CClosebutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            DatetextBox4.Text = DateTime.Today.ToShortDateString();
        }


    }
}

       

    