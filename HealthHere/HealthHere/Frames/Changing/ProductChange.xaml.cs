using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для ProductChange.xaml
    /// </summary>
    public partial class ProductChange : Page
    {
        private product currentProduct = new product();
        public ProductChange(product selectedProduct)
        {
            InitializeComponent();

            if (selectedProduct != null)
                currentProduct = selectedProduct;

            DataContext = currentProduct;
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            currentProduct = (product)DataContext;

            if (currentProduct.price == 0)
                errors.AppendLine("Введите цену");
            if (string.IsNullOrWhiteSpace(currentProduct.name))
                errors.AppendLine("Введите наименование");

            currentProduct.caterogy_id = 3;

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (currentProduct.product_id == 0)
                HealthHereEntities.GetContext().product.AddOrUpdate(currentProduct);

            try
            {
                HealthHereEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
