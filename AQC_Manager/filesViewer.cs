using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AQC_Manager
{
    public partial class filesViewer : Form
    {
        public filesViewer()
        {
            InitializeComponent();
        }

        private void filesViewer_Load(object sender, EventArgs e)
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
                            comboBox1.Items.Add(Name + "("+employee_id+")");
                        }
                    }
                }
            }
        }
    }
}
