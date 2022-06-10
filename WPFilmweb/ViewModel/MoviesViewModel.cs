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
        private NavigationModel navigationModel { get; set; }
        public NavigationModel NavigationModel
        {
            get { return navigationModel; }
            set 
            { 
                navigationModel = value;
                onPropertyChanged(nameof(NavigationModel));
            }
        }
        private Model model { get; set; }
        public Model Model
        {
            get { return model; }
            set { model = value; }
        }
        private ObservableCollection<Filmy> movies { get; set; }
        public ObservableCollection<Filmy> Movies
        {
            get { return movies; }
            set
            {
                movies = value;
                onPropertyChanged(nameof(Movies));
            }
        }

        private ObservableCollection<Aktorzy> actors { get; set; }
        public ObservableCollection<Aktorzy> Actors
        {
            get { return actors; }
            set
            {
                actors = value;
                onPropertyChanged(nameof(Actors));
            }
        }

        private ObservableCollection<Rezyserzy> directors { get; set; }
        public ObservableCollection<Rezyserzy> Directors
        {
            get { return directors; }
            set
            {
                directors = value;
                onPropertyChanged(nameof(Directors));
            }
        }

        private int currentPage { get; set; }

        public MoviesViewModel(Model m, NavigationModel navimodel)
        {
            NavigationModel = navimodel;
            Model = m;
            Movies = new ObservableCollection<Filmy>();
            Directors = new ObservableCollection<Rezyserzy>();
            Actors = new ObservableCollection<Aktorzy>();
            CurrentPage = 1;
            model.RefreshMovies(movies, currentPage);
            Directors = model.DirectorsList;
            Actors = model.ActorList;

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
                if (CurrentPage <= Model.MoviesList.Count() / 4)
                {
                    CurrentPage++;
                    model.RefreshMovies(Movies, currentPage);
                }

            }, null));

        private ICommand previousPage;

        public ICommand PreviousPage => previousPage ?? (previousPage = new RelayCommand(
            o =>
            {
                if (CurrentPage > 1)
                {
                    CurrentPage--;
                    model.RefreshMovies(Movies, currentPage);
                }

            }, null));

        private ICommand movieClick1;

        public ICommand MovieClick1 => movieClick1 ?? (movieClick1 = new RelayCommand(
            o =>
            {

                if (Movies[0].Title != "")
                {
                    NavigationModel.ChangeVM(new MovieDescriptionViewModel(Movies[0], Actors, Directors));
                }
            }, null
            ));
        private ICommand movieClick2;

        public ICommand MovieClick2 => movieClick2 ?? (movieClick2 = new RelayCommand(
            o =>
            {
                if(Movies[1].Title != "")
                {
                    NavigationModel.ChangeVM(new MovieDescriptionViewModel(Movies[1], Actors, Directors));
                }
            }, null
            ));
        private ICommand movieClick3;

        public ICommand MovieClick3 => movieClick3 ?? (movieClick3 = new RelayCommand(
            o =>
            {
                if (Movies[2].Title != "")
                {
                    NavigationModel.ChangeVM(new MovieDescriptionViewModel(Movies[2], Actors, Directors));
                }
            }, null
            ));
        private ICommand movieClick4;

        public ICommand MovieClick4 => movieClick4 ?? (movieClick4 = new RelayCommand(
            o =>
            {
                if (Movies[3].Title != "")
                {
                    NavigationModel.ChangeVM(new MovieDescriptionViewModel(Movies[3], Actors, Directors));
                }
            }, null
            ));
    }
}
