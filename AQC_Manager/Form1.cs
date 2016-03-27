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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string sql = "Server=localhost;Database=phpMyAdmin;Uid=root;";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(sql);
            MySqlCommand cmd;
            con.Open();
            try{
cmd = con.CreateCommand();
}
catch(Exception){
throw;

}
finally {
if(con.State == ConnectionState.Open){
con.Close();
}
}
        }
    }
}
