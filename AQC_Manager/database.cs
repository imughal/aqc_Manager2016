﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace AQC_Manager
{
    class database
    {
        


        public static MySqlConnection getConnection(){
            string sql = "Server=localhost;Database=aqc_manager;Uid=root;";
            MySqlConnection con = new MySqlConnection(sql);
           
            return con;
            }
        }
    }

