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
                if(SelectedItem == "Movies")
                {
                    Model.GetMoviesByTitle(SearchbarText);
                    NavigationModel.ChangeVM(new MoviesViewModel(Model, NavigationModel, CurrentUserId));
                }
                else if (SelectedItem == "Actors")
                {
                    Model.GetActorsByName(SearchbarText);
                    NavigationModel.ChangeVM(new ActorsViewModel(Model, NavigationModel));
                }
                else if(SelectedItem == "Directors")
                {
                    Model.GetDirectorsByName(SearchbarText);
                    NavigationModel.ChangeVM(new DirectorsViewModel(Model,NavigationModel));
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
            get 
            { 
                return selectedItem; 
            }
            set 
            { 
                selectedItem = value;
                onPropertyChanged(nameof(SelectedItem));
                if(selectedItem == "Movies")
                {
                    NavigationModel.ChangeVM(new MoviesViewModel(Model, NavigationModel, CurrentUserId));
                }
                else if(selectedItem == "Actors")
                {
                    NavigationModel.ChangeVM(new ActorsViewModel(Model, NavigationModel));
                }
                else if(selectedItem == "Directors")
                {
                    NavigationModel.ChangeVM(new DirectorsViewModel(Model, NavigationModel));
                }
                SearchbarText = String.Empty;
            }
        }

        //tu dopisalem 

        private string comboVisibility { get; set; }

        public string ComboVisibility
        {
            get { return comboVisibility; }
            set
            {
                comboVisibility = value;
                onPropertyChanged(nameof(ComboVisibility));
            }
        }

        private string adminPanelVisibility { get; set; }

        public string AdminPanelVisibility
        {
            get { return adminPanelVisibility; }
            set
            {
                adminPanelVisibility = value;
                onPropertyChanged(nameof(AdminPanelVisibility));
            }
        }
        #endregion

        #region Constructors 
        public MainViewModel()
        {
            Model = new Model();
            NavigationModel = new NavigationModel();
            ComboContent = new List<string>()
            {   "Movies",
                "Actors",
                "Directors"
            };
            welcomeText = "Welcome to MVVM movies!";
            ComboVisibility = "Hidden";
            AdminPanelVisibility = "Hidden";
            //NavigationModel.ChangeVM(new MoviesViewModel(Model, NavigationModel));
            //ComboVisibility = "Visible";
        }

        //tu dopisalem
        private string currentUsername { get; set; }

        public string CurrentUsername
        {
            get { return currentUsername; }
            set
            {
                currentUsername = value;
                onPropertyChanged(nameof(CurrentUsername));
            }
        }
        private string currentPassword { get; set; }

        public string CurrentPassword
        {
            get { return currentPassword; }
            set
            {
                currentPassword = value;
                onPropertyChanged(nameof(CurrentPassword));
            }
        }

        private int currentUserId { get; set; }

        public int CurrentUserId
        {
            get { return currentUserId; }
            set
            {
                currentUserId = value;
                onPropertyChanged(nameof(CurrentUserId));
            }
        }

        private ICommand login;

        public ICommand Login => login ?? (login = new RelayCommand(
            o =>
            {
                for (int i = 0; i < Model.UsersList.Count; i++)
                {
                    if (Model.UsersList[i].Nickname == CurrentUsername && Model.UsersList[i].Password == CurrentPassword)
                    {
                        CurrentUserId = Model.UsersList[i].IDUser;
                        NavigationModel.ChangeVM(new MoviesViewModel(Model, NavigationModel, CurrentUserId));
                        SelectedItem = ComboContent[0];
                        ComboVisibility = "Visible";
                        AdminPanelVisibility = "Visible";
                    }
                }
            }, null));

        private ICommand logout;

        public ICommand Logout => logout ?? (logout = new RelayCommand(
            o =>
            {
                //NavigationModel.ChangeVM(new MainViewModel());
            }, null));
        #endregion
    }
}
