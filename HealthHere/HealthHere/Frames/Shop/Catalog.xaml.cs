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

namespace HealthHere.Frames
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Page
    {
        private order order = new order();
        public Catalog()
        {
            InitializeComponent();

        }

        public void Reload()
        {
            HealthHereEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Products.ItemsSource = HealthHereEntities.GetContext().product.Where(a => a.count != 0).ToList();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                Reload();
            }
        }

        public static void buy_button(object sender, RoutedEventArgs e)
        {

        }
    }
}
