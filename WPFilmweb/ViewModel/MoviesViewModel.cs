using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Navigation;

namespace WPFilmweb.ViewModel
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using WPFilmweb.Model;
    using WPFilmweb.ViewModel.BaseClasses;
    using WPFilmweb.View;

    class MoviesViewModel : ViewModelBase
    {
        private Model model { get; set; }
        private ObservableCollection<Filmy> movies {get; set;}

        private ObservableCollection<string> titles { get; set; }

        private ObservableCollection<ImageSource> posters { get; set; }

        private int currentPage { get; set; }

        public MoviesViewModel()
        {
            model = new Model();
            movies = new ObservableCollection<Filmy>();
            titles = new ObservableCollection<string>();

            movies = model.MoviesList;
            titles = model.TitleList;
            posters = model.PosterList;

            currentPage = 1;
            
        }


        public ObservableCollection<string> Titles
        {
            get
            {
                return titles;
            }
            set
            {
                titles = value;
                onPropertyChanged(nameof(Titles));
            }
        }

        public ObservableCollection<ImageSource> Posters
        {
            get
            {
                return posters;
            }
            set
            {
                posters = value;
                onPropertyChanged(nameof(Posters));
            }
        }

        public int CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                onPropertyChanged(nameof(CurrentPage));
            }
        }

        private ICommand nextPage;

        public ICommand NextPage => nextPage ?? (nextPage = new RelayCommand(
            o =>
            {
               if(CurrentPage <= movies.Count()/4)
                {
                    CurrentPage++;
                    Titles = model.RefreshTitles(Titles, CurrentPage);
                    Posters = model.RefreshPosters(Posters,CurrentPage);
                }
                    
            }, null));

        private ICommand previousPage;

        public ICommand PreviousPage => previousPage ?? (previousPage = new RelayCommand(
            o =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage--;
                    Titles = model.RefreshTitles(Titles, CurrentPage);
                    Posters = model.RefreshPosters(Posters, CurrentPage);
                }

            }, null));

        private ICommand movieClick;

        public ICommand MovieClick => movieClick ?? (movieClick = new RelayCommand(
            o =>
            {
                Console.WriteLine("test");
                //NavigationService.GetNavigationService(null).Navigate(new MovieDescription());
                //NavigationService.Navigate(new MovieDescription());
            }, null
            ));
    }
}
