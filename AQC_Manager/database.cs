using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace AQC_Manager
{
    class database
    {


        public static String Server = "192.168.1.34";
        public static String Database = "aqc_manager";
        public static String UserID = "root";
        public static String password = "";

        public static MySqlConnection getConnection(){
            string sql = "Server="+Server+";Database="+Database+";Uid="+UserID+";Convert Zero Datetime=True;";
            MySqlConnection con = new MySqlConnection(sql);
           
            return con;
            }
        }
    }

