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
//using System.Windows.Forms;
using System.Diagnostics;

namespace app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow _instance;
        public MainWindow()
        {
            _instance = this;
            InitializeComponent();
            Loaded += load;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

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

                string query = "SELECT * FROM books JOIN authors ON author_id = id_author JOIN genres ON genre_id = id_genres;";
                string query2 = "SELECT * FROM genres";

                MySqlCommand cmd3 = new MySqlCommand(query, database.sql);            
                MySqlDataReader ItemsAmount = cmd3.ExecuteReader();
                int rowCount = 0;
                while (ItemsAmount.Read())
                {
                    rowCount++;
                }
                ItemsAmount.Close();

                MySqlCommand cmd2 = new MySqlCommand(query2, database.sql);
                MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                    selectGenres.Items.Add(dataReader2["name_genre"]);
                }
                dataReader2.Close();

                MySqlCommand cmd = new MySqlCommand(query, database.sql);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                SolidColorBrush losos = new SolidColorBrush(Color.FromRgb(180, 91, 91));
                SolidColorBrush bialy = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                SolidColorBrush siwy = new SolidColorBrush(Color.FromRgb(217, 217, 217));
                scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                
                for (int i = 0; i < rowCount; i++)
                {
                    dataReader.Read();
                    Rectangle newRectangle = new Rectangle
                    {
                        Width = 850,
                        Height = 200,
                        Fill = losos,
                        StrokeThickness = 0,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(0, 213 * i, 0, 0),
                    };
                    kafelki.Children.Add(newRectangle);


                    Rectangle tlo = new Rectangle
                    {
                        Width = 180,
                        Height = 180,
                        Fill = bialy,
                        StrokeThickness = 0,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(-642, (213 * i) + 10, 0, 0),
                    };
                    kafelki.Children.Add(tlo);


                    Image newImage = new Image
                    {
                        Width = 180,
                        Height = 180,
                        Source = new BitmapImage(new Uri("C:/Users/komputer/Desktop/git/biblioteczka/biblioteczka/app/app/" + dataReader["image"])),
                        Margin = new Thickness(-642, (213 * i) + 10, 0, 0),
                        VerticalAlignment = VerticalAlignment.Top,
                        
                    };
                    kafelki.Children.Add(newImage);


                    TextBlock title = new TextBlock
                    {
                        Width = 450,
                        Height = 25,
                        FontSize = 16,
                        Foreground = bialy,
                        FontWeight = FontWeights.Bold,
                        Text = dataReader["title"].ToString(),
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(70, (213 * i) + 40, 0, 0),
                        Background = null,                      
                    };
                    kafelki.Children.Add(title);


                    TextBlock author = new TextBlock
                    {
                        Width = 450,
                        Height = 20,
                        FontSize = 14,
                        Foreground = bialy,
                        Text = dataReader["name"].ToString() + " " + dataReader["last_name"].ToString(),
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(70, (213 * i) + 75, 0, 0),
                        Background = null,
                    };
                    kafelki.Children.Add(author);


                    TextBlock genre = new TextBlock
                    {
                        Width = 450,
                        Height = 20,
                        FontSize = 14,
                        Foreground = bialy,
                        Text = dataReader["name_genre"].ToString(),
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(70, (213 * i) + 105, 0, 0),
                        Background = null,
                    };
                    kafelki.Children.Add(genre);


                    TextBlock date = new TextBlock
                    {
                        Width = 450,
                        Height = 20,
                        FontSize = 14,
                        Foreground = bialy,
                        Text = dataReader["publication_date"].ToString(),
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(70, (213 * i) + 135, 0, 0),
                        Background = null,
                    };
                    kafelki.Children.Add(date);


                    Button usun = new Button
                    {
                        Width = 100,
                        Height = 30,
                        Name = "b" + i,
                        Tag = dataReader["id_book"],
                        Background = siwy,
                        BorderBrush = null,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(690, (213 * i) + 10, 0, 0),
                        Content = "DELETE BOOK",
                        FontWeight = FontWeights.Bold,
                    };
                    usun.Click += new RoutedEventHandler(deleteRow);
                    kafelki.Children.Add(usun);


                }


                dataReader.Close();
                database.close_db();
   
            }
           
        }

        private void load(object sender, RoutedEventArgs e)
        {
            loadData();
        }

        private void deleteRow(object sender, RoutedEventArgs e)
        {

            Button button = (Button)e.OriginalSource;
            string id = button.Tag.ToString();
            

            var conn = new database();

            if (conn.connect_db())
            {

                string zap = "DELETE FROM books WHERE id_book = @i";
                MySqlCommand cmd = new MySqlCommand(zap, conn.sql);
                cmd.Parameters.AddWithValue("@i", id);
                cmd.ExecuteNonQuery();
                //this.loadData();
                //this.InvalidateVisual();
                MainWindow okno = new MainWindow();
                okno.Show();
                this.Close();
                

            }

        }

        private void add_book(object sender, RoutedEventArgs e)
        {
            addBook dodaj = new addBook();
            dodaj.Show();
        }

        private void newAuthor_Click(object sender, RoutedEventArgs e)
        {
            addAuthor autor = new addAuthor();
            autor.Show();
        }


        //TO DO:

        //wyszukiwanie
        //refresh danych po usunieciu
        //poprawa wygladu 
        //jak nam sie chce walidaja danych

    }
}
