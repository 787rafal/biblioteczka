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
using System.Windows.Forms;
using System.Diagnostics;

namespace app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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

                string query = "SELECT * FROM books";
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = database.sql;
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = dt;
                dane.ItemsSource = bindingSource;


                /* Panie Czech
                 * Tutaj na dole jest jak wyciagnac kazda skladowa z danego wiersza
                 * W ten sposob moglibysmy je wpisywac do danego nwm "textboxa" poprzez zwykle value czy cos
                 * Wydaje mi sie ze moze byc mniej pierdolenia niz z tym DataGrid, bo moze kazdym elementem z osobna sterowac
                 * Wyniki tego kodu mozesz zobaczyc w okienku "Dane wyjsciowe" tylko musi tam byc zaznaczone pokaz dane wyjsciowe z DEBUGOWANIA
                 * 
                 * 
                 * 
                 */

                MySqlCommand cmd = new MySqlCommand(query, database.sql);
               
                MySqlDataReader ItemsAmount = cmd.ExecuteReader();
                int rowCount = 0;
                int columnCount = ItemsAmount.FieldCount;
                while (ItemsAmount.Read())
                {
                    rowCount++;
                }
                Trace.WriteLine("Number of rows = " + rowCount + "\nNumber of columns = " + columnCount +"\n");
                ItemsAmount.Close();



                MySqlDataReader dataReader = cmd.ExecuteReader(); 
                while (dataReader.Read())
                {
                    Trace.WriteLine(dataReader["id_book"]);
                    Trace.WriteLine(dataReader["title"]);
                    Trace.WriteLine(dataReader["image"]);
                    string pubDate = dataReader["publication_date"].ToString();
                    pubDate = pubDate.Substring(0, pubDate.IndexOf(" "));
                    Trace.WriteLine(pubDate);
                    //Trace.WriteLine(dataReader["publication_date"]);
                    Trace.WriteLine(dataReader["author_id"]);
                    Trace.WriteLine(dataReader["genre_id"]);
                    Trace.WriteLine("");
                }
                dataReader.Close();

                database.close_db();
   
            }
           
        }

        private void load(object sender, RoutedEventArgs e)
        {
            loadData();
        }
    }
}
