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
using System.Data;
using System.Diagnostics;
using System.IO;

namespace app
{
    /// <summary>
    /// Logika interakcji dla klasy addBook.xaml
    /// </summary>
    public partial class addBook : Window
    {
        ImageAdd newImage = new ImageAdd();
        public addBook()
        {
            InitializeComponent();

            var database = new database();
            if (database.connect_db())
            {

                string query = "SELECT * FROM authors;";
                string query2 = "SELECT * FROM genres;";
                MySqlCommand cmd = new MySqlCommand(query, database.sql);
                MySqlCommand cmd2 = new MySqlCommand(query2, database.sql);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    selectAuthor.Items.Add(reader["id_author"] + ". " + reader["name"] + " " + reader["last_name"]);
                }

                reader.Close();
                MySqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    selectGenre.Items.Add(reader2["id_genres"] + ". " + reader2["name_genre"]);
                }

            }

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void add_book(object sender, RoutedEventArgs e)
        {

            var conn = new database();

            if (conn.connect_db())
            {

                string tytul = SearchedText.Text;
                string autor = selectAuthor.Text;
                string gatunek = selectGenre.Text;
                string date = SearchedText3.Text;

                string zap = "INSERT INTO books (title, image, publication_date, author_id, genre_id) VALUES (@t, @p, @d, @a, @g)";

                MySqlCommand cmd = new MySqlCommand(zap, conn.sql);

                Trace.WriteLine(btn_img.Content.ToString());

                cmd.Parameters.AddWithValue("@t", tytul);
                cmd.Parameters.AddWithValue("@p", newImage.FileDatabaseName);
                cmd.Parameters.AddWithValue("@d", date);
                cmd.Parameters.AddWithValue("@a", autor[0]);
                cmd.Parameters.AddWithValue("@g", gatunek[0]);

                cmd.ExecuteNonQuery();

                newImage.ImageCopy();

                this.Close();

                MainWindow._instance.loadData();

                MainWindow._instance.Show();

            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush szary = new SolidColorBrush(Color.FromRgb(185, 185, 185));

            SolidColorBrush bialy = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            bool? response = dlg.ShowDialog();

            if(response == true)
            {
                newImage.Image(dlg.FileName);
                btn_img.Content = newImage.FileName;
            }

            if(btn_img.Content.ToString()  == "IMAGE...")
            {
                btn_img.Foreground = szary;
            }
            else
            {
                btn_img.Foreground = bialy;
            }

        }


        private void dateChange(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchedText3.Text))
            {
                date.Visibility = Visibility.Hidden;
            }
            else
            {
                date.Visibility = Visibility.Visible;
            }
        }


        private void titleChange(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchedText.Text))
            {
                title.Visibility = Visibility.Hidden;
            }
            else
            {
                title.Visibility = Visibility.Visible;
            }
        }
    }
}
