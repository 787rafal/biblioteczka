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
    /// Logika interakcji dla klasy error.xaml
    /// </summary>
    public partial class error : Window
    {
        public error()
        {
            InitializeComponent();
        }

        private void drag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (addBook._instance2 != null)
            {
                addBook._instance2.Show();
            }
            if (addAuthor._instance3 != null)
            {
                addAuthor._instance3.Show();
            }
            //addAuthor._instance3.Show();
        }
    }
}
