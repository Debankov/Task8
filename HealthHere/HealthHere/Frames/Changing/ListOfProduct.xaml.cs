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

namespace HealthHere.Frames.Changing
{
    /// <summary>
    /// Логика взаимодействия для ListOfProduct.xaml
    /// </summary>
    public partial class ListOfProduct : Page
    {
        public ListOfProduct()
        {
            InitializeComponent();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var CarsForRemoving = GridProduct.SelectedItems.Cast<product>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {CarsForRemoving.Count()} элементов ?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    HealthHereEntities.GetContext().product.RemoveRange(CarsForRemoving);
                    HealthHereEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    GridProduct.ItemsSource = HealthHereEntities.GetContext().product.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MainFrame.Navigate(new ProductChange(null));
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.MainFrame.Navigate(new ProductChange((sender as Button).DataContext as product));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                HealthHereEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                GridProduct.ItemsSource = HealthHereEntities.GetContext().product.ToList();

            }
        }
    }
}
