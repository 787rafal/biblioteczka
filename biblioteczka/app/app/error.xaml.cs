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
using System.Windows.Shapes;

namespace app
{
    /// <summary>
    /// Logika interakcji dla klasy error.xaml
    /// </summary>
    public partial class error : Window
    {
        public error()
        {
            InitializeComponent();
            zamiana.TextAlignment = TextAlignment.Center;
            zamiana2.TextAlignment = TextAlignment.Center;

            
            zamiana.Text = "INVALID DATA";
            zamiana2.Text = "TRY ONE MORE TIME!";

            if(MainWindow._instance.error == 1)
            {
                zamiana.Text = "FILE EXIST";
                zamiana2.Text = "CHANGE NAME!";
            }
            else if (MainWindow._instance.error == 2)
            {
                zamiana.Text = "AUTHOR EXISTS!";
                zamiana2.Text = "";
            }
            else if (MainWindow._instance.error == 3)
            {
                zamiana.Text = "BAD FILE EXTENSION!";
                zamiana2.Text = "Only .JPG or .PNG";
            }

        }

        private void drag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (addAuthor._instance3 != null)
            {
                addAuthor._instance3.Show();
            }
            else if (addBook._instance2 != null)
            {
                addBook._instance2.Show();
            }
            if(kalendarz._instance4 != null)
            {
                kalendarz._instance4.Show();
            }
        }
    }
}
