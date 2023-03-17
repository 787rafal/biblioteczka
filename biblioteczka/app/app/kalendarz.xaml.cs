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
    /// Logika interakcji dla klasy kalendarz.xaml
    /// </summary>
    public partial class kalendarz : Window
    {
        public kalendarz()
        {
            InitializeComponent();
        }

        private void mini(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void przeciagnij2(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void zapisz(object sender, RoutedEventArgs e)
        {
            var date = "";
            if (cal.SelectedDate == null)
            {
                date = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                date = cal.SelectedDate.Value.Date.ToString("dd/MM/yyyy");
            }
            addBook._instance2.pub_date.Content = date;
            this.Close();

        }
    }
}
