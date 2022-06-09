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
    using DAL.Encje;
    internal class MovieDescriptionViewModel : ViewModelBase
    {

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

        public MovieDescriptionViewModel(Filmy movie)
        {
            CurrentMovie = movie;
        }

        public string Title => CurrentMovie.Title;
        public string Description => "Opis: " + CurrentMovie.Description;
        public ImageSource Poster => CurrentMovie.Poster;
        public string ReleaseYear => "Rok wydania: " + CurrentMovie.ReleaseYear;
        public string Length => "Czas trwania: " + CurrentMovie.Length;


    }
}
