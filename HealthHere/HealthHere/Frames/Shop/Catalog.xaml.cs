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
        private order_sctructure order_Sctructure = new order_sctructure();
        private order Order = new order();
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

        private void buy_button(object sender, RoutedEventArgs e)
        {
            if(ViewModel.user_id == 0)
            {
                MessageBox.Show("вы не авторизированны");
                return;
            }
            

            Order.user_id = ViewModel.user_id;

            var selectedProduct = (sender as FrameworkElement)?.DataContext as product;

            if (selectedProduct != null)
            {
                order_Sctructure.product_id = selectedProduct.product_id;
                selectedProduct.count--;

                if (ViewModel.user_id != 0)
                {
                    Order.user_id = ViewModel.user_id;
                    
                }

                if (Order.order_id == 0)
                    HealthHereEntities.GetContext().order.Add(Order);
                }

            order_Sctructure.order_id = HealthHereEntities.GetContext().order.Max(a => a.order_id);


            try
            {
                    HealthHereEntities.GetContext().SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }

                if (order_Sctructure.id == 0)
                {
                    order_Sctructure.count = 1;
                    HealthHereEntities.GetContext().order_sctructure.Add(order_Sctructure);
                }
                    

                try
                {
                    HealthHereEntities.GetContext().SaveChanges();
                    order_Sctructure = new order_sctructure();
                    Reload(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }

            }
        }
    }

