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
    internal class DirectorDescriptionViewModel : ViewModelBase
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
        private Rezyserzy currentDirector;

        public Rezyserzy CurrentDirector
        {
            get
            {
                return currentDirector;
            }
            set
            {
                currentDirector = value;
                onPropertyChanged(nameof(CurrentDirector));
            }
        }

        private ObservableCollection<Filmy> currentMovies;

        public ObservableCollection<Filmy> CurrentMovies
        {
            get
            {
                return currentMovies;
            }
            set
            {
                currentMovies = value;
                onPropertyChanged(nameof(CurrentMovies));
            }
        }

        private string tempBirthDate;

        public string TempBirthDate
        {
            get { return tempBirthDate; }
            set { tempBirthDate = value; }
        }

        public DirectorDescriptionViewModel(Rezyserzy director, ObservableCollection<Filmy> movies, NavigationModel navi)
        {
            Model = new Model();
            CurrentDirector = director;
            CurrentMovies = movies;
            CurrentMovies = Model.GetMoviesFromDirector(director);
            NavigationModel = navi;
        }

        public string NameSurname => CurrentDirector.Name + " " + CurrentDirector.Surname;
        public string Bio => "Biografia: " + CurrentDirector.Bio;
        public ImageSource ActorImage => CurrentDirector.DirectorImage;
        public string BirthDate => "Data Urodzenia: " + BirthDateToString();
        public string Movies => "Wyreżyserował: " + MoviesListToString();

        public string BirthDateToString()
        {
            string result = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                result += CurrentDirector.Birthdate.ToString()[i];
            }
            return result;
        }
        public string MoviesListToString()
        {
            string result = String.Empty;
            if (CurrentMovies.Count == 0)
            {
                return "Brak danych";
            }
            else
            {
                for (int i = 0; i < CurrentMovies.Count; i++)
                {
                    if (i != CurrentMovies.Count - 1)
                    {
                        result += CurrentMovies[i].Title;
                        result += ", ";
                    }
                    else
                    {
                        result += CurrentMovies[i].Title;
                    }
                }
                return result;
            }
        }


        private ICommand back;

        public ICommand Back => back ?? (back = new RelayCommand(
            o =>
            {
                NavigationModel.ChangeVM(new DirectorsViewModel(Model, NavigationModel));
            }, null
            ));
    }
}
    

