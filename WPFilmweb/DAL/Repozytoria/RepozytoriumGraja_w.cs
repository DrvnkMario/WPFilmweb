using System.Collections.ObjectModel;
using WPFilmweb.DAL.Encje;
using MySql.Data.MySqlClient;

namespace WPFilmweb.DAL.Repozytoria
{
    class RepozytoriumGraja_w
    {
        #region Queries
        private const string ALL_PLAYING_ACTORS = "SELECT * FROM graja_w";
        #endregion

        public static ObservableCollection<Graja_w> GetPlayingActors()
        {
            var playingActors = new ObservableCollection<Graja_w>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_PLAYING_ACTORS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    playingActors.Add(new Graja_w(reader));
                connection.Close();
            }
            return playingActors;
        }
    }
}
