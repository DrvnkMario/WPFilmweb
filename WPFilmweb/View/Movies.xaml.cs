using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace WPFilmweb.View
{
    /// <summary>
    /// Logika interakcji dla klasy Movies.xaml
    /// </summary>
    public partial class Movies : UserControl
    {
        public Movies()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty Title1Property =
             DependencyProperty.Register(
                 nameof(Title1),
                 typeof(string),
                 typeof(Movies)
                 );

        public string Title1
        {
            get { return (string)GetValue(Title1Property); }
            set { SetValue(Title1Property, value); }
        }

        public static readonly DependencyProperty Poster1Property =
             DependencyProperty.Register(
                 nameof(Poster1),
                 typeof(ImageSource),
                 typeof(Movies)
                 );

        public ImageSource Poster1
        {
            get { return (ImageSource)GetValue(Poster1Property); }
            set { SetValue(Poster1Property, value); }
        }



        public static readonly DependencyProperty Title2Property =
             DependencyProperty.Register(
                 nameof(Title2),
                 typeof(string),
                 typeof(Movies)
                 );

        public string Title2
        {
            get { return (string)GetValue(Title2Property); }
            set { SetValue(Title2Property, value); }
        }

        public static readonly DependencyProperty Poster2Property =
             DependencyProperty.Register(
                 nameof(Poster2),
                 typeof(ImageSource),
                 typeof(Movies)
                 );

        public ImageSource Poster2
        {
            get { return (ImageSource)GetValue(Poster2Property); }
            set { SetValue(Poster2Property, value); }
        }

        public static readonly DependencyProperty Title3Property =
             DependencyProperty.Register(
                 nameof(Title3),
                 typeof(string),
                 typeof(Movies)
                 );

        public string Title3
        {
            get { return (string)GetValue(Title3Property); }
            set { SetValue(Title3Property, value); }
        }

        public static readonly DependencyProperty Poster3Property =
             DependencyProperty.Register(
                 nameof(Poster3),
                 typeof(ImageSource),
                 typeof(Movies)
                 );

        public ImageSource Poster3
        {
            get { return (ImageSource)GetValue(Poster3Property); }
            set { SetValue(Poster3Property, value); }
        }


        public static readonly DependencyProperty Title4Property =
             DependencyProperty.Register(
                 nameof(Title4),
                 typeof(string),
                 typeof(Movies)
                 );

        public string Title4
        {
            get { return (string)GetValue(Title1Property); }
            set { SetValue(Title1Property, value); }
        }

        public static readonly DependencyProperty Poster4Property =
             DependencyProperty.Register(
                 nameof(Poster4),
                 typeof(ImageSource),
                 typeof(Movies)
                 );

        public ImageSource Poster4
        {
            get { return (ImageSource)GetValue(Poster1Property); }
            set { SetValue(Poster1Property, value); }
        }

        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(
                nameof(CurrentPage),
                typeof(int),
                typeof(Movies)
                );

        public int CurrentPage
        {
            get { return (int)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        public static readonly RoutedEvent evNext_Page =
            EventManager.RegisterRoutedEvent(
                nameof(evNext_Page_handler),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(Movies));

        public event RoutedEventHandler evNext_Page_handler 
        {
            add {AddHandler(evNext_Page, value); }
            remove{ RemoveHandler(evNext_Page, value); }
        }   

        private void Next_Page(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Movies.evNext_Page);
            RaiseEvent(newEventArgs);
        }


        public static readonly RoutedEvent evPrevious_Page =
            EventManager.RegisterRoutedEvent(
                nameof(evPrevious_Page_handler),
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(Movies));

        public event RoutedEventHandler evPrevious_Page_handler
        {
            add { AddHandler(evPrevious_Page, value); }
            remove { RemoveHandler(evPrevious_Page, value); }
        }

        private void Previous_Page(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Movies.evPrevious_Page);
            RaiseEvent(newEventArgs);
        }


        public static readonly RoutedEvent evMovie_Click =
           EventManager.RegisterRoutedEvent(
               nameof(evMovie_Click_handler),
               RoutingStrategy.Bubble,
               typeof(RoutedEventHandler),
               typeof(Movies));

        public event RoutedEventHandler evMovie_Click_handler
        {
            add { AddHandler(evMovie_Click, value); }
            remove { RemoveHandler(evMovie_Click, value); }
        }

        private void Movie_Click(object sender, RoutedEventArgs e)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Movies.evMovie_Click);
            RaiseEvent(newEventArgs);
        }
    }
}
