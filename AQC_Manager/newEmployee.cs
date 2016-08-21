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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

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
           // byte[] im = null;
           // FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
           // BinaryReader br = new BinaryReader(fs);
           // im = br.ReadBytes((int)fs.Length);
            Image ss = System.Drawing.Image.FromFile(fileName);
            Bitmap bi = ResizeImage(ss, 150, 175);

            MemoryStream ms = new MemoryStream();
            bi.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);


            String sqlQ = "insert into employee_pic (employee_id, pic) values ('imran',@IMG);";
            MySqlConnection conn = database.getConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQ,conn);
            MySqlDataReader RD;

            try
            {
                conn.Open();
                cmd.Parameters.Add(new MySqlParameter("@IMG", ms.ToArray()));
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
    }
}
