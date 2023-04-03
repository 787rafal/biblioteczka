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
using System.Windows.Forms;

namespace app
{
    public class ksiazki
    {

        public static SolidColorBrush losos = new SolidColorBrush(Color.FromRgb(180, 91, 91));
        public static SolidColorBrush bialy = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        public static SolidColorBrush siwy = new SolidColorBrush(Color.FromRgb(217, 217, 217));


        public static void wyswietl(string query, database database, Grid kafelki)
        {
            kafelki.Children.Clear();

            MySqlCommand command = new MySqlCommand(query, database.sql);
            MySqlDataReader dataReader = command.ExecuteReader();

            int i = 0;

            while (dataReader.Read())
            {

                Rectangle blok = new Rectangle
                {
                    Width = 850,
                    Height = 200,
                    Fill = losos,
                    StrokeThickness = 0,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(0, 213 * i, 0, 0),
                };
                kafelki.Children.Add(blok);


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


                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(System.IO.Directory.GetCurrentDirectory() + dataReader["image"]);
                image.EndInit();


                Image newImage = new Image
                {
                    Width = 180,
                    Height = 180,
                    Source = image,
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
                    Margin = new Thickness(70, (213 * i) + 20, 0, 0),
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
                    Margin = new Thickness(70, (213 * i) + 55, 0, 0),
                    Background = null,
                };
                kafelki.Children.Add(author);


                TextBlock wydawnictwo = new TextBlock
                {
                    Width = 450,
                    Height = 20,
                    FontSize = 14,
                    Foreground = bialy,
                    Text = dataReader["publication_house"].ToString(),
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(70, (213 * i) + 80, 0, 0),
                    Background = null,
                };
                kafelki.Children.Add(wydawnictwo);


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


                string pubDate = dataReader["publication_date"].ToString();
                //pubDate = pubDate.Substring(0, pubDate.IndexOf(" "));

                TextBlock date = new TextBlock
                {
                    Width = 450,
                    Height = 20,
                    FontSize = 14,
                    Foreground = bialy,
                    Text = pubDate,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(70, (213 * i) + 130, 0, 0),
                    Background = null,
                    //Style = TargetType
                };
                kafelki.Children.Add(date);


                TextBlock isbnCode = new TextBlock
                {
                    Width = 450,
                    Height = 20,
                    FontSize = 14,
                    Foreground = bialy,
                    Text = dataReader["isbn"].ToString(),
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(70, (213 * i) + 155, 0, 0),
                    Background = null,
                };
                kafelki.Children.Add(isbnCode);


                System.Windows.Controls.Button usun = new System.Windows.Controls.Button
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
                    FontWeight = FontWeights.Normal,
                    Cursor = System.Windows.Input.Cursors.Hand,
                };
                

                

                kafelki.Children.Add(usun);

                i++;
            }
            dataReader.Close();
            if(i == 0)

            {
                TextBlock title = new TextBlock
                {
                    Width = 450,
                    Height = 25,
                    FontSize = 20,
                    Foreground = Brushes.Black,
                    FontWeight = FontWeights.Bold,
                    Text = "BRAK KSIĄŻEK DO WYŚWIETLENIA",
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(170, 0, 0, 0),
                    Background = null,
                };
                kafelki.Children.Add(title);

            }

            MainWindow._instance.buttonRadius();

        }


        public static void wczytaj_gatunki(database database, System.Windows.Controls.ComboBox combo)
        {

            //System.Windows.Controls
            //System.Windows.Forms

            string query = "SELECT * FROM authors";
            MySqlCommand cmd = new MySqlCommand(query, database.sql);
            MySqlDataReader reader = cmd.ExecuteReader();

            combo.Items.Add("AUTHORS: ");

            addBook._instance2.selectAuthor.SelectedIndex = 0;

            while (reader.Read())
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = reader["name"] + " " + reader["last_name"];
                item.Tag = reader["id_author"];
                combo.Items.Add(item);
            }

            reader.Close();

        }






    }
}
