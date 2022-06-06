using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WPFilmweb.DAL.Encje;
using MySql.Data.MySqlClient;

namespace WPFilmweb.DAL.Repozytoria
{
    class RepozytoriumAktorzy
    {
        #region Queries
        private const string EVERY_ACTOR = "SELECT * FROM aktorzy";
        private const string ADD_ACTOR = "INSERT INTO 'aktorzy'( 'imie', 'nazwisko', 'data_urodzenia', 'biografia', 'zdjecie') VALUES";
        #endregion

        #region CRUD methods
        public static ObservableCollection<Aktorzy> GetAllActors()
        {
            ObservableCollection<Aktorzy> actors = new ObservableCollection<Aktorzy>();
            using(var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(EVERY_ACTOR, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while(reader.Read())
                    actors.Add(new Aktorzy(reader));
                connection.Close();
            }
            return actors;
        }
        #endregion
    }
}
