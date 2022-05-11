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

namespace Willberries.UI.Customers
{
    /// <summary>
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class CustomersList : Window
    {
        private ObservableCollection<Customer> _customers = null;

        public CustomersList()
        {
            InitializeComponent();
            RefreshCustomersCollection();
        }

        private void RefreshCustomersCollection() 
        {
            if (_customers == null)
            {
                _customers = new ObservableCollection<Customer>();
            }

            _customers.Clear();

            using (var context = new AppDbContext())
            {
                foreach (var customer in context.Customers)
                {
                    _customers.Add(new Customer(customer.Id, customer.Code, customer.Title, customer.Address, customer.Phone, customer.Delegate));
                }
            }

            CustomersDataGrid.ItemsSource = _customers;
        }

        private void AddNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            new UI.Customers.AddCustomer().ShowDialog();
        }

        private void RefreshCustomersCollection_Click(object sender, RoutedEventArgs e)
        {
            RefreshCustomersCollection();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public class Customer
        {
            public Customer(int id, string code, string title, string address, string phone, string _delegate)
            {
                CustomerId = id;
                CustomerCode = code;
                CustomerTitle = title;
                CustomerAddress = address;
                CustomerPhone = phone;
                CustomerDelegate = _delegate;
            }
            public int CustomerId { get; set; }
            public string CustomerCode { get; set; }
            public string CustomerTitle { get; set; }
            public string CustomerAddress { get; set; }
            public string CustomerPhone { get; set; }
            public string CustomerDelegate { get; set; }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rowData = (Customer)CustomersDataGrid.SelectedItem;
            var customerId = rowData.CustomerId;
            var customerCode = rowData.CustomerCode;
            var customerTitle = rowData.CustomerTitle;
            var customerAddress = rowData.CustomerAddress;
            var customerPhone = rowData.CustomerPhone;
            var customerDelegate = rowData.CustomerDelegate;

            new UI.Customers.EditCustomer(customerId, customerCode, customerTitle, customerAddress, customerPhone, customerDelegate).ShowDialog();
        }
    }
}
