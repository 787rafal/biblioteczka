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
        }

        private void min_btn(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void hide1(object sender, KeyEventArgs e)
        {
            name.Visibility = Visibility.Hidden;
        }

        private void hide2(object sender, KeyEventArgs e)
        {
            sname.Visibility = Visibility.Hidden;
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

            }

        }
    }
}
