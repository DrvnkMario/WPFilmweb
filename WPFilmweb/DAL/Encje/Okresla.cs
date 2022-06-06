﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WPFilmweb.DAL.Encje
{
    class Okresla
    {
        #region Properties
        public int IDmovie { get; set; }
        public int IDgenre { get; set; }
        #endregion

        #region Constructors
        // MySqlDataReader constructor - creates object based on MySql data
        public Okresla(MySqlDataReader reader)
        {
            IDmovie = int.Parse(reader["IDfilmu"].ToString());
            IDgenre = int.Parse(reader["IDgatunku"].ToString());
        }
        #endregion
    }
}
