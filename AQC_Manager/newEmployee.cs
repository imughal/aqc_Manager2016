using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
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
            //Personal Information
            string empID = empId.Text;
            string empl = empName.Text;
            string empFatherX = empFather.Text;
            string empReligionX = empReligion.Text;
            DateTime empDOBx = empDOB.Value;
            string EmpShadix = EmpShadi.Text;
            string empSexX = empSex.Text;
            string EmpMobileX = EmpMobile.Text;
            string empCountryX = empCountry.Text;
            string empICEX = empICE.Text;
            string empHomeNumberX = empHomeNumber.Text;
            //string empPicture.Image;

            //Passport Information
            string passportNumberX = passportNumber.Text;
            DateTime passportIssueDateX = passportIssueDate.Value;
            DateTime passportExpiryDateX = passportExpiryDate.Value;

            //ID Card Information
            string IDCardNumberX = IDCardNumber.Text;
            string IDNumberX = IDNumber.Text;
            DateTime IDExpiryDateX = IDExpiryDate.Value;

            //Visa Information
            string visaOccupationX = visaOccupation.Text;
            string visaNumberX = visaNumber.Text;
            DateTime visaIssueDateX = visaIssueDate.Value;
            DateTime visaExpiryDateX = visaExpiryDate.Value;

            //Daman Information
            string damanNumberX = damanNumber.Text;
            string policyNumberX = policyNumber.Text;
            DateTime damanIssueDateX = damanIssueDate.Value;
            DateTime damanExpiryDateX = damanExpiryDate.Value;

            //Labor Card information
            string personCodeX = personCode.Text;
            string laborCardNumberX = laborCardNumber.Text;
            DateTime laborExpiryDateX = laborExpiryDate.Value;
            DateTime laborIssueDateX = laborIssueDate.Value;

            //WPS Information
            string wpsBankX = wpsBank.Text;
            string wpsBranchX = wpsBranch.Text;
            string wpsAccountNumberX = wpsAccountNumber.Text;
            string wpsIBANX = wpsIBAN.Text;
            string wpsCardNumberX = wpsCardNumber.Text;
            DateTime wpsIssueDateX = wpsIssueDate.Value;
            DateTime wpsExpiryDateX = wpsExpiryDate.Value;


            if (isEm())
            {
                //Databases Inserting

                String sql = "INSERT INTO `aqc_manager`.`employees` (`employee_id`, `name`, `fathername`, `nationality`, `religion`, `maritial`, `sex`, `dateOfBirth`, `mobile`, `emergency`, `homeTel`, `passportNumber`, `passportIssue`, `passportExpiry`, `iDnumber`, `iDCardNumber`, `iDExpiry`, `visaOccupation`, `visaNumber`, `visaIssue`, `visaExpiry`, `damanNumber`, `policyNumber`, `damanIssue`, `damanExpiry`, `personCode`, `laborCardNumber`, `laborIssue`, `laborExpiry`, `wpsBank`, `wpsBranch`, `wpsAccount`, `wpsIBAN`, `wpsCard`, `wpsIssueDate`,`wpsExpiryDate`) VALUES (@empID, @empName, @empFather, @nation, @relg, @maritial, @sex, @DOB, @mble, @ICE, @home, @passNum, @passIssue, @passExpire, @IDNum, @IDCardNum, @IDExpire, @visaOccu, @vissaNum, @visaIss, @visaExiry, @damanNum, @policyNum, @damanIss, @damanExpire, @personC, @laborCardNum, @laborIss, @laborExpire, @wpsBankk, @wpsBranchh, @wpsAcc, @wpsIbann, @wpsCardd, @wpsIssue, @wpsExpire);";
                //@empID, @empName, @empFather, @nation, @relg, @maritial, @sex, @DOB, @mble, @ICE, @home, @passNum, @passIssue, @passExpire, @IDNum, @IDCardNum, @IDExpire, @visaOccu, @vissaNum, @visaIss, @visaExiry, @damanNum, @policyNum, @damanIss, @damanExpire, @personC, @laborCardNum, @laborIss, @laborExpire, @wpsBankk, @wpsBranchh, @wpsAcc, @wpsIbann, @wpsCardd, @wpsIssue, @wpsExpire

                MySqlConnection connP = database.getConnection();
                MySqlCommand cmdP = new MySqlCommand(sql, connP);
                MySqlDataReader RDP;

                try
                {
                    connP.Open();


                    //Personal Info
                    cmdP.Parameters.Add(new MySqlParameter("@empID", empID));
                    cmdP.Parameters.Add(new MySqlParameter("@empName", empl));
                    cmdP.Parameters.Add(new MySqlParameter("@empFather", empFatherX));
                    cmdP.Parameters.Add(new MySqlParameter("@nation", empCountryX));
                    cmdP.Parameters.Add(new MySqlParameter("@relg", empReligionX));
                    cmdP.Parameters.Add(new MySqlParameter("@maritial", EmpShadix));
                    cmdP.Parameters.Add(new MySqlParameter("@sex", empSexX));
                    cmdP.Parameters.Add(new MySqlParameter("@DOB", empDOBx));
                    cmdP.Parameters.Add(new MySqlParameter("@mble", EmpMobileX));
                    cmdP.Parameters.Add(new MySqlParameter("@ICE", empICEX));
                    cmdP.Parameters.Add(new MySqlParameter("@home", empHomeNumberX));

                    //Passport Info
                    cmdP.Parameters.Add(new MySqlParameter("@passNum", passportNumberX));
                    cmdP.Parameters.Add(new MySqlParameter("@passIssue", passportIssueDateX));
                    cmdP.Parameters.Add(new MySqlParameter("@passExpire", passportExpiryDateX));

                    //ID Info
                    cmdP.Parameters.Add(new MySqlParameter("@IDNum", IDNumberX));
                    cmdP.Parameters.Add(new MySqlParameter("@IDCardNum", IDCardNumberX));
                    cmdP.Parameters.Add(new MySqlParameter("@IDExpire", IDExpiryDateX));

                    //Visa Info
                    cmdP.Parameters.Add(new MySqlParameter("@visaOccu", visaOccupationX));
                    cmdP.Parameters.Add(new MySqlParameter("@vissaNum", visaNumberX));
                    cmdP.Parameters.Add(new MySqlParameter("@visaIss", visaIssueDateX));
                    cmdP.Parameters.Add(new MySqlParameter("@visaExiry", visaExpiryDateX));

                    //Daman Info
                    cmdP.Parameters.Add(new MySqlParameter("@damanNum", damanNumberX));
                    cmdP.Parameters.Add(new MySqlParameter("@policyNum", policyNumberX));
                    cmdP.Parameters.Add(new MySqlParameter("@damanIss", damanIssueDateX));
                    cmdP.Parameters.Add(new MySqlParameter("@damanExpire", damanExpiryDateX));

                    //Labor Info
                    cmdP.Parameters.Add(new MySqlParameter("@personC", personCodeX));
                    cmdP.Parameters.Add(new MySqlParameter("@laborCardNum", laborCardNumberX));
                    cmdP.Parameters.Add(new MySqlParameter("@laborIss", laborIssueDateX));
                    cmdP.Parameters.Add(new MySqlParameter("@laborExpire", laborExpiryDateX));

                    //wps Info
                    cmdP.Parameters.Add(new MySqlParameter("@wpsBankk", wpsBankX));
                    cmdP.Parameters.Add(new MySqlParameter("@wpsBranchh", wpsBranchX));
                    cmdP.Parameters.Add(new MySqlParameter("@wpsAcc", wpsAccountNumberX));
                    cmdP.Parameters.Add(new MySqlParameter("@wpsIbann", wpsIBANX));
                    cmdP.Parameters.Add(new MySqlParameter("@wpsCardd", wpsCardNumberX));
                    cmdP.Parameters.Add(new MySqlParameter("@wpsIssue", wpsIssueDateX));
                    cmdP.Parameters.Add(new MySqlParameter("@wpsExpire", wpsExpiryDateX));
                    //cmdP.Parameters.Add(new MySqlParameter("@IMG", ""));









                    RDP = cmdP.ExecuteReader();











                    connP.Close();
                }
                catch (Exception EX)
                {
                    MessageBox.Show(EX.ToString());
                }
                ////////////
                //Saving Images
                ///////////


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
                MySqlCommand cmd = new MySqlCommand(sqlQ, conn);
                MySqlDataReader RD;

                try
                {
                    conn.Open();
                    cmd.Parameters.Add(new MySqlParameter("@IMG", ms.ToArray()));
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
        private bool isEm()
        {
            bool rVal = false;
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {
                        rVal = true;
                        MessageBox.Show("Empty");
                    }
                }
            }
            return rVal;
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

        private void button2_Click(object sender, EventArgs e)
        {
            //Reseting All Fields

            //Personal Information
            empId.Text = "";
            empName.Text = "";
            empFather.Text = "";
            empReligion.Text = "";
            empDOB.Value = DateTime.Today;
            EmpShadi.Text = "";
            empSex.Text = "";
            EmpMobile.Text = "";
            empCountry.Text = "";
            empICE.Text = "";
            empHomeNumber.Text = "";
            empPicture.Image = null;

            //Passport Information
            passportNumber.Text = "";
            passportIssueDate.Value = DateTime.Today;
            passportExpiryDate.Value = DateTime.Today;

            //ID Card Information
            IDCardNumber.Text = "";
            IDNumber.Text = "";
            IDExpiryDate.Value = DateTime.Today;

            //Visa Information
            visaOccupation.Text = "";
            visaNumber.Text = "";
            visaIssueDate.Value = DateTime.Today;
            visaExpiryDate.Value = DateTime.Today;

            //Daman Information
            damanNumber.Text = "";
            policyNumber.Text = "";
            damanIssueDate.Value = DateTime.Today;
            damanExpiryDate.Value = DateTime.Today;

            //Labor Card information
            personCode.Text = "";
            laborCardNumber.Text = "";
            laborExpiryDate.Value = DateTime.Today;
            laborIssueDate.Value = DateTime.Today;

            //WPS Information
            wpsBank.Text = "";
            wpsBranch.Text = "";
            wpsAccountNumber.Text = "";
            wpsIBAN.Text = "";
            wpsCardNumber.Text = "";
            wpsIssueDate.Value = DateTime.Today;
            wpsExpiryDate.Value = DateTime.Today;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(empName.Text);
        }
    }
}
