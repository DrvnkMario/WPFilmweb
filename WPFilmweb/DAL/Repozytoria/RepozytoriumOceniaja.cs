using System.Collections.ObjectModel;
using WPFilmweb.DAL.Encje;
using MySql.Data.MySqlClient;

namespace WPFilmweb.DAL.Repozytoria
{
    class RepozytoriumOceniaja
    {
        #region Queries
        private const string ALL_REVIEWS = "SELECT * FROM oceniaja";
        #endregion

        public static ObservableCollection<Oceniaja> GetAllReviews()
        {
            var reviews = new ObservableCollection<Oceniaja>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(ALL_REVIEWS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    reviews.Add(new Oceniaja(reader));
                connection.Close();
            }
            return reviews;
        }
    }
}