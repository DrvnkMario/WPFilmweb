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
        public Model Model
        {
            get { return model; }
            set { model = value; }
        }
        private ObservableCollection<Filmy> movies {get; set;}
        public ObservableCollection<Filmy> Movies
        {
            get { return movies; }
            set 
            {
                movies = value; 
                onPropertyChanged(nameof(Movies));
            }
        }

        private int currentPage { get; set; }

        public MoviesViewModel()
        {
            Model = new Model();
            Movies = new ObservableCollection<Filmy>();
            CurrentPage = 1;
            Movies = model.RefreshMovies(movies,currentPage);
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
               if(CurrentPage <= Model.MoviesList.Count()/4)
                {
                    CurrentPage++;
                    Movies = model.RefreshMovies(Movies,currentPage);
                }
                    
            }, null));

        private ICommand previousPage;

        public ICommand PreviousPage => previousPage ?? (previousPage = new RelayCommand(
            o =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage--;
                    Movies = model.RefreshMovies(Movies, currentPage);
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
