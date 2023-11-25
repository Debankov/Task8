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
using HealthHere.Frames;

namespace HealthHere
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel.MainFrame = MainFrame;
            ViewModel.MainFrame.Navigate(new Catalog());
            
        }

        private void UserPage_Click(object sender, RoutedEventArgs e)
        {
            if(UserText.Text == "Вход")
            {
                ViewModel.MainFrame.Navigate(new Login());
                return;
            }
                ViewModel.MainFrame.Navigate(new UserPage());
        }

        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MainFrame.Navigate(new Catalog());
        }

        private void ShopCart_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MainFrame.Navigate(new ShopCart());
        }
    }
}
