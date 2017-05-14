using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AQC_Manager
{
    public partial class laborExpiries : Form
    {
        public laborExpiries()
        {
            InitializeComponent();
            loadEmployees();
            comboLoad();

        }
        private void loadEmployees()
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
            String sql = "SELECT employee_id AS 'Employee ID', name AS 'Name',passportExpiry as 'Passport Expiry', iDExpiry as 'ID Card Expiry', visaExpiry as 'Visa Expiry', laborExpiry as 'Labor Card Expiry', wpsExpiryDate as'Salary Card Expiry' FROM aqc_manager.employees";
            DataSet DS = new DataSet();
            MySqlDataAdapter myDA = new MySqlDataAdapter(sql, con);
            myDA.Fill(DS);
            employeesShow.DataSource = DS.Tables[0];
            employeesShow.Columns["Passport Expiry"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            employeesShow.Columns["ID Card Expiry"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            employeesShow.Columns["Visa Expiry"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            employeesShow.Columns["Labor Card Expiry"].DefaultCellStyle.Format = "dd-MMM-yyyy";
            employeesShow.Columns["Salary Card Expiry"].DefaultCellStyle.Format = "dd-MMM-yyyy";

            try
            {
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboLoad()
        {
            foreach (DataGridViewColumn col in employeesShow.Columns)
            {
                headerCombo.Items.Add(col.HeaderText);
            }
            headerCombo.SelectedIndex = 0;
            
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (employeesShow.Rows.Count != 0)
            {
                employeesShow.Rows[0].Selected = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string searchValue = textBox1.Text;

            //employeesShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //try
            //{
            //    foreach (DataGridViewRow row in employeesShow.Rows)
            //    {
            //        if (row.Cells["Name"].Value.ToString().Equals(searchValue))
            //        {
            //            row.Selected = true;
            //            break;
            //        }
            //    }
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message);
            //}
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //MySqlConnection con = database.getConnection();

            //con.Open();
            //String sql = "SELECT employee_id AS 'Employee ID', name AS 'Name',fathername AS 'Father Name', sex AS 'Gender', dateOfBirth as 'Date of Birth', nationality as 'Nationality', religion as 'Religion' FROM aqc_manager.employees where LOWER(name) like '%" + textBox1.Text.ToLower() + "%'";
            //DataSet DS = new DataSet();
            //MySqlDataAdapter myDA = new MySqlDataAdapter(sql, con);
            //myDA.Fill(DS);
            
            //employeesShow.DataSource = DS.Tables[0];
            

            //con.Close();

            searchOPT();
        }

        private void searchOPT()
        {
            (employeesShow.DataSource as DataTable).DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", headerCombo.Text, textBox1.Text);
            //MySqlConnection con = database.getConnection();

            //con.Open();
            //String sql = "SELECT employee_id AS 'Employee ID', name AS 'Name',fathername AS 'Father Name', sex AS 'Gender', dateOfBirth as 'Date of Birth', nationality as 'Nationality', religion as 'Religion' FROM aqc_manager.employees where LOWER(name) like '%" + textBox1.Text.ToLower() + "%'";
            //DataSet DS = new DataSet();
            //MySqlDataAdapter myDA = new MySqlDataAdapter(sql, con);
            //myDA.Fill(DS);

            //employeesShow.DataSource = DS.Tables[0];


            //con.Close();
        }

        private void employeesShow_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void employeesShow_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Add this
                    employeesShow.CurrentCell = employeesShow.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    employeesShow.Rows[e.RowIndex].Selected = true;
                    employeesShow.Focus();
                }
            }
            catch (Exception el)
            { }
        }

        private void viewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeesShow.SelectedCells.Count > 0)
            {
                int selectedrowindex = employeesShow.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = employeesShow.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Employee ID"].Value);
                //MessageBox.Show(a);
                viewEmployee ve = new viewEmployee(a);
                ve.Show();

                ve.MdiParent = this.MdiParent;
            }
        }

        private void editEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            if (employeesShow.SelectedCells.Count > 0)
            {
                int selectedrowindex = employeesShow.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = employeesShow.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Employee ID"].Value);
                //MessageBox.Show(a);

                modifyEmployee ME = new modifyEmployee(a);
                ME.Show();

                ME.MdiParent = this.MdiParent;
            }
        }

        private void employeesShow_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (employeesShow.SelectedCells.Count > 0)
            {
                int selectedrowindex = employeesShow.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = employeesShow.Rows[selectedrowindex];

                string a = Convert.ToString(selectedRow.Cells["Employee ID"].Value);
                //MessageBox.Show(a);
                viewEmployee ve = new viewEmployee(a);
                ve.Show();

                ve.MdiParent = this.MdiParent;
            }
        }

        private void viewDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedrowindex = employeesShow.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = employeesShow.Rows[selectedrowindex];

            string a = Convert.ToString(selectedRow.Cells["Employee ID"].Value);
            string b = Convert.ToString(selectedRow.Cells["Name"].Value);
            string empo = b + "(" + a + ")";
            //MessageBox.Show(a);
            filesViewer DCViewer = new filesViewer(empo);
            DCViewer.Show();

            DCViewer.MdiParent = this.MdiParent;
        }
    }
}
