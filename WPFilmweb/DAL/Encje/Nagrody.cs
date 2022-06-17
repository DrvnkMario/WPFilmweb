using MySql.Data.MySqlClient;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace WPFilmweb.DAL.Encje
{
    class Nagrody
    {
        #region Properties

        public int? IDAward { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageSource AwardImage { get; set; }

        #endregion

        #region Constructors
        // MySqlDataReader constructor - creates object based on MySql data
        public Nagrody(MySqlDataReader reader)
        {
            IDAward = int.Parse(reader["IDnagrody"].ToString());
            Name = reader["nazwa"].ToString();
            Description = reader["opis_nagrody"].ToString();

            BitmapImage temp = new BitmapImage();
            MemoryStream ms = new MemoryStream((byte[])reader["zdjecie"]);
            if (ms.Length > 0)
            {
                temp.BeginInit();
                temp.StreamSource = ms;
                temp.EndInit();
                AwardImage = temp as ImageSource;
            }
            else
            {
                AwardImage = null;
            }
        }

        // New object created from scratch, to add into database
        public Nagrody(string name, string description, ImageSource image)
        {
            IDAward = null;
            Name = name;
            Description = description;
            AwardImage = image;
        }

        // Copy ctor
        public Nagrody(Nagrody award)
        {
            IDAward = award.IDAward;
            Name = award.Name;
            Description = award.Description;
            AwardImage = award.AwardImage;
        }
        #endregion

        #region Methods
        public string ToInsert()
        {
            return $"'{Name}','{Description}','{AwardImage}'";
        }
        // Override Equals method to check if actor is not duplicated with Contains function
        public override bool Equals(object obj)
        {
            Nagrody Award = obj as Nagrody;
            if (Award == null) return false;
            if (Award.Name.ToLower() != Name.ToLower()) return false;
            if(Award.Description.ToLower() != Description.ToLower()) return false;
            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
