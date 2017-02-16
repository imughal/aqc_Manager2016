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
    public partial class employeesList : Form
    {
        public employeesList()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
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
            String sql = "SELECT employee_id AS 'Employee ID', name AS 'Name',fathername AS 'Father Name', sex AS 'Gender', dateOfBirth as 'Date of Birth', nationality as 'Nationality', religion as 'Religion' FROM aqc_manager.employees";
            DataSet DS = new DataSet();
            MySqlDataAdapter myDA = new MySqlDataAdapter(sql, con);
            myDA.Fill(DS);
            employeesShow.DataSource = DS.Tables[0];


            try
            {
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //int rowNumber = 1;
            //foreach (DataGridViewRow row in employeesShow.Rows)
            //{
            //    if (row.IsNewRow) continue;
            //    row.HeaderCell.Value = "Row " + rowNumber;
            //    rowNumber = rowNumber + 1;
            //}
            //employeesShow.AutoResizeRowHeadersWidth(
            //    DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;

            employeesShow.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in employeesShow.Rows)
                {
                    if (row.Cells[2].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = database.getConnection();

            con.Open();
            String sql = "SELECT employee_id AS 'Employee ID', name AS 'Name',fathername AS 'Father Name', sex AS 'Gender', dateOfBirth as 'Date of Birth', nationality as 'Nationality', religion as 'Religion' FROM aqc_manager.employees where LOWER(name) like '%" + textBox1.Text.ToLower() + "%'";
            DataSet DS = new DataSet();
            MySqlDataAdapter myDA = new MySqlDataAdapter(sql, con);
            myDA.Fill(DS);
            employeesShow.DataSource = DS.Tables[0];

            con.Close();
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
            if (e.Button == MouseButtons.Right)
            {
                // Add this
                employeesShow.CurrentCell = employeesShow.Rows[e.RowIndex].Cells[e.ColumnIndex];
                // Can leave these here - doesn't hurt
                employeesShow.Rows[e.RowIndex].Selected = true;
                employeesShow.Focus();
            }
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
    }
}
