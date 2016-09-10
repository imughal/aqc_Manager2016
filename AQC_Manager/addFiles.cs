using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AQC_Manager
{
    public partial class addFiles : Form
    {
        public addFiles()
        {
            InitializeComponent();
        }

        private void addFiles_Load(object sender, EventArgs e)
        {
            loadEmployees();
        }
        private void loadEmployees()
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
                            employee.Items.Add(Name + "(" + employee_id + ")");
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select File";
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box

                //empPicture.Image = new Bitmap(open.FileName);
                //empPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                //MessageBox.Show(open.FileName);
                //fileName = open.FileName.ToString();
                //imageModify = true;
                // image file path
                //textBox1.Text = open.FileName;
                fileLocation.Text = open.FileName;
                fileName.Text = employee.Text.Split('(', ')')[1];
            } 
        }
    }
}
