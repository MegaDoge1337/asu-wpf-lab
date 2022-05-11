using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace Willberries.UI.Products
{
    /// <summary>
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class ProductsList : Window
    {
        private ObservableCollection<Product> _products = null;

        public ProductsList()
        {
            InitializeComponent();
            RefreshProductsCollection();
        }

        private void RefreshProductsCollection() 
        {
            if (_products == null)
            {
                _products = new ObservableCollection<Product>();
            }

            _products.Clear();

            using (var context = new AppDbContext())
            {
                foreach (var product in context.Products.Include(p => p.DeliveryMethod))
                {
                    _products.Add(new Product(product.Id, product.Title, product.Description, product.Code, product.Price, product.DeliveryMethod.Method));
                }
            }

            ProductsDataGrid.ItemsSource = _products;
        }

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            new UI.Products.AddProduct().ShowDialog();
        }

        private void RefreshProductsCollection_Click(object sender, RoutedEventArgs e)
        {
            RefreshProductsCollection();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public class Product
        {
            public Product(int id, string title, string description, string code, int price, string methodTitle)
            {
                ProductId = id;
                ProductTitle = title;
                ProductDescription = description;
                ProductCode = code;
                ProductPrice = price;
                DeliveryMethodTitle = methodTitle;
            }
            public int ProductId { get; set; }
            public string ProductTitle { get; set; }
            public string ProductDescription { get; set; }
            public string ProductCode { get; set; }
            public int ProductPrice { get; set; }
            public string DeliveryMethodTitle { get; set; }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rowData = (Product)ProductsDataGrid.SelectedItem;
            var id = rowData.ProductId;
            var productTitle = rowData.ProductTitle;
            var productDescription = rowData.ProductDescription;
            var productCode = rowData.ProductCode;
            var productPrice = rowData.ProductPrice;
            var deliveryMethod = rowData.DeliveryMethodTitle;

            new EditProduct(id, productTitle, productDescription, productCode, productPrice, deliveryMethod).ShowDialog();
        }
    }
}
