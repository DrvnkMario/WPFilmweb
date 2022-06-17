using System.Collections.ObjectModel;
using WPFilmweb.DAL.Encje;
using MySql.Data.MySqlClient;

namespace WPFilmweb.DAL.Repozytoria
{
    class RepozytoriumRezyseruja
    {
        #region Queries
        private const string GET_MOVIE_DIRECTORS = "SELECT * FROM rezyseruja";
        #endregion

        public static ObservableCollection<Rezyseruja> GetMovieDirectors()
        {
            var movieDirectors = new ObservableCollection<Rezyseruja>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_MOVIE_DIRECTORS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    movieDirectors.Add(new Rezyseruja(reader));
                connection.Close();
            }
            return movieDirectors;
        }
    }
}