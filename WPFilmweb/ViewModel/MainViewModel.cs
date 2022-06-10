﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows;
using System.Web;
namespace WPFilmweb.ViewModel
{
    using DAL.Encje;
    using DAL.Repozytoria;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using WPFilmweb.Model;
    using WPFilmweb.ViewModel.BaseClasses;
    using WPFilmweb.View;
    internal class MainViewModel : ViewModelBase
    {
        #region Properties
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
        private Model model { get ; set; }
        public Model Model 
        {
            get { return model; }
            set 
            {
                model = value; 
                onPropertyChanged(nameof(Model));
            }
        }
        private string welcomeText { get; set; }

        public string WelcomeText
        {
            get { return welcomeText; }
            set { welcomeText = value; }
        }

        private string searchbarText { get; set; }

        public string SearchbarText
        {
            get { return searchbarText; }
            set
            {
                searchbarText = value;
                onPropertyChanged(nameof(SearchbarText));
            }
        }
        private List<string> comboContent { get; set; }

        public List<string> ComboContent
        {
            get { return comboContent; }
            set
            {
                comboContent = value;
            }
        }
        private string selectedItem { get; set; }

        public string SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; }
        }
        #endregion

        #region Constructors 
        public MainViewModel()
        {
            Model = new Model();
            NavigationModel = new NavigationModel();
            NavigationModel.ChangeVM(new MoviesViewModel(Model, NavigationModel));
            welcomeText = "Welcome to MVVM movies!";
            ComboContent = new List<string>()
            {   "Movies",
                "Actors",
                "Directors" };
            SelectedItem = ComboContent[0];
        }
        #endregion
    }
}
