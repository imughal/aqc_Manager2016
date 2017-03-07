using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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
                pictureBox1.Image = new Bitmap(open.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                //fileName.Text = employee.Text.Split('(', ')')[1];
            } 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (employee.Text == null || employee.Text == "")
            {
                return;
            }
            String filelocation = fileLocation.Text;
            String filename = fileName.Text;
            String employeeID = employee.Text.Split('(', ')')[1];
            String Description = fileDescription.Text;

            Image ss = System.Drawing.Image.FromFile(filelocation);
            Bitmap bi = null;
            if (ss.Height > ss.Width)
            {
                bi = ResizeImage(ss, 1588, 2244);
            }
            else if (ss.Width > ss.Height)
            {
                bi = ResizeImage(ss, 2244, 1588);
            }

            MemoryStream ms = new MemoryStream();
            bi.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //pictureBox1.Image = bi;
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            byte[] byteArray = ms.ToArray();
            
            String sqlQ = "insert into documents (employee_id, fileName, Description,file) values (@empID,@fileName,@des,@IMG);";
            MySqlConnection conn = database.getConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQ, conn);
            MySqlDataReader RD;

            try
            {
                conn.Open();
                cmd.Parameters.Add(new MySqlParameter("@empID", employeeID));
                cmd.Parameters.Add(new MySqlParameter("@fileName", filename));
                cmd.Parameters.Add(new MySqlParameter("@des",Description));
                cmd.Parameters.Add("@IMG",MySqlDbType.Blob).Value = byteArray;
                //cmd.Parameters.Add("@image", MySqlDbType.Blob).Value = data;
                RD = cmd.ExecuteReader();
                MessageBox.Show("Saved");

                //while (RD.Read())
                //{

                //}
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
