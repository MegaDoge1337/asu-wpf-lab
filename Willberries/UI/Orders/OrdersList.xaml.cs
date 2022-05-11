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

namespace Willberries.UI.Orders
{
    /// <summary>
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class OrdersList : Window
    {
        private ObservableCollection<Order> _orders = null;

        public OrdersList()
        {
            InitializeComponent();
            RefreshOrdersCollection();
        }

        private void RefreshOrdersCollection() 
        {
            if (_orders == null)
            {
                _orders = new ObservableCollection<Order>();
            }

            _orders.Clear();

            using (var context = new AppDbContext())
            {
                foreach (var order in context.Orders.Include(o => o.Product).Include(o => o.Customer))
                {
                    _orders.Add(new Order(order.Id, order.Customer.Title, order.Product.Title, order.Quantity, order.Date));
                }
            }

            OrdersDataGrid.ItemsSource = _orders;
        }

        private void AddNewOrder_Click(object sender, RoutedEventArgs e)
        {
            new UI.Orders.AddOrder().ShowDialog();
        }

        private void RefreshOrdersCollection_Click(object sender, RoutedEventArgs e)
        {
            RefreshOrdersCollection();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public class Order
        {
            public Order(int id, string customer, string product, int quantity, DateTime date)
            {
                OrderId = id;
                OrderCustomer = customer;
                OrderProduct = product;
                OrderQuantity = quantity;
                OrderDate = date;
            }
            public int OrderId { get; set; }
            public string OrderCustomer { get; set; }
            public string OrderProduct { get; set; }
            public int OrderQuantity { get; set; }
            public DateTime OrderDate { get; set; }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rowData = (Order)OrdersDataGrid.SelectedItem;
            var orderId = rowData.OrderId;
            var orderCustomer = rowData.OrderCustomer;
            var orderProduct = rowData.OrderProduct;
            var orderQuantity = rowData.OrderQuantity;
            var orderDate = rowData.OrderDate;

            new UI.Orders.EditOrder(orderId, orderCustomer, orderProduct, orderQuantity, orderDate).ShowDialog();
        }
    }
}
