using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public static kalendarz _instance4;
        public kalendarz()
        {
            _instance4 = this;
            InitializeComponent();
        }


        private void close(object sender, RoutedEventArgs e)
        {
            addBook._instance2.kalendarz_active = false;
            addBook._instance2.IsEnabled = true;
            this.Close();
            _instance4 = null;
        }

        private void zapisz(object sender, RoutedEventArgs e)
        {

            string date1 = cal.SelectedDate.ToString();
            string date2 = DateTime.Now.AddDays(14).ToString("dd/MM/yyyy");


            if ( (!String.IsNullOrEmpty(date1)) && (DateTime.Parse(date1) > DateTime.Parse(date2)))
            {
                error blad = new error();
                blad.Show();
                this.Hide();
            }
            else
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
                addBook._instance2.kalendarz_active = false;
                addBook._instance2.IsEnabled = true;
                this.Close();
                _instance4 = null;
            }

        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            _instance4 = null;
            addBook._instance2.kalendarz_active = false;
            addBook._instance2.IsEnabled = true;
        }
    }
}
