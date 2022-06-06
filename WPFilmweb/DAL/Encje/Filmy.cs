﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFilmweb.DAL.Encje
{
    class Filmy
    {
        #region Properties

        public int? IDmovie { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Length { get; set; }
        public string Description { get; set; }
        public ImageSource Poster { get; set; }

        #endregion

        #region Constructors
        // MySqlDataReader constructor - creates object based on MySql data
        public Filmy(MySqlDataReader reader)
        {
            IDmovie = int.Parse(reader["IDfilmu"].ToString());
            Title = reader["tytul"].ToString();
            ReleaseYear = int.Parse(reader["rok_wydania"].ToString());
            Length = reader["czas_trwania"].ToString();
            Description = reader["opis"].ToString();

            BitmapImage temp = new BitmapImage();
            MemoryStream ms = new MemoryStream((byte[])reader["plakat"]);
            temp.BeginInit();
            temp.StreamSource = ms;
            temp.EndInit();
            Poster = temp as ImageSource;
        }
        // New object ctcreated from scratch, to add into database
        public Filmy(string title, int releaseYear, string length, string description, ImageSource poster)
        {
            IDmovie = null;
            Title = title;
            ReleaseYear = releaseYear;
            Length = length;
            Description = description;
            Poster = poster;
        }
        
        //Copty ctor
        public Filmy(Filmy movie)
        {
            IDmovie = movie.IDmovie;
            Title = movie.Title;
            ReleaseYear = movie.ReleaseYear;
            Length = movie.Length;
            Description = movie.Description;
            Poster = movie.Poster;
        }
        #endregion

        #region Methods

        public string ToInsert()
        {
            return $"'{Title}','{ReleaseYear}','{Length}','{Description}','{Poster}'";
        }
        // Override Equals method to check if actor is not duplicated with Contains function
        public override bool Equals(object obj)
        {
            var movie = obj as Filmy;
            if (movie == null) return false;
            if (Title.ToLower() != movie.Title.ToLower()) return false;
            if(ReleaseYear != movie.ReleaseYear) return false;
            if(Length != movie.Length) return false;
            if(Description.ToLower() != movie.Description.ToLower()) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
