using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using WPFilmweb.DAL.Encje;

namespace WPFilmweb.DAL.Repozytoria
{
    class RepozytoriumFilmy
    {
        private const string SHOW_MOVIES = "SELECT * FROM filmy";

        public static List<Filmy> getMovies()
        {
            List<Filmy> movies = new List<Filmy>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(SHOW_MOVIES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    movies.Add(new Filmy(reader));
                connection.Close();
            }
            return movies;
        }

    }
}
