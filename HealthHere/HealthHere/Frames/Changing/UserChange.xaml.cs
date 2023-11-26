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
    /// Логика взаимодействия для UserChange.xaml
    /// </summary>
    public partial class UserChange : Page
    {
        private user currentUser = new user();
        public UserChange()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Reload();
            }
        }

        private void Reload()
        {
            if (Visibility == Visibility.Visible)
            {
                HealthHereEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                GridUser.ItemsSource = HealthHereEntities.GetContext().user.ToList();
                DataContext = currentUser;
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            var CarsForRemoving = GridUser.SelectedItems.Cast<user>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {CarsForRemoving.Count()} элементов ?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    HealthHereEntities.GetContext().user.RemoveRange(CarsForRemoving);
                    HealthHereEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    GridUser.ItemsSource = HealthHereEntities.GetContext().user.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
