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
            byte[] im = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            im = br.ReadBytes((int)fs.Length);


            String sqlQ = "insert into employee_pic (employee_id, pic) values ('imran',@IMG);";
            MySqlConnection conn = database.getConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQ,conn);
            MySqlDataReader RD;

            try
            {
                conn.Open();
                cmd.Parameters.Add(new MySqlParameter("@IMG", im));
                RD = cmd.ExecuteReader();
                MessageBox.Show("Saved");

                while (RD.Read())
                {

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                fileName = open.FileName.ToString();

                // image file path
                //textBox1.Text = open.FileName;
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sqlQ = "select * FROM employee_pic WHERE id = 1";
            MySqlConnection conn = database.getConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQ, conn);
            MySqlDataReader RD;

            try
            {
                conn.Open();
                RD = cmd.ExecuteReader();
                MessageBox.Show("Saved");

                while (RD.Read())
                {

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
