﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WPFilmweb.DAL.Encje
{
    class Oceniaja
    {
        #region Properties

        public int IDmovie { get; set; }
        public int IDuser { get; set; }
        public string Comment { get; set; }
        
        public double Grade { get; set; } 

        #endregion

        #region Constructor 
        // MySqlDataReader constructor - creates object based on MySql data
        public Oceniaja(MySqlDataReader reader)
        {
            IDmovie = int.Parse(reader["IDfilmu"].ToString());
            IDuser = int.Parse(reader["IDuzytkownika"].ToString());
            Comment = reader["komentarz"].ToString();
            Grade = double.Parse(reader["Wartość"].ToString());
        }
        #endregion
    }
}
