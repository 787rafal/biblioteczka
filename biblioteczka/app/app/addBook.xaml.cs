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

                cmd.Parameters.AddWithValue("@t", tytul);
                cmd.Parameters.AddWithValue("@p", btn_img.Content);
                cmd.Parameters.AddWithValue("@d", date);
                cmd.Parameters.AddWithValue("@a", autor[0]);
                cmd.Parameters.AddWithValue("@g", gatunek[0]);

                cmd.ExecuteNonQuery();

                this.Close();

                MainWindow._instance.loadData();

            }

        }

        private void hide1(object sender, KeyEventArgs e)
        {
            title.Visibility = Visibility.Hidden;
        }

        private void hide3(object sender, KeyEventArgs e)
        {
            date.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            bool? response = dlg.ShowDialog();

            if(response == true)
            {
                string filepath = dlg.FileName;
                int location = filepath.LastIndexOf(@"\", StringComparison.OrdinalIgnoreCase);
                string filename = filepath.Substring(location);
                string final_name = "";
                for(int i = 1; i < filename.Length; i++)
                {
                    final_name += filename[i];
                }
                if (!File.Exists("C:/Users/komputer/Desktop/git/biblioteczka/biblioteczka/app/app/" + final_name))
                {
                    File.Copy(filepath, "C:/Users/komputer/Desktop/git/biblioteczka/biblioteczka/app/app/" + final_name);
                }
                btn_img.Content = final_name;
            }

        }
    }
}
