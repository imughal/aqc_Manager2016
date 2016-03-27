using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace AQC_Manager
{
    class database
    {
        string sql = "Server=localhost;Database=phpMyAdmin;Uid=root;";


        public MySqlConnection getConnection(){
            MySqlConnection con = new MySqlConnection(sql);
           
            return con;
            }
        }
    }
}
