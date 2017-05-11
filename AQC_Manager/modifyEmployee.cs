using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AQC_Manager
{
    public partial class modifyEmployee : Form
    {
        public modifyEmployee()
        {
            InitializeComponent();
        }

        public static String AQC_ID = "";
        public modifyEmployee(string emplo)
        {
            InitializeComponent();
            AQC_ID = emplo;
            loadingDATA();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
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


            //if (isEm())
            //{
                //Databases Inserting

            String sql = "UPDATE `aqc_manager`.`employees` SET  `name`= @empName, `fathername` = @empFather, `nationality` = @nation, `religion` = @relg, `maritial` = @maritial, `sex` = @sex, `dateOfBirth` = @DOB, `mobile` = @mble, `emergency` = @ICE, `homeTel` = @home, `passportNumber` = @passNum, `passportIssue` = @passIssue, `passportExpiry` = @passExpire, `iDnumber` = @IDNum, `iDCardNumber` = @IDCardNum, `iDExpiry` = @IDExpire, `visaOccupation` = @visaOccu, `visaNumber` = @vissaNum, `visaIssue` = @visaIss, `visaExpiry`=@visaExiry, `damanNumber`= @damanNum, `policyNumber`= @policyNum, `damanIssue`=@damanIss, `damanExpiry`=@damanExpire, `personCode`=@personC, `laborCardNumber`=@laborCardNum, `laborIssue`=@laborIss, `laborExpiry`=@laborExpire, `wpsBank`=@wpsBankk, `wpsBranch`=@wpsBranchh, `wpsAccount`=@wpsAcc, `wpsIBAN`=@wpsIbann, `wpsCard`=@wpsCardd, `wpsIssueDate`=@wpsIssue,`wpsExpiryDate`=@wpsExpire WHERE `id` ='"+id+"' ;";
                //--------------------------------------------------------------------------------------------------------                                                                                                                ---------------------@empID, @empName, @empFather, @nation, @relg, @maritial, @sex, @DOB, @mble, @ICE, @home, @passNum, @passIssue, @passExpire, @IDNum, @IDCardNum, @IDExpire, @visaOccu, @vissaNum, @visaIss, @visaExiry,                                                                                                                                                                                        @damanNum, @policyNum, @damanIss, @damanExpire, @personC, @laborCardNum, @laborIss, @laborExpire, @wpsBankk, @wpsBranchh, @wpsAcc, @wpsIbann, @wpsCardd, @wpsIssue, @wpsExpire

                MySqlConnection connP = database.getConnection();
                MySqlCommand cmdP = new MySqlCommand(sql, connP);
                MySqlDataReader RDP;

                try
                {
                    connP.Open();


                    //Personal Info
                    //cmdP.Parameters.Add(new MySqlParameter("@empID", empID));
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
                if (imageModify)
                {
                    Image ss = System.Drawing.Image.FromFile(fileName);
                    Bitmap bi = ResizeImage(ss, 150, 175);

                    MemoryStream ms = new MemoryStream();
                    bi.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);


                    String sqlQ = "UPDATE employee_pic SET pic = @IMG WHERE employee_id = @empID;";
                    MySqlConnection conn = database.getConnection();
                    MySqlCommand cmd = new MySqlCommand(sqlQ, conn);
                    MySqlDataReader RD;

                    try
                    {
                        conn.Open();
                        cmd.Parameters.Add(new MySqlParameter("@empID", empId.Text));
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

                MessageBox.Show("Employee Edited Successfully.");
                this.Close();
                viewEmployee Ve = new viewEmployee(empId.Text);
                Ve.Show();
                Ve.MdiParent = this.MdiParent;
           // }
        }
        private void loadPic()
        {
            String sqlQ = "select * FROM employee_pic WHERE employee_id = @empID";
            //String sqlQ = "select * FROM employee_pic";
            MySqlConnection conn = database.getConnection();
            MySqlCommand cmd = new MySqlCommand(sqlQ, conn);
            MySqlDataReader RD;

            try
            {
                conn.Open();
                cmd.Parameters.Add(new MySqlParameter("@empID", empId.Text));
                //MessageBox.Show(empId.Text);
                RD = cmd.ExecuteReader();


                while (RD.Read())
                {
                    byte[] imgg = (byte[])(RD["pic"]);
                    if (imgg == null) { empPicture.Image = null; }
                    else
                    {
                        MemoryStream MS = new MemoryStream(imgg);
                        empPicture.Image = System.Drawing.Image.FromStream(MS);
                        empPicture.SizeMode = PictureBoxSizeMode.StretchImage;


                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool imageModify = false;
        private void browseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Select Picture";
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                
                empPicture.Image = new Bitmap(open.FileName);
                empPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                MessageBox.Show(open.FileName);
                fileName = open.FileName.ToString();
                imageModify = true;
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
            //empId.Text = "";
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
        private string id = "";
        private void loadingDATA(){

            using (MySqlConnection con = database.getConnection())
            {
                con.Open();
                String query = "SELECT * FROM employees WHERE employee_id='"+AQC_ID+"';";
                using (MySqlCommand command = new MySqlCommand(query, con))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        //Iterate through the rows and add it to the combobox's items
                        while (reader.Read())
                        {
//employee_id`, `name`, `fathername`, `nationality`, `religion`, `maritial`, `sex`, `dateOfBirth`, `mobile`, `emergency`, `homeTel`,  ,
                            //Personal Information
                            id = reader.GetString("id");
                            empId.Text = reader.GetString("employee_id");
                            empName.Text = reader.GetString("name");
                            empFather.Text = reader.GetString("fathername");
                            empReligion.Text = reader.GetString("religion");
                            empDOB.Value = reader.GetDateTime("dateOfBirth");
                            EmpShadi.Text = reader.GetString("maritial");
                            empSex.Text = reader.GetString("sex");
                            EmpMobile.Text =reader.GetString("mobile");
                            empCountry.Text = reader.GetString("nationality");
                            empICE.Text = reader.GetString("emergency");
                            empHomeNumber.Text = reader.GetString("homeTel");
                            loadPic();
                            //empPicture.Image = null;reader.GetString("employee_id");

                           //`passportNumber`, `passportIssue`, `passportExpiry`,     
                            //Passport Information
                            passportNumber.Text = reader.GetString("passportNumber");
                            passportIssueDate.Value = reader.GetDateTime("passportIssue");
                            passportExpiryDate.Value = reader.GetDateTime("passportExpiry");

                            //`iDnumber`, `iDCardNumber`, `iDExpiry`
                            //ID Card Information
                            IDCardNumber.Text = reader.GetString("iDCardNumber");
                            IDNumber.Text = reader.GetString("iDnumber");
                            IDExpiryDate.Value = reader.GetDateTime("iDExpiry");

                            // `visaOccupation`, `visaNumber`, `visaIssue`, `visaExpiry`    
                            //Visa Information
                            visaOccupation.Text = reader.GetString("visaOccupation");
                            visaNumber.Text = reader.GetString("visaNumber");
                            visaIssueDate.Value = reader.GetDateTime("visaIssue");
                            visaExpiryDate.Value = reader.GetDateTime("visaExpiry");

                            // `damanNumber`, `policyNumber`, `damanIssue`, `damanExpiry`,
                            //Daman Information
                            damanNumber.Text = reader.GetString("damanNumber");
                            policyNumber.Text = reader.GetString("policyNumber");
                            damanIssueDate.Value = reader.GetDateTime("damanIssue");
                            damanExpiryDate.Value = reader.GetDateTime("damanExpiry");

                            //`personCode`, `laborCardNumber`, `laborIssue`, `laborExpiry`,
                            //Labor Card information
                            personCode.Text = reader.GetString("personCode");
                            laborCardNumber.Text = reader.GetString("laborCardNumber");
                            laborExpiryDate.Value = reader.GetDateTime("laborExpiry");
                            laborIssueDate.Value = reader.GetDateTime("laborIssue");

                        //,  `wpsBank`, `wpsBranch`, `wpsAccount`, `wpsIBAN`, `wpsCard`, `wpsIssueDate`,`wpsExpiryDate`
                            //WPS Information
                            wpsBank.Text = reader.GetString("wpsBank");
                            wpsBranch.Text = reader.GetString("wpsBranch");
                            wpsAccountNumber.Text = reader.GetString("wpsAccount");
                            wpsIBAN.Text = reader.GetString("wpsIBAN");
                            wpsCardNumber.Text = reader.GetString("wpsCard");
                            wpsIssueDate.Value = reader.GetDateTime("wpsIssueDate");
                            wpsExpiryDate.Value = reader.GetDateTime("wpsExpiryDate");
                                        
                        }
                    }
                }
            }

        }
        public static void modifyEmp(string EmpModify)
        {
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(empName.Text);
        }

        private void newEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            loadingDATA();
        }
    }
}
