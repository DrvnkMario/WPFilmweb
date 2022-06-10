using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFilmweb.ViewModel.BaseClasses;
using System.Windows.Media;
using System.Collections.ObjectModel;
namespace WPFilmweb.ViewModel
{
    using Model;
    using DAL.Encje;
    internal class MovieDescriptionViewModel : ViewModelBase
    {
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

        public MovieDescriptionViewModel(Filmy movie, ObservableCollection<Aktorzy> actors, ObservableCollection<Rezyserzy> director)
        {
            Model = new Model();
            CurrentMovie = movie;
            CurrentActors = actors;
            CurrentActors = Model.GetActorsFromMovie(movie);
            CurrentDirectors = director;
            CurrentDirectors = Model.GetDirectorsFromMovie(movie);

        }

        public string Title => CurrentMovie.Title;
        public string Description => "Opis: " + CurrentMovie.Description;
        public ImageSource Poster => CurrentMovie.Poster;
        public string ReleaseYear => "Rok wydania: " + CurrentMovie.ReleaseYear;
        public string Length => "Czas trwania: " + CurrentMovie.Length;
        public string Actors => "Obsada: " + ActorsListToString();
        public string Directors => "Reżyserzy: " + DirectorsListToString();

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
    }
}
