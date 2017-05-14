using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            if (Application.OpenForms.OfType<employeesList>().Count() == 1)
            {
                Application.OpenForms.OfType<employeesList>().First().Focus();
            }
            else
            {
                employeesList nx = new employeesList();
                nx.Show();
                nx.MdiParent = this;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<viewEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<viewEmployee>().First().Focus();
            }
            else
            {
                viewEmployee nx = new viewEmployee();
                nx.Show();
                nx.MdiParent = this;

            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<newEmployee>().Count() == 1)
            {
                Application.OpenForms.OfType<newEmployee>().First().Focus();
            }
            else
            {
                newEmployee nx = new newEmployee();
                nx.Show();
                nx.MdiParent = this;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<filesViewer>().Count() == 1)
            {
                Application.OpenForms.OfType<filesViewer>().First().Focus();
            }
            else
            {
                filesViewer nx = new filesViewer();
                nx.Show();
                nx.MdiParent = this;
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<addFiles>().Count() == 1)
            {
                Application.OpenForms.OfType<addFiles>().First().Focus();
            }
            else
            {
                addFiles aF = new addFiles();
                aF.Show();
                aF.MdiParent = this;
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            string file = "D:\\backup.sql";
            using (MySqlConnection conn = database.getConnection())
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        mb.ExportToFile(file);
                        conn.Close();
                    }
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<phoneDirectory>().Count() == 1)
            {
                Application.OpenForms.OfType<phoneDirectory>().First().Focus();
            }
            else
            {
                phoneDirectory pD = new phoneDirectory();
                pD.Show();
                pD.MdiParent = this;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<laborExpiries>().Count() == 1)
            {
                Application.OpenForms.OfType<laborExpiries>().First().Focus();
            }
            else
            {
                laborExpiries lE = new laborExpiries();
                lE.Show();
                lE.MdiParent = this;
            }
        }
    }
}
