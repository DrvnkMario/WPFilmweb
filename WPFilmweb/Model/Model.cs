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
        public ObservableCollection<Filmy> MoviesList { get; set; } = new ObservableCollection<Filmy>(); // ok
        public ObservableCollection<string> MoviesVisibility { get; set; } = new ObservableCollection<string>(); // ok

        public ObservableCollection<Aktorzy> ActorList { get; set; } = new ObservableCollection<Aktorzy>();

        public ObservableCollection<Graja_w> ActorsMoviesList { get; set; } = new ObservableCollection<Graja_w>();

        public ObservableCollection<Rezyserzy> DirectorsList { get; set; } = new ObservableCollection<Rezyserzy>();

        public ObservableCollection<Rezyseruja> DirectorsMoviesList { get; set; } = new ObservableCollection<Rezyseruja>();

        

        public ObservableCollection<string> ActorsVisibility { get; set; } = new ObservableCollection<string>();

        public ObservableCollection<string> DirectorsVisibility { get; set; } = new ObservableCollection<string>();

        //Tu dopisuje

        public ObservableCollection<Uzytkownicy> UsersList { get; set; } = new ObservableCollection<Uzytkownicy>();

        public ObservableCollection<Oceniaja> MoviesRatio { get; set; } = new ObservableCollection<Oceniaja>();
        public ObservableCollection<Gatunek> Genres { get; set; } = new ObservableCollection<Gatunek>();
        public ObservableCollection<Okresla> MoviesAndGenresList { get; set; } = new ObservableCollection<Okresla>();
        public ObservableCollection<Nagrody> Awards { get; set; } = new ObservableCollection<Nagrody>();
        public ObservableCollection<string> AwardsVisibility { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<Nagradzaja> MoviesAwards { get; set; } = new ObservableCollection<Nagradzaja>();

        private Filmy emptyMovie = new Filmy("", 0, "", "", null);
        private Aktorzy emptyActor = new Aktorzy("", "", "", "", null);
        private Rezyserzy emptyDirector = new Rezyserzy("", "", "", "", null);
        private Nagrody emptyAward = new Nagrody("", "", null);
        public Model()
        {
            GetMovies();
            GetActors();
            GetActorsMovies();
            GetDirectors();
            GetDirectorsMovies();
            GetUsers();
            MoviesVisibility.Clear();
            ActorsVisibility.Clear();
            DirectorsVisibility.Clear();
            //
            GetMoviesRatio();
            GetGenres();
            MoviesAndGenres();
            GetAwards();
            GetMoviesAwards();
        }
        //tu      sad
        public void GetAwards()
        {
            var awards = RepozytoriumNagrody.GetAllAwards();
            Awards.Clear();
            foreach (var award in awards)
            {
                Awards.Add(award);
            }
        }
        public void RefreshAwards(ObservableCollection<Nagrody> awards, int n)
        {
            if (Awards.Count != 0)
            {
                awards.Clear(); // this line is intentional. It's purpouse is clearing ObservableCollection passed as reference, that way it is always filled with 4 objects
                AwardsVisibility.Clear();
                for (int i = 4 * n - 4; i <= n * 3 + 1; i++)
                {
                    if (i == Awards.Count())
                    {
                        for (int z = i; z <= n * 3 + 2; z++)
                        {
                            awards.Add(emptyAward);
                            AwardsVisibility.Add("Hidden");
                        }
                        break;
                    }
                    awards.Add(Awards[i]);
                    AwardsVisibility.Add("Visible");
                }
            }
            else
            {
                for (int i = 0; i <= 4; i++)
                {
                    awards.Add(emptyAward);
                    AwardsVisibility.Add("Hidden");
                }
            }
        }
        public void GetAwardsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                GetAwards();
            }
            else
            {
                GetAwards();
                ObservableCollection<Nagrody> temp = new ObservableCollection<Nagrody>();
                AwardsVisibility.Clear();
                foreach (var award in Awards)
                {
                    if (award.Name.ToLower().Contains(name.ToLower()))
                    {
                        temp.Add(award);
                        AwardsVisibility.Add("Visible");
                    }
                    else
                    {
                        AwardsVisibility.Add("Hidden");
                    }
                }
                Awards.Clear();
                Awards = temp;
            }
        }
        public void GetMoviesAwards()
        {
            var MoviesRewards = RepozytoriumNagradzaja.GetMovieRewards();
            foreach(var mr in MoviesRewards)
            {
                MoviesAwards.Add(mr);
            }
        }
        private Nagrody GetAwardById(int id)
        {
            foreach (var a in Awards)
            {
                if (a.IDAward == id)
                    return a;
            }
            return null;
        }
        public string GetMovieAwards(Filmy movie)
        {
            string awards = "";
            foreach (var a in MoviesAwards)
            {
                if (a.IDmovie == movie.IDmovie)
                {
                    awards +=  GetAwardById(a.IDaward).Name;
                }
            }
            if (awards != String.Empty)
                return awards;
            else
                return "Brak danych";
        }
        public void GetGenres()
        {
            var genres = RepozytoriumGatunek.GetGenres();
            Genres.Clear();
            foreach (var genre in genres)
            {
                Genres.Add(genre);
            }
        }
        public void MoviesAndGenres()
        {
            var MoviesAndGenres = RepozytoriumOkresla.GetDefiningGenres();
            MoviesAndGenresList.Clear();
            foreach(var mg in MoviesAndGenres)
            {
                MoviesAndGenresList.Add(mg);
            }
        }
        private Gatunek FindGenreByID(int id)
        {
            foreach (var g in Genres)
            {
                if (g.IDgenre == id)
                    return g;
            }
            return null;
        }
        public string GetMovieGenres(Filmy movie)
        {
            string genre = "";
            foreach (var g in MoviesAndGenresList)
            {
                if (g.IDmovie == movie.IDmovie)
                {
                    genre += FindGenreByID(g.IDgenre).Name;
                }
            }
            if (genre != String.Empty)
                return genre;
            else
                return "Brak danych";
        }
        public void UpdateAddGrade(int movieId, int userId, int grade)
        {
            bool temp = true;
            for(int i = 0; i < MoviesRatio.Count; i++)
            {
                if(MoviesRatio[i].IDmovie == movieId && MoviesRatio[i].IDuser == userId)
                {
                    RepozytoriumOceniaja.UpdateGrade(movieId, userId, grade);
                    temp = false;
                    break;
                }
            }
            if(temp)
            {
                RepozytoriumOceniaja.AddGrade(movieId, userId, grade);
            }
            MoviesRatio.Clear();
            GetMoviesRatio();
        }
        public void GetMoviesRatio()
        {
            var moviesratio = RepozytoriumOceniaja.GetAllReviews();
            MoviesRatio.Clear();
            foreach (var mr in moviesratio)
            {
                MoviesRatio.Add(mr);
            }
        }

        public string GetMovieRatio(Filmy m)
        {
            double result = 0;
            int temp = 0;
            for(int i = 0; i < MoviesRatio.Count; i++)
            {
                if(MoviesRatio[i].IDmovie == m.IDmovie)
                {
                    result += (MoviesRatio[i].Grade);
                    temp++;
                }    
            }
            // 
            if (temp > 0)
                return "Ocena filmu: " + (result / temp).ToString("F");
            else
                return "Ocena filmu: " + 0.ToString("F");
        }
        public int GetUserRatio(Filmy m, int user)
        {
            for (int i = 0; i < MoviesRatio.Count; i++)
            {
                if(MoviesRatio[i].IDmovie == m.IDmovie && MoviesRatio[i].IDuser == user)
                {
                    return int.Parse(MoviesRatio[i].Grade.ToString());
                }
            }
            return 0;
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

        //tu dopisuje
        public void GetUsers()
        {
            var users = RepozytoriumUzytkownicy.GetAllUsers();
            UsersList.Clear();
            foreach (var user in users)
            {
                UsersList.Add(user);
            }
            UsersList = new ObservableCollection<Uzytkownicy>(UsersList.OrderBy(user => user.Nickname).ToList());
        }

        public void GetActorsMovies()
        {
            var actorsMovies = RepozytoriumGraja_w.GetPlayingActors();
            ActorsMoviesList.Clear();
            foreach (var actorsMovie in actorsMovies)
            {
                ActorsMoviesList.Add(actorsMovie);
            }
        }

        public void GetDirectors()
        {
            var directors = RepozytoriumRezyserzy.GetAllDirectors();
            DirectorsList.Clear();
            foreach (var director in directors)
            {
                DirectorsList.Add(director);
            }
            DirectorsList = new ObservableCollection<Rezyserzy>(DirectorsList.OrderBy(director => (director.Name + director.Surname)).ToList());
        }

        public void GetDirectorsMovies()
        {
            var directorMovies = RepozytoriumRezyseruja.GetMovieDirectors();
            DirectorsMoviesList.Clear();
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
                DirectorsVisibility.Clear();
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
                if (a.IDmovie == movie.IDmovie)
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
                if (d.IDmovie == movie.IDmovie)
                {
                    directors.Add(FindDirectorById(d.IDdirector));
                }
            }
            return directors;
        }

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
                MoviesVisibility.Clear();
                foreach (var movie in MoviesList)
                {
                    if (movie.Title.ToLower().Contains(title.ToLower()))
                    {
                        temp.Add(movie);
                        MoviesVisibility.Add("Visible");
                    }
                    else
                    {
                        MoviesVisibility.Add("Hidden");
                    }
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
                ActorsVisibility.Clear();
                foreach (var actor in ActorList)
                {
                    if ((actor.Name + " " + actor.Surname).ToLower().Contains(name.ToLower()))
                    {
                        temp.Add(actor);
                        ActorsVisibility.Add("Visible");
                    }
                    else
                    {
                        ActorsVisibility.Add("Hidden");
                    }
                }
                ActorList.Clear();
                ActorList = temp;
            }
        }

        public void GetDirectorsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                GetDirectors();
            }
            else
            {
                GetDirectors();
                ObservableCollection<Rezyserzy> temp = new ObservableCollection<Rezyserzy>();
                DirectorsVisibility.Clear();
                foreach (var director in DirectorsList)
                {
                    if ((director.Name + " " + director.Surname).ToLower().Contains(name.ToLower()))
                    {
                        temp.Add(director);
                        DirectorsVisibility.Add("Visible");
                    }
                    else
                    {
                        DirectorsVisibility.Add("Hidden");
                    }
                }
                DirectorsList.Clear();
                DirectorsList = temp;
            }
        }

        //tu
        
        //
        public ObservableCollection<string> GetRatingsForMovieList(ObservableCollection<Filmy> movies)
        {
            double grade = 0;
            int temp = 0;
            ObservableCollection<string> result = new ObservableCollection<string>();
            for (int i = 0; i < movies.Count; i++)
            {
                if(movies[i].Title != "") // check if list isnt filled with empty movie
                {
                    for (int j = 0; j < MoviesRatio.Count; j++)
                    {
                        if (movies[i].IDmovie == MoviesRatio[j].IDmovie)
                        {
                            grade += MoviesRatio[j].Grade;
                            temp++;
                        }
                    }
                    if (temp > 0)
                        result.Add((grade / temp).ToString("F"));
                    else
                        result.Add(0.ToString("F"));
                    grade = 0;
                    temp = 0;
                }
                else
                {
                    result.Add("");
                }
            }
            return result;
            
        }
        public bool checkAdmin(int userID)
        {
            var users = UsersList;
            for(int i = 0; i< UsersList.Count(); i++)
            {
                if (users[i].IDUser == userID && users[i].AccountType == "Administrator")
                    return true;
            }
            return false;
        }
    }
}
