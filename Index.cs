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
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

          
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Register f = new Register();
          f.ShowDialog();
          
            
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Index_Load(object sender, EventArgs e)
        {

        }
                              
    }
}
