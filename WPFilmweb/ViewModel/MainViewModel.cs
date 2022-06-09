using System;
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
        private ViewModelBase currentViewModel { get; set; }
        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                onPropertyChanged(nameof(CurrentViewModel));
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
                Console.WriteLine("TEST");
                //if (searchbarText == string.Empty)
                //{
                //    moviesPanel.Model.RefreshMovies(moviesPanel.Movies, moviesPanel.CurrentPage);
                //}
                //else if (SelectedItem == "Movies")
                //{
                //}
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
            //CurrentViewModel = new MoviesViewModel();
            MoviesViewModel temp = new MoviesViewModel();
            CurrentViewModel = new MovieDescriptionViewModel(temp.Movies[0]);
            welcomeText = "Welcome to MVVM movies!";
            ComboContent = new List<string>()
            {   "Movies",
                "Actors",
                "Directors" };
            SelectedItem = ComboContent[0];
        }
        #endregion

        #region Commands
        private ICommand changePage { get; set; }
        public ICommand ChangePage => changePage ?? (changePage = new RelayCommand(
            o =>
            {
                //CurrentViewModel = new MovieDescriptionViewModel();
            }, null
            ));
        #endregion
    }
}
