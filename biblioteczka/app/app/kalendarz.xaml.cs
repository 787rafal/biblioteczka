﻿using System;
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
    /// Logika interakcji dla klasy kalendarz.xaml
    /// </summary>
    public partial class kalendarz : Window
    {
        public kalendarz()
        {
            InitializeComponent();
        }


        private void close(object sender, RoutedEventArgs e)
        {
            addBook._instance2.kalendarz_active = false;
            addBook._instance2.IsEnabled = true;
            this.Close();
        }

        private void zapisz(object sender, RoutedEventArgs e)
        {
            var date = "";
            if (cal.SelectedDate == null)
            {
                date = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                date = cal.SelectedDate.Value.Date.ToString("dd/MM/yyyy");
            }
            addBook._instance2.pub_date.Content = date;
            addBook._instance2.kalendarz_active = false;
            addBook._instance2.IsEnabled = true;
            this.Close();

        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            //addBook._instance2.Topmost = true;
            Window window = (Window)sender;
            window.Topmost = true;
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
            addBook._instance2.kalendarz_active = false;
            addBook._instance2.IsEnabled = true;
        }
    }
}
