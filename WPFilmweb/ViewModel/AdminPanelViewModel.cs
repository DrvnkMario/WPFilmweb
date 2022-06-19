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
    
    internal class AdminPanelViewModel : ViewModelBase
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


        #region MovieProperties

        private string movieTitle { get; set; }

        public string MovieTitle
        {
            get { return movieTitle; }
            set
            {
                movieTitle = value;
                onPropertyChanged(nameof(MovieTitle));
            }
        }

        private string movieReleaseYear { get; set; }

        public string MovieReleaseYear
        {
            get { return movieReleaseYear; }
            set
            {
                movieReleaseYear = value;
                onPropertyChanged(nameof(MovieReleaseYear));
            }
        }

        private string movieLength { get; set; }

        public string MovieLength
        {
            get { return movieLength; }
            set
            {
                movieLength = value;
                onPropertyChanged(nameof(MovieLength));
            }
        }

        private string movieDescription { get; set; }

        public string MovieDescription
        {
            get { return movieDescription; }
            set
            {
                movieDescription = value;
                onPropertyChanged(nameof(MovieDescription));
            }
        }

        #endregion

        #region ActorsProperties

        private string actorName { get; set; }

        public string ActorName
        {
            get { return actorName; }
            set
            {
                actorName = value;
                onPropertyChanged(nameof(ActorName));
            }
        }

        private string actorSurname { get; set; }

        public string ActorSurname
        {
            get { return actorSurname; }
            set
            {
                actorSurname = value;
                onPropertyChanged(nameof(ActorSurname));
            }
        }

        private string actorDateOfBirth { get; set; }

        public string ActorDateOfBirth
        {
            get { return actorDateOfBirth; }
            set
            {
                actorDateOfBirth = value;
                onPropertyChanged(nameof(ActorDateOfBirth));
            }
        }

        private string actorBio { get; set; }

        public string ActorBio
        {
            get { return actorBio; }
            set
            {
                actorBio = value;
                onPropertyChanged(nameof(ActorBio));
            }
        }

        #endregion

        #region DirectorProperties

        private string directorName { get; set; }

        public string DirectorName
        {
            get { return directorName; }
            set
            {
                directorName = value;
                onPropertyChanged(nameof(DirectorName));
            }
        }

        private string directorSurname { get; set; }

        public string DirectorSurname
        {
            get { return directorSurname; }
            set
            {
                directorSurname = value;
                onPropertyChanged(nameof(DirectorSurname));
            }
        }

        private string directorDateOfBirth { get; set; }

        public string DirectorDateOfBirth
        {
            get { return directorDateOfBirth; }
            set
            {
                directorDateOfBirth = value;
                onPropertyChanged(nameof(DirectorDateOfBirth));
            }
        }

        private string directorBio { get; set; }

        public string DirectorBio
        {
            get { return directorBio; }
            set
            {
                directorBio = value;
                onPropertyChanged(nameof(DirectorBio));
            }
        }

        #endregion

        public AdminPanelViewModel(Model m, NavigationModel navimodel)
        {
            NavigationModel = navimodel;
            Model = m;
        }

        private ICommand addMovie;

        public ICommand AddMovie => addMovie ?? (addMovie = new RelayCommand(
            o =>
            {
                int i = 0;
                if(int.TryParse(MovieReleaseYear,out i) && MovieTitle != "" && MovieReleaseYear != "" && MovieLength != "")
                {
                    Model.AddMovie(MovieTitle,int.Parse(MovieReleaseYear), MovieLength, MovieDescription);
                    MovieReleaseYear = "";
                    MovieLength = "";
                    MovieTitle = "";
                    MovieDescription = "";
                }
            }, null
            ));

        private ICommand addActor;

        public ICommand AddActor => addActor ?? (addActor = new RelayCommand(
            o =>
            {
                if (ActorName != "" && ActorSurname != "" && ActorDateOfBirth != "" && ActorDateOfBirth.Contains('-'))
                {
                    Model.AddActor(ActorName, ActorSurname, ActorDateOfBirth, ActorBio);
                    ActorName = "";
                    ActorSurname = "";
                    ActorDateOfBirth = "";
                    ActorBio = "";
                }
            }, null
            ));

        private ICommand addDirector;

        public ICommand AddDirector => addDirector ?? (addDirector = new RelayCommand(
            o =>
            {
                if (DirectorName != "" && DirectorSurname != "" && DirectorDateOfBirth != "" && DirectorDateOfBirth.Contains('-'))
                {
                    Model.AddDirector(DirectorName, DirectorSurname, DirectorDateOfBirth, DirectorBio);
                    DirectorName = "";
                    DirectorSurname = "";
                    DirectorDateOfBirth = "";
                    DirectorBio = "";
                }

            }, null
            ));

        private ICommand nextPage;

        public ICommand NextPage => nextPage ?? (nextPage = new RelayCommand(
            o=>
            {
                NavigationModel.ChangeVM(new AdminPanel2ViewModel(Model, NavigationModel));
            },null));
    }
}
