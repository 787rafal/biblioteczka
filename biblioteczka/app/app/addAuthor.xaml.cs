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
using MySql.Data.MySqlClient;

namespace app
{
  
    public partial class addAuthor : Window
    {
        public addAuthor()
        {
            InitializeComponent();
        }

        private void przeciagnij(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void close_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow._instance.loadData();
            MainWindow._instance.Show();
        }

        private void min_btn(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }


        private void add_autor(object sender, RoutedEventArgs e)
        {

            var conn = new database();

            if (conn.connect_db())
            {

                string imie = SearchedText2.Text;
                string nazwisko = SearchedText1.Text;

                string zap = "INSERT INTO authors (name, last_name) VALUES (@i, @l)";

                MySqlCommand cmd = new MySqlCommand(zap, conn.sql);

                cmd.Parameters.AddWithValue("@i", imie);
                cmd.Parameters.AddWithValue("@l", nazwisko);

                cmd.ExecuteNonQuery();

                this.Close();

                MainWindow._instance.loadData();

                MainWindow._instance.Show();

            }

        }

        private void lastNameChange(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchedText1.Text))
            {
                sname.Visibility = Visibility.Hidden;
            }
            else
            {
                sname.Visibility = Visibility.Visible;
            }
        }

        private void firstNameChange(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchedText2.Text))
            {
                name.Visibility = Visibility.Hidden;
            }
            else
            {
                name.Visibility = Visibility.Visible;
            }
        }

    }
}
