using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace AQC_Manager
{
    public partial class filesViewer : Form
    {
        public filesViewer()
        {
            InitializeComponent();
            loading();
        }

        public filesViewer(string employee)
        {
            InitializeComponent();
            loading();
            //Combox1.SelectedIndex = Combox1.FindStringExact("test1")
            comboBox1.SelectedIndex = comboBox1.FindStringExact(employee);
        }


        private void filesViewer_Load(object sender, EventArgs e)
        {

        }
        private void loading()
        {
            //var connectionString = "connection string goes here";
            using (MySqlConnection con = database.getConnection())
            {
                con.Open();
                String query = "SELECT employee_id,name FROM employees;";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            String Name = reader.GetString("name");
                            string employee_id = reader.GetString("employee_id");
                            comboBox1.Items.Add(Name + "(" + employee_id + ")");
                            comboBox1.SelectedIndex = 0;
                        }
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadFiles();
            
        }
        private void loadFiles()
        {
            listFiles.Items.Clear();
            using (MySqlConnection con = database.getConnection())
            {
                String employeeID = comboBox1.Text.Split('(', ')')[1];
                con.Open();
                String query = "SELECT fileName FROM documents WHERE employee_id = '" + employeeID + "';";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
                            String Name = reader.GetString("fileName");

                            listFiles.Items.Add(Name);
                        }
                    }
                }
            }
        }

        private void listFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadFile();
        }
        private void loadFile()
        {
            string emp_id = comboBox1.Text.Split('(', ')')[1];
            // = listFiles.SelectedItems[0].ToString();
            string selectedFile = "";
            if (listFiles.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listFiles.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                selectedFile = listFiles.Items[intselectedindex].Text;

                //do something
                //MessageBox.Show(listView1.Items[intselectedindex].Text); 
            } 
           // empPicture.Image = AQC_Manager.Properties.Resources._1432580807_free_17;
            String sqlQ = "select file FROM documents WHERE employee_id = '"+emp_id+"' AND fileName = '"+selectedFile+"'";
            //String sqlQ = "select * FROM employee_pic";
            MySqlConnection conn = database.getConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQ, conn);
            MySqlDataReader RD;

            try
            {
                conn.Open();
                //MessageBox.Show(empId.Text);
                RD = cmd.ExecuteReader();


                while (RD.Read())
                {
                    byte[] imgg = (byte[])(RD["file"]);
                    if (imgg == null) { fileViewBox.Image = AQC_Manager.Properties.Resources.Profile; }
                    else
                    {
                        MemoryStream MS = new MemoryStream(imgg);
                        //fileViewBox.Image = System.Drawing.Image.FromStream(MS);
                        Image bi = System.Drawing.Image.FromStream(MS);
                        fileViewBox.Width = bi.Width;
                        fileViewBox.Height = bi.Height;
                        fileViewBox.Image = bi;

                        //fileViewBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Save Image As";
                // image filters
                save.Filter = "Image Files(*.jpg; *.jpeg)|*.jpg; *.jpeg;";
                string saveFileName = listFiles.SelectedItems[0].Text;
                save.FileName = saveFileName + ".jpg";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string pathFile = save.FileName;
                    try
                    {
                        fileViewBox.Image.Save(@pathFile, ImageFormat.Jpeg);
                        MessageBox.Show("File Saved");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //File Delete Function
            if (comboBox1.SelectedItem != null)
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want Delete ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    DelFile();
                }
            }
        }
        private void DelFile()
        {
            string emp_id = comboBox1.Text.Split('(', ')')[1];
            string selectedFile = "";
            if (listFiles.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listFiles.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                selectedFile = listFiles.Items[intselectedindex].Text;

            }
            String sqlQ = "DELETE from documents WHERE employee_id = '" + emp_id + "' AND fileName = '" + selectedFile + "'";
            MySqlConnection conn = database.getConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQ, conn);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Successfully...");
                fileViewBox.Image = null;
                fileViewBox.InitialImage = null;
                loadFiles();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            addFiles aF = new addFiles(comboBox1.Text);
            aF.Show();

            aF.MdiParent = this.MdiParent;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
