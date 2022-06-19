﻿using System;
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
    internal class ActorDescriptionViewModel : ViewModelBase
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
        private Aktorzy currentActor;

        public Aktorzy CurrentActor
        {
            get
            {
                return currentActor;
            }
            set
            {
                currentActor = value;
                onPropertyChanged(nameof(CurrentActor));
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

        public ActorDescriptionViewModel(Aktorzy actor, ObservableCollection<Filmy> movies, NavigationModel navi, Model model)
        {
            Model = model;
            CurrentActor = actor;
            CurrentMovies = movies;
            CurrentMovies = Model.GetMoviesFromActor(actor);
            NavigationModel = navi;
        }

        public string NameSurname => CurrentActor.Name + " " + CurrentActor.Surname;
        public string Bio => "Biografia: " + CurrentActor.Bio;
        public ImageSource ActorImage => CurrentActor.ActorImage;
        public string BirthDate => "Data Urodzenia: " + BirthDateToString();
        public string Movies => "Zagrał w: " + MoviesListToString();

        public string BirthDateToString()
        {
            string result = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                result += CurrentActor.BirthDate.ToString()[i];
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
                NavigationModel.ChangeVM(new ActorsViewModel(Model, NavigationModel));
            }, null
            ));
    }
}
