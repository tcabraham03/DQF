using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DQF_30_01_15
{
    public partial class MenuOptions : Form
    {
        public MenuOptions()
        {
            InitializeComponent();
        }

        private void MenuOptions_Load(object sender, EventArgs e)
        {
            if (DB.lusid.ToLower().Equals("admin"))
                toolStripMenuItem1.Visible = true;
            else
                toolStripMenuItem1.Visible = false;
        }

        private void MenuOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserAdmn f = new UserAdmn();
            f.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CPwd f = new CPwd();
            f.ShowDialog();
        }

        private void defineObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void postDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void preserveColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void mergeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void automatedQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sQLServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostView f = new PostView();
            f.Show();
        }

        private void accessToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void oracleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OraclePostView f = new OraclePostView();
            f.Show();
           
        }

        private void sQLServerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AutoFill f = new AutoFill();
            f.Show();

        }

        private void oracleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OracleAutoFill f = new OracleAutoFill();
            f.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void oracleServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ODefineObj f = new ODefineObj();
            f.Show();
        }

        private void sQLServerToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DefineObj f = new DefineObj();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
               
    }
}
