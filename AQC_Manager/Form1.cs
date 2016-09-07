using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AQC_Manager
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            employeesList nx = new employeesList();
            

            nx.Show();
            nx.MdiParent = this;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            viewEmployee nx = new viewEmployee();


            nx.Show();
            nx.MdiParent = this;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            newEmployee nx = new newEmployee();


            nx.Show();
            nx.MdiParent = this;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            filesViewer nx = new filesViewer();

           
            nx.Show();
            nx.MdiParent = this;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            modifyEmployee nx = new modifyEmployee();
            nx.Show();
            nx.MdiParent = this;
        }





    }
}
