using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace AQC_Manager
{
    public partial class viewEmployee : Form
    {
        public static String AQC_ID = "";
        public viewEmployee(string emplo)
        {
            InitializeComponent();
            AQC_ID = emplo;
        }
        public viewEmployee()
        {
            InitializeComponent();
        }
        //private BindingSource biS = new BindingSource();
        private void viewEmployee_Load(object sender, EventArgs e)
        {
            MySqlConnection con = database.getConnection();

            try
            {
                con.Open();

            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }

            DataSet DS = new DataSet();
            MySqlDataAdapter myDA = new MySqlDataAdapter("select * from employees", con);
            myDA.Fill(DS);
            BindingSource biS = new BindingSource();
            biS.DataSource = DS.Tables[0];
            mysqlBI.BindingSource = biS;

            //nameLbl.DataBindings.Add("Text", biS, "name");

            //Personal Information
            empId.DataBindings.Add("Text", biS, "employee_id");
            empName.DataBindings.Add("Text", biS, "name");
            empFather.DataBindings.Add("Text", biS, "fathername");
            empReligion.DataBindings.Add("Text", biS, "religion");
            //empDOB.DataBindings.Add("Text", biS, "dateOfBirth");
            empDOB.DataBindings.Add("Text", biS, "dateOfBirth", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");
            EmpShadi.DataBindings.Add("Text", biS, "maritial");
            empSex.DataBindings.Add("Text", biS, "sex");
            EmpMobile.DataBindings.Add("Text", biS, "mobile");
            empCountry.DataBindings.Add("Text", biS, "nationality");
            empICE.DataBindings.Add("Text", biS, "emergency");
            empHomeNumber.DataBindings.Add("Text", biS, "hometel");
            //empPicture.Image = null;
            //loadPic();

            //Passport Information
            passportNumber.DataBindings.Add("Text", biS, "passportNumber");
            passportIssueDate.DataBindings.Add("Text", biS, "passportIssue", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");
            passportExpiryDate.DataBindings.Add("Text", biS, "passportExpiry", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");

            //ID Card Information
            IDCardNumber.DataBindings.Add("Text", biS, "iDCardNumber");
            IDNumber.DataBindings.Add("Text", biS, "iDnumber");
            IDExpiryDate.DataBindings.Add("Text", biS, "iDExpiry", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");

            //Visa Information
            visaOccupation.DataBindings.Add("Text", biS, "visaOccupation");
            visaNumber.DataBindings.Add("Text", biS, "visaNumber");
            visaIssueDate.DataBindings.Add("Text", biS, "visaIssue", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");
            visaExpiryDate.DataBindings.Add("Text", biS, "visaExpiry", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");

            //Daman Information
            damanNumber.DataBindings.Add("Text", biS, "damanNumber");
            policyNumber.DataBindings.Add("Text", biS, "policyNumber");
            damanIssueDate.DataBindings.Add("Text", biS, "damanIssue", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");
            damanExpiryDate.DataBindings.Add("Text", biS, "damanExpiry", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");

            //Labor Card information
            personCode.DataBindings.Add("Text", biS, "personCode");
            laborCardNumber.DataBindings.Add("Text", biS, "laborCardNumber");
            laborExpiryDate.DataBindings.Add("Text", biS, "laborIssue", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");
            laborIssueDate.DataBindings.Add("Text", biS, "laborExpiry", true, DataSourceUpdateMode.OnValidation, "", "dd-MMM-yyyy");

            //WPS Information
            wpsBank.DataBindings.Add("Text", biS, "wpsBank");
            wpsBranch.DataBindings.Add("Text", biS, "wpsBranch");
            wpsAccountNumber.DataBindings.Add("Text", biS, "wpsAccount");
            wpsIBAN.DataBindings.Add("Text", biS, "wpsIBAN");
            wpsCardNumber.DataBindings.Add("Text", biS, "wpsCard");
            wpsIssueDate.DataBindings.Add("Text", biS, "wpsIssueDate", true, DataSourceUpdateMode.OnValidation, "", "MMM-yyyy");
            wpsExpiryDate.DataBindings.Add("Text", biS, "wpsExpiryDate", true, DataSourceUpdateMode.OnValidation, "", "MMM-yyyy");



            int index = biS.Find("employee_id", AQC_ID);

            if (index >= 0)
            {
                biS.Position = index;
            }
            try
            {
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadPic()
        {
            empPicture.Image = AQC_Manager.Properties.Resources._1432580807_free_17;
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
                    if (imgg == null) {empPicture.Image = AQC_Manager.Properties.Resources._1432580807_free_17; }
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

        private void empId_TextChanged(object sender, EventArgs e)
        {
            loadPic();
        }

        private void empId_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    int index = biS.Find("employee_id", AQC_ID);

            //    if (index >= 0)
            //    {
            //        biS.Position = index;
            //    }
            //}
        }
    }
}
