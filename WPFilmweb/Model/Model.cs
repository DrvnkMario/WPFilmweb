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

        public ObservableCollection<string> MoviesVisibility { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> ActorsVisibility { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> DirectorsVisibility { get; set; } = new ObservableCollection<string>();

        private Filmy emptyMovie = new Filmy("", 0, "", "", null);
        private Aktorzy emptyActor = new Aktorzy("", "", "", "", null);
        private Rezyserzy emptyDirector = new Rezyserzy("", "", "", "", null);
        public Model()
        {
            GetMovies();
            GetActors();
            GetActorsMovies();
            GetDirectors();
            GetDirectorsMovies();
            MoviesVisibility.Clear();
            ActorsVisibility.Clear();
            DirectorsVisibility.Clear();
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
            ActorList.Clear();
            foreach (var actor in actors)
            {
                ActorList.Add(actor);
            }
            ActorList = new ObservableCollection<Aktorzy>(ActorList.OrderBy(actor => (actor.Name + actor.Surname)).ToList());
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
            if(MoviesList.Count != 0)
            {
                movies.Clear(); // this line is intentional. It's purpouse is clearing ObservableCollection passed as reference, that way it is always filled with 4 objects
                MoviesVisibility.Clear();
                for (int i = 4 * n - 4; i <= n * 3 + 1; i++)
                {
                    if (i == MoviesList.Count())
                    {
                        for (int z = i; z <= n * 3 + 2; z++)
                        {
                            movies.Add(emptyMovie);
                            MoviesVisibility.Add("Hidden");
                        }
                        break;
                    }
                    movies.Add(MoviesList[i]);
                    MoviesVisibility.Add("Visible");
                }
            }
            else
            {
                for(int i = 0; i <= 4; i++)
                {
                    movies.Add(emptyMovie);
                    MoviesVisibility.Add("Hidden");
                }    
            }
        }
        public void RefreshActors(ObservableCollection<Aktorzy> actors, int n)
        {
            if (ActorList.Count != 0)
            {
                ActorsVisibility.Clear();
                actors.Clear(); // this line is intentional. It's purpouse is clearing ObservableCollection passed as reference, that way it is always filled with 4 objects
                for (int i = 4 * n - 4; i <= n * 3 + 1; i++)
                {
                    if (i == ActorList.Count())
                    {
                        for (int z = i; z <= n * 3 + 2; z++)
                        {
                            actors.Add(emptyActor);
                            ActorsVisibility.Add("Hidden");
                        }
                        break;
                    }
                    actors.Add(ActorList[i]);
                    ActorsVisibility.Add("Visible");
                }
            }
            else
            {
                for (int i = 0; i <= 4; i++)
                {
                    actors.Add(emptyActor);
                    ActorsVisibility.Add("Hidden");
                }     
            }
        }

        public void RefreshDirectors(ObservableCollection<Rezyserzy> directors, int n)
        {
            if (DirectorsList.Count != 0)
            {
                directors.Clear(); // this line is intentional. It's purpouse is clearing ObservableCollection passed as reference, that way it is always filled with 4 objects
                for (int i = 4 * n - 4; i <= n * 3 + 1; i++)
                {
                    if (i == DirectorsList.Count())
                    {
                        for (int z = i; z <= n * 3 + 2; z++)
                        {
                            directors.Add(emptyDirector);
                            DirectorsVisibility.Add("Hidden");
                        }
                        break;
                    }
                    directors.Add(DirectorsList[i]);
                    DirectorsVisibility.Add("Visible");
                }
            }
            else
            {
                for (int i = 0; i <= 4; i++)
                {
                    directors.Add(emptyDirector);
                    DirectorsVisibility.Add("Hidden");
                }
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

        //
        private Filmy FindMovieById(int id)
        {
            foreach (var m in MoviesList)
            {
                if (m.IDmovie == id)
                    return m;
            }
            return null;
        }

        public ObservableCollection<Filmy> GetMoviesFromActor(Aktorzy actor)
        {
            var movies = new ObservableCollection<Filmy>(); //
            foreach (var a in ActorsMoviesList)
            {
                if (a.IDactor == actor.IDActor)
                {
                    movies.Add(FindMovieById(a.IDmovie));
                }
            }
            return movies;
        }

        public ObservableCollection<Filmy> GetMoviesFromDirector(Rezyserzy director)
        {
            var movies = new ObservableCollection<Filmy>(); //
            foreach (var d in DirectorsMoviesList)
            {
                if (d.IDdirector == director.IDDirector)
                {
                    movies.Add(FindMovieById(d.IDmovie));
                }
            }
            return movies;
        }

        public void GetMoviesByTitle(string title)
        {
            if(string.IsNullOrEmpty(title))
            {
                GetMovies();

            }
            else
            {
                GetMovies();
                ObservableCollection<Filmy> temp = new ObservableCollection<Filmy>();
                foreach (var movie in MoviesList)
                {
                    if(movie.Title.ToLower().Contains(title.ToLower()))
                        temp.Add(movie);
                }
                MoviesList.Clear();
                MoviesList = temp;
            }
        }
        public void GetActorsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                GetActors();
            }
            else
            {
                GetActors();
                ObservableCollection<Aktorzy> temp = new ObservableCollection<Aktorzy>();
                foreach (var actor in ActorList)
                {
                    if ((actor.Name + " " + actor.Surname).ToLower().Contains(name.ToLower()))
                        temp.Add(actor);
                }
                ActorList.Clear();
                ActorList = temp;
            }
        }
    }
}
