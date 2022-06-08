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
        public ObservableCollection<string> TitleList { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<ImageSource> PosterList { get; set; } = new ObservableCollection<ImageSource>();

        private Filmy emptyMovie = new Filmy("", 0, "", "", null);
        public Model()
        {
            var movies = RepozytoriumFilmy.GetMovies();
            foreach (var movie in movies)
            {
                MoviesList.Add(movie);
                TitleList.Add(movie.Title);
                PosterList.Add(movie.Poster);
            }
        }

        public ObservableCollection<string> RefreshTitles(ObservableCollection<string> m, int n)
        {
            int j = 0;
            ObservableCollection<string> temp = new ObservableCollection<string>(m);
            for (int i = 4 * n - 4; i <= n * 3 + 1; i++)
            {
                if (i == m.Count())
                {
                    for (int z = i; z <= n * 3 + 2; z++)
                    {
                        temp[j] = emptyMovie.Title;
                        j++;
                    }
                    break;
                }
                temp[j] = TitleList[i];
                j++;
            }
            return temp;
        }

        public ObservableCollection<ImageSource> RefreshPosters(ObservableCollection<ImageSource> p, int n)
        {
            int j = 0;
            ObservableCollection<ImageSource> temp = new ObservableCollection<ImageSource>(p);
            for (int i = 4 * n - 4; i <= n * 3 + 1; i++)
            {
                if (i == p.Count())
                {
                    for (int z = i; z <= n * 3 + 2; z++)
                    {
                        temp[j] = emptyMovie.Poster;
                        j++;
                    }
                    break;
                }
                temp[j] = PosterList[i];
                j++;
            }
            return temp;
        }
    }
}
