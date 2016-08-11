using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AQC_Manager
{
    public partial class viewEmployee : Form
    {
        public viewEmployee()
        {
            InitializeComponent();
        }

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

            nameLbl.DataBindings.Add("Text", biS, "name");
            


            try
            {
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
