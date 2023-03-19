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

        public bool kalendarz_active = false;
        ImageAdd newImage = new ImageAdd();
        public static addBook _instance2;

        public addBook()
        {
            InitializeComponent();

            _instance2 = this;

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
            _instance2 = null;  
        }

        private void min_btn(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void add_book(object sender, RoutedEventArgs e)
        {

            if ((SearchedText.Text.ToString() != "") && (selectAuthor.Text.ToString() != "AUTHORS:") && (selectGenre.Text.ToString() != "GENRES:") && (pub_date.Content.ToString() != "PUBLICATION DATE...") && (search_ISBN.Text.ToString() != "") && (search_HOUSE.Text.ToString() != "") && (btn_img.Content != "IMAGE...") && (search_ISBN.Text.Length == 10 || search_ISBN.Text.Length == 13)) {

                var conn = new database();

                if (conn.connect_db())
                {

                    string tytul = SearchedText.Text;
                    string autor = selectAuthor.Text;
                    string gatunek = selectGenre.Text;
                    string date = pub_date.Content.ToString();
                    string isbn = search_ISBN.Text;
                    string house = search_HOUSE.Text;

                    string zap = "INSERT INTO books (title, image, publication_date, isbn, publication_house, author_id, genre_id) VALUES (@t, @p, @d, @i, @h, @a, @g)";

                    MySqlCommand cmd = new MySqlCommand(zap, conn.sql);

                    cmd.Parameters.AddWithValue("@t", tytul);
                    cmd.Parameters.AddWithValue("@p", newImage.FileDatabaseName);
                    cmd.Parameters.AddWithValue("@d", date);
                    cmd.Parameters.AddWithValue("@i", isbn);
                    cmd.Parameters.AddWithValue("@h", house);
                    cmd.Parameters.AddWithValue("@a", autor[0]);
                    cmd.Parameters.AddWithValue("@g", gatunek[0]);

                    cmd.ExecuteNonQuery();
                    newImage.ImageCopy();
                    this.Close();
                    MainWindow._instance.loadData();
                    MainWindow._instance.Show();
                    _instance2 = null;

                }
            
            }else
            {
                error blad = new error();
                blad.Show();
                this.Hide();
            }

        }


        private void Image_Button_Click(object sender, RoutedEventArgs e)
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

            if (response == true)
            {

                var connect = new database();
                if (connect.connect_db())
                {

                    string qry = @"SELECT * FROM books WHERE image LIKE '%" + btn_img.Content.ToString() + "'";
                    MySqlCommand cmd = new MySqlCommand(qry, connect.sql);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds1 = new DataSet();
                    da.Fill(ds1);
                    int i = ds1.Tables[0].Rows.Count;

                    if (i > 0)
                    {
                        btn_img.Content = "IMAGE...";
                        MainWindow._instance.value = 1;
                        error blad = new error();
                        blad.Show();
                        this.Hide();
                    }

                }

            }

            MainWindow._instance.value = 0;

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

            if (SearchedText.Text.Length > 50)
            {
                error blad = new error();
                blad.Show();
                this.Hide();
                SearchedText.Text = "";
            }

        }

        private void isbnChange(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(search_ISBN.Text))
            {
                isbnPH.Visibility = Visibility.Hidden;
            }
            else
            {
                isbnPH.Visibility = Visibility.Visible;
            }

            foreach(char c in search_ISBN.Text)
            {
                if (!char.IsDigit(c))
                {
                    error blad = new error();
                    blad.Show();
                    this.Hide();
                    search_ISBN.Text = "";
                }
            }

            if(search_ISBN.Text.Length > 13)
            {
                error blad = new error();
                blad.Show();
                this.Hide();
                search_ISBN.Text = "";
            }

        }

        private void houseChange(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrEmpty(search_HOUSE.Text))
            {
                housePH.Visibility = Visibility.Hidden;
            }
            else
            {
                housePH.Visibility = Visibility.Visible;
            }

            foreach (char c in search_HOUSE.Text)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    error blad = new error();
                    blad.Show();
                    this.Hide();
                    search_HOUSE.Text = "";
                }
            }

            if(search_HOUSE.Text.Length > 50)
            {
                error blad = new error();
                blad.Show();
                this.Hide();
                search_HOUSE.Text = "";
            }

        }
        
        private void Date_Button_Click(object sender, RoutedEventArgs e)
        {

            if (!kalendarz_active)
            {
                kalendarz kal = new kalendarz();
                kal.Show();
                kalendarz_active = true;
                this.IsEnabled = false;
            }

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            MainWindow._instance.loadData();
            MainWindow._instance.Show();
            _instance2 = null;
        }
    }
}
