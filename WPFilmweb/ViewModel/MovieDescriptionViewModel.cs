using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFilmweb.ViewModel.BaseClasses;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace WPFilmweb.ViewModel
{
    using Model;
    using DAL.Encje;
    internal class MovieDescriptionViewModel : ViewModelBase
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
        private Filmy currentMovie;

        public Filmy CurrentMovie
        {
            get
            {
                return currentMovie;
            }
            set
            {
                currentMovie = value;
                onPropertyChanged(nameof(CurrentMovie));
            }
        }

        private ObservableCollection<Aktorzy> currentActors;

        public ObservableCollection<Aktorzy> CurrentActors
        {
            get
            {
                return currentActors;
            }
            set
            {
                currentActors = value;
                onPropertyChanged(nameof(CurrentActors));
            }
        }

        private ObservableCollection<Rezyserzy> currentDirectors;

        public ObservableCollection<Rezyserzy> CurrentDirectors
        {
            get
            {
                return currentDirectors;
            }
            set
            {
                currentDirectors = value;
                onPropertyChanged(nameof(CurrentDirectors));
            }
        }

        private string currentRating;

        public string CurrentRating
        {
            get
            {
                return currentRating;
            }
            set
            {
                currentRating = value;
                onPropertyChanged(nameof(CurrentRating));
            }
        }

        private int currentUserId;

        public int CurrentUserId
        {
            get
            {
                return currentUserId;
            }
            set
            {
                currentUserId = value;
                onPropertyChanged(nameof(CurrentUserId));
            }
        }

        private double curretUserRatio;

        public double CurretUserRatio
        {
            get { return curretUserRatio; }
            set
            {
                curretUserRatio = value;
                onPropertyChanged(nameof(CurretUserRatio));
            }
        }

        public MovieDescriptionViewModel(Filmy movie, ObservableCollection<Aktorzy> actors, ObservableCollection<Rezyserzy> director, int id, NavigationModel navi, Model model)
        {
            Model = model;
            CurrentMovie = movie;
            CurrentActors = actors;
            CurrentActors = Model.GetActorsFromMovie(movie);
            CurrentDirectors = director;
            CurrentDirectors = Model.GetDirectorsFromMovie(movie);
            NavigationModel = navi;
            //
            CurrentRating = Model.GetMovieRatio(CurrentMovie);
            CurrentUserId = id;
            CurretUserRatio = Model.GetUserRatio(CurrentMovie, CurrentUserId);
        }

        public string Title => CurrentMovie.Title;
        public string Description => "Opis: " + CurrentMovie.Description;
        public ImageSource Poster => CurrentMovie.Poster;
        public string ReleaseYear => "Rok wydania: " + CurrentMovie.ReleaseYear;
        public string Length => "Czas trwania: " + CurrentMovie.Length;
        public string Actors => "Obsada: " + ActorsListToString();
        public string Directors => "Reżyserzy: " + DirectorsListToString();
        public string Genres => "Gatunki: " + Model.GetMovieGenres(CurrentMovie);

        public string Awards => "Przyznane nagrody: " + Model.GetMovieAwards(CurrentMovie);
        public string ActorsListToString()
        {
            string result = String.Empty;
            if(CurrentActors.Count == 0)
            {
                return "Brak danych";
            }
            else
            {
                for (int i = 0; i < CurrentActors.Count; i++)
                {
                    if (i != CurrentActors.Count - 1)
                    {
                        result += CurrentActors[i].Name;
                        result += " ";
                        result += CurrentActors[i].Surname;
                        result += ", ";
                    }
                    else
                    {
                        result += CurrentActors[i].Name;
                        result += " ";
                        result += CurrentActors[i].Surname;
                    }
                }
                return result;
            }
        }

        public string DirectorsListToString()
        {
            string result = String.Empty;
            if (CurrentDirectors.Count == 0)
            {
                return "Brak danych";
            }
            else
            {
                for (int i = 0; i < CurrentDirectors.Count; i++)
                {
                    if (i != CurrentDirectors.Count - 1)
                    {
                        result += CurrentDirectors[i].Name;
                        result += " ";
                        result += CurrentDirectors[i].Surname;
                        result += ", ";
                    }
                    else
                    {
                        result += CurrentDirectors[i].Name;
                        result += " ";
                        result += CurrentDirectors[i].Surname;
                    }
                }
                return result;
            }
        }
        private ICommand back;

        public ICommand Back => back ?? (back = new RelayCommand(
            o =>
            {
                NavigationModel.ChangeVM(new MoviesViewModel(Model, NavigationModel, CurrentUserId));
            }, null
            ));

        private ICommand updateRatio;

        public ICommand UpdateRatio => updateRatio ?? (updateRatio = new RelayCommand(
            o =>
            {
                Model.UpdateAddGrade(CurrentMovie.IDmovie, CurrentUserId, int.Parse(CurretUserRatio.ToString()));
                Model.GetMoviesRatio();
                CurrentRating = Model.GetMovieRatio(CurrentMovie);
            }, null
            ));
    }
}
