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

namespace app
{
    /// <summary>
    /// Logika interakcji dla klasy addAuthor.xaml
    /// </summary>
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



    }
}
