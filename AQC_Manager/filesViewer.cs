using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace AQC_Manager
{
    public partial class filesViewer : Form
    {
        public filesViewer()
        {
            InitializeComponent();
        }

        private void filesViewer_Load(object sender, EventArgs e)
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
                            comboBox1.Items.Add(Name + "("+employee_id+")");
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listFiles.Items.Clear();
            using (MySqlConnection con = database.getConnection())
            {
                String employeeID = comboBox1.Text.Split('(', ')')[1];
                con.Open();
                String query = "SELECT fileName FROM documents WHERE employee_id = '"+employeeID+"';";
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
                    if (imgg == null) { fileViewBox.Image = AQC_Manager.Properties.Resources._1432580807_free_17; }
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
    }
}
