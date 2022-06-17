using System.Collections.ObjectModel;
using WPFilmweb.DAL.Encje;
using MySql.Data.MySqlClient;

namespace WPFilmweb.DAL.Repozytoria
{
    class RepozytoriumNagrody
    {
        #region Queries
        private const string GET_EVERY_AWARD = "SELECT * FROM nagrody";
        private const string ADD_AWARD = "INSERT INTO 'nagrody'( 'nazwa', 'opis_nagrody', 'zdjecie') VALUES";
        #endregion

        #region CRUD methods
        public static ObservableCollection<Nagrody> GetAllAwards()
        {
            ObservableCollection<Nagrody> awards = new ObservableCollection<Nagrody>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_EVERY_AWARD, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    awards.Add(new Nagrody(reader));
                connection.Close();
            }
            return awards;
        }

        public static bool AddAward(Nagrody award)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{ADD_AWARD} {award.ToInsert()}", connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                state = true;
                award.IDAward = (int)command.LastInsertedId;
                connection.Close();
            }
            return state;
        }

        public static bool EditAward(Nagrody award, int IDAward)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string EDIT_AWARD = $"UPDATE nagrody SET nazwa='{award.Name}', opis_nagrody='{award.Description}', zdjecie='{award.AwardImage}'" +
                    $"WHERE IDnagrody = {IDAward}";
                MySqlCommand command = new MySqlCommand(EDIT_AWARD, connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                if (id == 1)
                    state = true;

                connection.Close();
            }
            return state;
        }

        public static bool DeleteAward(Nagrody award)
        {
            bool state = false;
            using (var connection = DBConnection.Instance.Connection)
            {
                string DELETE_AWARD = $"DELETE FROM nagrody WHERE IDnagrody = {award.IDAward}";
                MySqlCommand command = new MySqlCommand(DELETE_AWARD, connection);
                connection.Open();
                var id = command.ExecuteNonQuery();
                if (id == 1)
                    state = true;

                connection.Close();
            }
            return state;
        }
        #endregion
    }
}
