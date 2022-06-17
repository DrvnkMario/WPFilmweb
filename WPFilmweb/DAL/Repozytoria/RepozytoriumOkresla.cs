using System.Collections.ObjectModel;
using WPFilmweb.DAL.Encje;
using MySql.Data.MySqlClient;

namespace WPFilmweb.DAL.Repozytoria
{
    class RepozytoriumOkresla
    {
        #region Queries
        private const string GET_DEFINING_GENRES = "SELECT * FROM okresla";
        #endregion

        public static ObservableCollection<Okresla> GetDefiningGenres()
        {
            var definingGenres = new ObservableCollection<Okresla>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_DEFINING_GENRES, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    definingGenres.Add(new Okresla(reader));
                connection.Close();
            }
            return definingGenres;
        }
    }
}