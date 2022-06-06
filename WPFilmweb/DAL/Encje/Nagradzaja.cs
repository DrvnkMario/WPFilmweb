using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WPFilmweb.DAL.Encje
{
    class Nagradzaja
    {
        #region 
        public int IDmovie { get; set; }
        public int IDaward { get; set; }
        #endregion

        #region Constructors
        // MySqlDataReader constructor - creates object based on MySql data
        public Nagradzaja(MySqlDataReader reader)
        {
            IDmovie = int.Parse(reader["IDfilmu"].ToString());
            IDaward = int.Parse(reader["IDnagrody"].ToString());
        }
        #endregion



    }
}
