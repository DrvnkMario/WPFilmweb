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

        private Filmy emptyMovie = new Filmy("", 0, "", "", null);
        public Model()
        {

            GetMovies();
        }
        public void GetMovies()
        {
            var movies = RepozytoriumFilmy.GetMovies();
            MoviesList.Clear();
            foreach (var movie in movies)
            {
                MoviesList.Add(movie);
            }
        }
        public ObservableCollection<Filmy> RefreshMovies(ObservableCollection<Filmy> m, int n)
        {
            ObservableCollection<Filmy> movies = new ObservableCollection<Filmy>();
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
            m.Clear();
            return movies;
        }
        
    }
}
