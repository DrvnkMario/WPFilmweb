using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPFilmweb.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;

    class Model
    {
        public ObservableCollection<Filmy> MoviesList { get; set; } = new ObservableCollection<Filmy>();

        public ObservableCollection<Aktorzy> ActorList { get; set; } = new ObservableCollection<Aktorzy>();

        public ObservableCollection<Graja_w> ActorsMoviesList { get; set; } = new ObservableCollection<Graja_w>();

        public ObservableCollection<Rezyserzy> DirectorsList { get; set; } = new ObservableCollection<Rezyserzy>();

        public ObservableCollection<Rezyseruja> DirectorsMoviesList { get; set; } = new ObservableCollection<Rezyseruja>();

        private Filmy emptyMovie = new Filmy("", 0, "", "", null);

        public Model()
        {
            GetMovies();
            GetActors();
            GetActorsMovies();
            GetDirectors();
            GetDirectorsMovies();
        }

        public void GetMovies() // Filling up models movie list
        {
            var movies = RepozytoriumFilmy.GetMovies();
            MoviesList.Clear();
            foreach (var movie in movies)
            {
                MoviesList.Add(movie);
            }
            MoviesList = new ObservableCollection<Filmy>(MoviesList.OrderBy(movie => movie.Title).ToList());
        }

        public void GetActors()
        {
            var actors = RepozytoriumAktorzy.GetAllActors();
            foreach (var actor in actors)
            {
                ActorList.Add(actor);
            }
        }

        public void GetActorsMovies()
        {
            var actorsMovies = RepozytoriumGraja_w.GetPlayingActors();
            foreach (var actorsMovie in actorsMovies)
            {
                ActorsMoviesList.Add(actorsMovie);
            }
        }

        public void GetDirectors()
        {
            var directors = RepozytoriumRezyserzy.GetAllDirectors();
            foreach (var director in directors)
            {
                DirectorsList.Add(director);
            }
        }

        public void GetDirectorsMovies()
        {
            var directorMovies = RepozytoriumRezyseruja.GetMovieDirectors();
            foreach(var directorMovie in directorMovies)
            {
                DirectorsMoviesList.Add(directorMovie);
            }
        }

        public void RefreshMovies(ObservableCollection<Filmy> movies, int n)
        {
            movies.Clear(); // this line is intentional. It's purpouse is clearing ObservableCollection passed as reference, that way it is always
            for (int i = 4 * n - 4; i <= n * 3 + 1; i++)
            {
                if (i == MoviesList.Count())
                {
                    for (int z = i; z <= n * 3 + 2; z++)
                    {
                        movies.Add(emptyMovie);
                    }
                    break;
                }
                movies.Add(MoviesList[i]);
            }
        }
        //Do sprawdzenia

        //private Filmy FindMovieById(int id)
        //{
        //    foreach (var m in MoviesList)
        //    {
        //        if (m.IDmovie == id)
        //            return m;
        //    }
        //    return null;
        //}

        private Aktorzy FindActorById(int id)
        {
            foreach (var a in ActorList)
            {
                if (a.IDActor == id)
                    return a;
            }
            return null;
        }

        private Rezyserzy FindDirectorById(int id)
        {
            foreach (var d in DirectorsList)
            {
                if (d.IDDirector == id)
                    return d;
            }
            return null;
        }

        public ObservableCollection<Aktorzy> GetActorsFromMovie(Filmy movie)
        {
            var actors = new ObservableCollection<Aktorzy>();
            foreach (var a in ActorsMoviesList)
            {
                if (a.IDactor == movie.IDmovie)
                {
                    actors.Add(FindActorById(a.IDactor));
                }
            }
            return actors;
        }

        public ObservableCollection<Rezyserzy> GetDirectorsFromMovie(Filmy movie)
        {
            var directors = new ObservableCollection<Rezyserzy>();
            foreach (var d in DirectorsMoviesList)
            {
                if (d.IDdirector == movie.IDmovie)
                {
                    directors.Add(FindDirectorById(d.IDdirector));
                }
            }
            return directors;
        }
    }
}
