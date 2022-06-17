using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WPFilmweb.DAL.Encje;

namespace WPFilmweb.Model
{
    internal class Movies
    {
        public ObservableCollection<Filmy> MoviesList { get; set; } = new ObservableCollection<Filmy>();
        public ObservableCollection<string> MoviesVisibility { get; set; } = new ObservableCollection<string>();
    }
}
