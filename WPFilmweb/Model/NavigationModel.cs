using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFilmweb.ViewModel.BaseClasses;
namespace WPFilmweb.Model
{
    public class NavigationModel : ViewModelBase
    {
        private ViewModelBase currentViewModel {get; set;}
        public ViewModelBase CurrentViewModel 
        { 
            get { return currentViewModel; }
            set 
            { 
                currentViewModel = value; 
                onPropertyChanged(nameof(CurrentViewModel));
            } 
        }
        public void ChangeVM(ViewModelBase vm)
        {
            CurrentViewModel = vm;
        }
    }
}
