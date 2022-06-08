using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
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
        public MoviesViewModel moviesPanel { get; set; }

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
                if (searchbarText == string.Empty)
                {
                    moviesPanel.Model.RefreshMovies(moviesPanel.Movies, moviesPanel.CurrentPage);
                }else if(SelectedItem == "Movies")
                {

                }
                    

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
            moviesPanel = new MoviesViewModel();
            ComboContent = new List<string>() 
            {   "Movies",
                "Actors",
                "Directors" };
            SelectedItem = ComboContent[0];
        }
        #endregion

        #region Commands

        #endregion
    }
}
