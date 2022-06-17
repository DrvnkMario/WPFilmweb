﻿using System.Collections.ObjectModel;
using WPFilmweb.DAL.Encje;
using MySql.Data.MySqlClient;

namespace WPFilmweb.DAL.Repozytoria
{
    class RepozytoriumNagradzaja
    {
        #region Queries
        private static string GET_MOVIE_REWARDS = "SELECT * FROM nagradzaja";
        #endregion

        public static ObservableCollection<Nagradzaja> GetMovieRewards()
        {
            var movieRewards = new ObservableCollection<Nagradzaja>();
            using (var connection = DBConnection.Instance.Connection)
            {
                MySqlCommand command = new MySqlCommand(GET_MOVIE_REWARDS, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                    movieRewards.Add(new Nagradzaja(reader));
                connection.Close();
            }
            return movieRewards;
        }
    }
}
