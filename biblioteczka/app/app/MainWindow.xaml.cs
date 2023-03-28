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
using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace app
{

    public partial class MainWindow : Window
    {
        public static MainWindow _instance;
        public int error { get; set; }
        public int author { get; set; }

        public MainWindow()
        {


            _instance = this;
            InitializeComponent();
            Loaded += load;
            this.error = 0;


            var database = new database();
            if (database.connect_db())
            {

                string query2 = "SELECT * FROM genres";
                MySqlCommand cmd2 = new MySqlCommand(query2, database.sql);
                MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                    selectGenres.Items.Add(dataReader2["name_genre"]);
                }
                dataReader2.Close();

            }

            status1.Content = "TITLE";
            status2.Content = "AUTHOR";

        }


        private void przeciagnij(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void close_btn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void min_btn(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void loadData()
        {

            var database = new database();
            if (database.connect_db())
            {                
                string query = "SELECT * FROM books JOIN authors ON author_id = id_author JOIN genres ON genre_id = id_genres ORDER BY id_book;";

                ksiazki.wyswietl(query, database, kafelki);

                database.close_db();
   
            }
           
        }

        private void load(object sender, EventArgs e)
        {
            loadData();
        }

        public void deleteRow(object sender, RoutedEventArgs e)
        {
            Button button = (Button)e.OriginalSource;
            string id = button.Tag.ToString();
            string file = "";

            var conn2 = new database();
            if (conn2.connect_db())
            {
                string zap2 = "SELECT * FROM books WHERE id_book = @i";
                
                MySqlCommand cmd2 = new MySqlCommand(zap2, conn2.sql);
                cmd2.Parameters.AddWithValue("@i", id);
                MySqlDataReader dataReader = cmd2.ExecuteReader();
                while (dataReader.Read())
                {
                    file = dataReader["image"].ToString();
                }
                
                dataReader.Close();
            }
            conn2.close_db();

            var conn = new database();
            if (conn.connect_db())
            {
                string zap = "DELETE FROM books WHERE id_book = @i";
                MySqlCommand cmd = new MySqlCommand(zap, conn.sql);
                cmd.Parameters.AddWithValue("@i", id);
                cmd.ExecuteNonQuery();
            }
            conn.close_db();
            szukaj();
            File.Delete(System.IO.Directory.GetCurrentDirectory() + file);



        }


        private void add_book(object sender, RoutedEventArgs e)
        {
            addBook dodaj = new addBook();
            dodaj.Show();
            this.Hide();
        }

        private void newAuthor_Click(object sender, RoutedEventArgs e)
        {
            addAuthor autor = new addAuthor();
            autor.Show();
            this.author = 0;
            this.Hide();
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            selectGenres.SelectedIndex = 0;
            SearchedText.Text = "";
            status1.IsChecked = true;
            status2.IsChecked = false;
            szukaj();
        }

        private void searchChange(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SearchedText.Text))
            {
                SearchPlaceholder.Visibility = Visibility.Hidden;
            }
            else
            {
                SearchPlaceholder.Visibility = Visibility.Visible;
            }

            szukaj();

        }

        private void szukaj()
        {

            string gen = selectGenres.Text;
            string szukaj = SearchedText.Text;
            string radio = "";

            if (status1.IsChecked == true)
            {
                radio = "TITLE";
            }
            else if (status2.IsChecked == true)
            {
                radio = "AUTHOR";
            }
            else
            {
                radio = "";
            }


            var database = new database();
            if (database.connect_db())
            {
                string query = "";

                if (gen == "None" || gen == "GENRES:")
                {
                    if (szukaj == "")
                    {
                        query = "SELECT * FROM books JOIN authors ON author_id = id_author JOIN genres ON genre_id = id_genres ORDER BY id_book;";
                    }
                    else if (radio == "AUTHOR")
                    {
                        query = "SELECT * FROM books JOIN authors ON author_id = id_author JOIN genres ON genre_id = id_genres WHERE concat(name,' ',last_name) LIKE '%"+ szukaj +"%' ORDER BY id_book;";
                    }
                    else if (radio == "TITLE")
                    {
                        query = "SELECT * FROM books JOIN authors ON author_id = id_author JOIN genres ON genre_id = id_genres WHERE TITLE LIKE '" + szukaj + "%' OR TITLE LIKE '%" + szukaj + "%' OR TITLE LIKE '%" + szukaj + "' ORDER BY id_book;";
                    }
                }
                else if (gen != "None" && gen != "GENRES")
                {
                    if (szukaj == "")
                    {
                        query = "SELECT * FROM books JOIN authors ON author_id = id_author JOIN genres ON genre_id = id_genres WHERE name_genre = '" + gen + "' ORDER BY id_book;";
                    }
                    else if (radio == "AUTHOR")
                    {
                        query = "SELECT * FROM books JOIN authors ON author_id = id_author JOIN genres ON genre_id = id_genres WHERE name_genre = '" + gen + "' AND concat(name,' ',last_name) LIKE '%"+ szukaj +"%' ORDER BY id_book;";
                    }
                    else if (radio == "TITLE")
                    {
                        query = "SELECT * FROM books JOIN authors ON author_id = id_author JOIN genres ON genre_id = id_genres WHERE name_genre = '" + gen + "' AND (TITLE LIKE '" + szukaj + "%' OR TITLE LIKE '%" + szukaj + "%' OR TITLE LIKE '%" + szukaj + "') ORDER BY id_book;";
                    }
                }

                ksiazki.wyswietl(query, database, kafelki);

                database.close_db();

            }

        }


        public void buttonRadius()
        {
            Panel mainContainer = (Panel)this.scroll.Content;
            UIElementCollection element = mainContainer.Children;
            List<DependencyObject> lstElement = element.Cast<DependencyObject>().ToList();
            Button[] btns = lstElement.OfType<Button>().ToArray();

            foreach (Button btn in btns)
            {
                btn.Style = (Style)FindResource("RoundedButtonStyle");
            }
        }

        private void dynamicSearch(object sender, EventArgs e)
        {
            szukaj();
        }

        private void dynamicSearch(object sender, RoutedEventArgs e)
        {
            szukaj();
        }
    }
}
