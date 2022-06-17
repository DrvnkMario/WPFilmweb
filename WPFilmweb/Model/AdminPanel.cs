using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFilmweb.Model
{
    using DAL.Encje;
    using DAL.Repozytoria;
    internal class AdminPanel
    {
        public AdminPanel()
        {
            
        }
        public void AddMovie(string title, int releaseYear, string length, string description)
        {
            Filmy movie = new Filmy(title,releaseYear, length, description);
            RepozytoriumFilmy.AddMovie(movie);
        }

        public void AddActor(string name, string surname, string dateOfBirth, string bio)
        {
            Aktorzy actor = new Aktorzy(name,surname,dateOfBirth,bio,null);
            RepozytoriumAktorzy.AddActor(actor);
        }
    }
}
