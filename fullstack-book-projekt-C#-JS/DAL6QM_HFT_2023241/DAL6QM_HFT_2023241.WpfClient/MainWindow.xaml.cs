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

namespace DAL6QM_HFT_2023241.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AuthorWindow authorWindow = new Windows.AuthorWindow();
            authorWindow.Show();
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Windows.CategoryWindow categoryWindow = new Windows.CategoryWindow();
            categoryWindow.Show();
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            Windows.PublisherWindow publisherWindow = new Windows.PublisherWindow();
            publisherWindow.Show();
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            Windows.BookWindow bookWindow = new Windows.BookWindow();
            bookWindow.Show();
        }
    }
}
