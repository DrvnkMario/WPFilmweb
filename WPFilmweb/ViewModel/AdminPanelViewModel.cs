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

        private ObservableCollection<string> selectedActors { get; set; }

        public ObservableCollection<string> SelectedActors
        {
            get { return selectedActors; }
            set
            {
                selectedActors = value;
                onPropertyChanged(nameof(SelectedActors));
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

        #region Award properties
        private string awardDescription { get; set; }

        public string AwardDescription
        {
            get { return awardDescription; }
            set
            {
                awardDescription = value;
                onPropertyChanged(nameof(AwardDescription));
            }
        }

        private string awardName { get; set; }

        public string AwardName
        {
            get { return awardName; }
            set
            {
                awardName = value;
                onPropertyChanged(nameof(AwardName));
            }
        }
        
        #endregion

        private ObservableCollection<string> movieTitles { get; set; }
        public ObservableCollection<string> MovieTitles
        {
            get { return movieTitles; }
            set
            {
                movieTitles = value;
                onPropertyChanged(nameof(MovieTitles));
            }
        }

        private ObservableCollection<string> actorNames { get; set; }
        public ObservableCollection<string> ActorNames
        {
            get { return actorNames; }
            set
            {
                actorNames = value;
                onPropertyChanged(nameof(ActorNames));
            }
        }



        private ObservableCollection<string> directorNames { get; set; }
        public ObservableCollection<string> DirectorNames
        {
            get { return directorNames; }
            set
            {
                directorNames = value;
                onPropertyChanged(nameof(DirectorNames));
            }
        }

        private int movieIndex { get; set; }
        public int MovieIndex
        {
            get { return movieIndex; }
            set
            {
                movieIndex = value;
                onPropertyChanged(nameof(MovieIndex));
            }
        }

        private int actorIndex { get; set; }
        public int ActorIndex
        {
            get { return actorIndex; }
            set
            {
                actorIndex = value;
                onPropertyChanged(nameof(ActorIndex));
            }
        }

        private Aktorzy selectedActor { get; set; }
        public Aktorzy SelectedActor
        {
            get { return selectedActor; }
            set
            {
                selectedActor = value;
                onPropertyChanged(nameof(SelectedActor));
            }
        }
        private ObservableCollection<Aktorzy> actorsToAdd { get; set; }
        public ObservableCollection<Aktorzy> ActorsToAdd
        {
            get { return actorsToAdd; }
            set
            {
                actorsToAdd = value;
                onPropertyChanged(nameof(ActorsToAdd));
            }
        }

        private ObservableCollection<Aktorzy> castActors { get; set; }
        public ObservableCollection<Aktorzy> CastActors
        {
            get { return castActors; }
            set
            {
                castActors = value;
                onPropertyChanged(nameof(CastActors));
            }
        }

        private int directorIndex { get; set; }
        public int DirectorIndex
        {
            get { return directorIndex; }
            set
            {
                directorIndex = value;
                onPropertyChanged(nameof(DirectorIndex));
            }
        }

        private Rezyserzy selectedDirector { get; set; }
        public Rezyserzy SelectedDirector
        {
            get { return selectedDirector; }
            set
            {
                selectedDirector = value;
                onPropertyChanged(nameof(SelectedDirector));
            }
        }
        private ObservableCollection<Rezyserzy> directorsToAdd { get; set; }
        public ObservableCollection<Rezyserzy> DirectorsToAdd
        {
            get { return directorsToAdd; }
            set
            {
                directorsToAdd = value;
                onPropertyChanged(nameof(DirectorsToAdd));
            }
        }

        private ObservableCollection<Rezyserzy> movieDirectors { get; set; }
        public ObservableCollection<Rezyserzy> MovieDirectors
        {
            get { return movieDirectors; }
            set
            {
                movieDirectors = value;
                onPropertyChanged(nameof(MovieDirectors));
            }
        }
        // --------------------------------------------------------------------------

        private Nagrody selectedAward { get; set; }
        public Nagrody SelectedAward
        {
            get { return selectedAward; }
            set
            {
                selectedAward = value;
                onPropertyChanged(nameof(SelectedAward));
            }
        }
        private ObservableCollection<Nagrody> awardToAdd { get; set; }
        public ObservableCollection<Nagrody> AwardToAdd
        {
            get { return awardToAdd; }
            set
            {
                awardToAdd = value;
                onPropertyChanged(nameof(AwardToAdd));
            }
        }

        private ObservableCollection<Nagrody> movieAward { get; set; }
        public ObservableCollection<Nagrody> MovieAward
        {
            get { return movieAward; }
            set
            {
                movieAward = value;
                onPropertyChanged(nameof(MovieAward));
            }
        }


        public AdminPanelViewModel(Model m, NavigationModel navimodel)
        {
            NavigationModel = navimodel;
            Model = m;
            MovieIndex = 0;
            MovieTitles = Model.MoviesTitles;
            DirectorNames = Model.DirectorNames;
            ActorNames = Model.ActorNames;
            

            Model.GetActors();
            ActorsToAdd = Model.ActorList;
            CastActors = new ObservableCollection<Aktorzy>();

            Model.GetDirectors();
            DirectorsToAdd = Model.DirectorsList;
            MovieDirectors = new ObservableCollection<Rezyserzy>();

            Model.GetAwards();
            AwardToAdd = Model.AwardList;
            MovieAward = new ObservableCollection<Nagrody>();
        }

        private ICommand addActorToList;

        public ICommand AddActorToList => addActorToList ?? (addActorToList = new RelayCommand(
            o =>
            {
                CastActors.Add(SelectedActor);
                ActorsToAdd.Remove(SelectedActor);
                
            }, null
            ));

        private ICommand resetActors;

        public ICommand ResetActors => resetActors ?? (resetActors = new RelayCommand(
            o =>
            {
                SelectedActor = null;
                CastActors.Clear();
                Model.GetActors();
                ActorsToAdd = Model.ActorList;
            }, null
            ));

        private ICommand addDirectorToList;

        public ICommand AddDirectorToList => addDirectorToList ?? (addDirectorToList = new RelayCommand(
            o =>
            {
                MovieDirectors.Add(SelectedDirector);
                DirectorsToAdd.Remove(SelectedDirector);

            }, null
            ));

        private ICommand resetDirectors;

        public ICommand ResetDirectors => resetDirectors ?? (resetDirectors = new RelayCommand(
            o =>
            {
                SelectedDirector = null;
                MovieDirectors.Clear();
                Model.GetAwards();
                AwardToAdd = Model.AwardList;
            }, null
            ));

        private ICommand addAwardToList;

        public ICommand AddAwardToList => addAwardToList ?? (addAwardToList = new RelayCommand(
            o =>
            {
                MovieAward.Add(SelectedAward);
                AwardToAdd.Remove(SelectedAward);

            }, null
            ));

        private ICommand resetAwards;

        public ICommand ResetAwards => resetAwards ?? (resetAwards = new RelayCommand(
            o =>
            {
                SelectedDirector = null;
                MovieAward.Clear();
                Model.GetAwards();
                AwardToAdd = Model.AwardList;
            }, null
            ));

        private ICommand addMovie;

        public ICommand AddMovie => addMovie ?? (addMovie = new RelayCommand(
            o =>
            {
                
                int i = 0;
                if (int.TryParse(MovieReleaseYear, out i) && MovieTitle != "" && MovieReleaseYear != "" && MovieLength != "")
                {
                    Model.AddMovie(MovieTitle, int.Parse(MovieReleaseYear), MovieLength, MovieDescription);

                    Filmy tempMovie = Model.FindMovieByTitle(MovieTitle);

                    for (int j= 0; j<CastActors.Count; j++)
                    {
                        Model.AddPlayIn(tempMovie.IDmovie, (int)CastActors[j].IDActor);
                    }

                    for (int j = 0; j < MovieDirectors.Count; j++)
                    {
                        Model.AddDirect(tempMovie.IDmovie, (int)MovieDirectors[j].IDDirector);
                    }

                    for (int j = 0; j < MovieAward.Count; j++)
                    {
                        Model.AddReward(tempMovie.IDmovie, (int)MovieAward[j].IDAward);
                    }


                    MovieReleaseYear = "";
                    MovieLength = "";
                    MovieTitle = "";
                    MovieDescription = "";

                    Model.GetActors();
                    Model.GetDirectors();
                    Model.GetAwards();

                    ActorsToAdd = Model.ActorList;
                    DirectorsToAdd = Model.DirectorsList;
                    AwardToAdd = Model.AwardList;

                    CastActors.Clear();
                    MovieDirectors.Clear();
                    MovieAward.Clear();
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

        private ICommand addAward;

        public ICommand AddAward => addAward ?? (addAward = new RelayCommand(
            o =>
            {
                if (AwardName != "" && AwardDescription != "")
                {
                    Model.AddAward(AwardName, AwardDescription);

                    AwardName = "";
                    AwardDescription = "";
                }

            }, null
            ));

        private ICommand deleteMovie;

        public ICommand DeleteMovie => deleteMovie ?? (deleteMovie = new RelayCommand(
            o =>
            {
                Model.DeleteMovie(MovieIndex);
                Model.GetMovies();
                Model.GetMovieTitles();
                MovieTitles = Model.MoviesTitles;
            }, null
            ));

        private ICommand deleteActor;

        public ICommand DeleteActor => deleteActor ?? (deleteActor = new RelayCommand(
            o =>
            {
                Model.DeleteActor(ActorIndex);
                Model.GetActors();
                Model.GetActorNames();
                ActorNames = Model.ActorNames;
            }, null
            ));

        private ICommand deleteDirector;

        public ICommand DeleteDirector => deleteDirector ?? (deleteDirector = new RelayCommand(
            o =>
            {
                Model.DeleteDirector(DirectorIndex);
                Model.GetDirectors();
                Model.GetDirectorNames();
                DirectorNames = Model.DirectorNames;
            }, null
            ));

        private ICommand addMovieImage;
        public ICommand AddMovieImage => addMovieImage ?? (addMovieImage = new RelayCommand(
            o=>
            {
                Model.GetImage();
            }, null
            )
            );
    }
}
