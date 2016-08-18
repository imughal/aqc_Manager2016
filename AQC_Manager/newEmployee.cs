using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace AQC_Manager
{
    public partial class newEmployee : Form
    {
        public newEmployee()
        {
            InitializeComponent();
        }
        public string fileName;
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = database.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            string SQL;
            long FileSize;
            byte[] rawData;
            FileStream fs;

            try
            {
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                FileSize = fs.Length;

                rawData = new byte[FileSize];
                fs.Read(rawData, 0, (int)FileSize);
                fs.Close();

                conn.Open();

                SQL = "INSERT INTO employee_pic (employee_id, pic) VALUES (" + FileSize + ", '" + rawData + "')";

                cmd.Connection = conn;
                cmd.CommandText = SQL;


                cmd.ExecuteNonQuery();

                MessageBox.Show("File Inserted into database successfully!",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
        private void browseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                
                empPicture.Image = new Bitmap(open.FileName);
                empPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                MessageBox.Show(open.FileName);
                fileName = open.FileName;

                // image file path
                //textBox1.Text = open.FileName;
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {

            MySqlDataReader myData;
            MySqlConnection conn = database.getConnection();
            MySqlCommand cmd = new MySqlCommand();

            string SQL;
            UInt32 FileSize;
            byte[] rawData;
            FileStream fs;



            SQL = "SELECT employee_id, pic FROM employee_pic";

            try
            {
                conn.Open();

                cmd.Connection = conn;
                cmd.CommandText = SQL;

                myData = cmd.ExecuteReader();

                if (!myData.HasRows)
                    throw new Exception("There are no BLOBs to save");

                myData.Read();

                FileSize = myData.GetUInt32(myData.GetOrdinal("employee_id"));
                rawData = new byte[FileSize];

                myData.GetBytes(myData.GetOrdinal("pic"), 0, rawData, 0, (int)FileSize);

                fs = new FileStream(@"D:\newfile.jpg", FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(rawData, 0, (int)FileSize);
                fs.Close();

                MessageBox.Show("File successfully written to disk!",
                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                myData.Close();
                conn.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
