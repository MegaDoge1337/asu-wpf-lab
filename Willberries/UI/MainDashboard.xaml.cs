using Microsoft.Toolkit.Uwp.Notifications;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using Willberries.Enities;
using Willberries.Helpers;

namespace Willberries.UI
{
    /// <summary>
    /// Логика взаимодействия для MainDashboard.xaml
    /// </summary>
    public partial class MainDashboard : Window
    {
        private User _user;
        public MainDashboard(User user)
        {
            InitializeComponent();
            _user = user;

            using (var context = new AppDbContext())
            {
                foreach (var customer in context.Customers)
                {
                    var item1 = new ComboBoxItem();
                    item1.Foreground = Brushes.Purple;
                    item1.BorderBrush = Brushes.Purple;
                    item1.Content = customer.Title;

                    var item2 = new ComboBoxItem();
                    item2.Foreground = Brushes.Purple;
                    item2.BorderBrush = Brushes.Purple;
                    item2.Content = customer.Title;

                    SelectedCustomer1.Items.Add(item1);
                    SelectedCustomer2.Items.Add(item2);
                }

                foreach (var product in context.Products) 
                {
                    var item = new ComboBoxItem();
                    item.Foreground = Brushes.Purple;
                    item.BorderBrush = Brushes.Purple;
                    item.Content = product.Title;

                    SelectedProduct.Items.Add(item);
                }

                foreach (var order in context.Orders) 
                {
                    var item1 = new ComboBoxItem();
                    item1.Foreground = Brushes.Purple;
                    item1.BorderBrush = Brushes.Purple;
                    item1.Content = order.Id.ToString();

                    var item2 = new ComboBoxItem();
                    item2.Foreground = Brushes.Purple;
                    item2.BorderBrush = Brushes.Purple;
                    item2.Content = order.Id.ToString();

                    SelectedOrderNumber.Items.Add(item1);
                    SelectedOrderNumberForBill.Items.Add(item2);
                }
            }

            UsersDashboard.IsEnabled = _user.IsAdministartor;
        }

        private void UsersDashboard_Click(object sender, RoutedEventArgs e)
        {
            new UI.Users.UsersList().ShowDialog();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeliveryMethodsDashboard_Click(object sender, RoutedEventArgs e)
        {
            new UI.DeliveryMethods.DeliveryMethodsList().ShowDialog();
        }

        private void ProductsDashboard_Click(object sender, RoutedEventArgs e)
        {
            new UI.Products.ProductsList().ShowDialog();
        }

        private void CustomersDashboard_Click(object sender, RoutedEventArgs e)
        {
            new UI.Customers.CustomersList().ShowDialog();
        }

        private void OrdersDashboard_Click(object sender, RoutedEventArgs e)
        {
            new UI.Orders.OrdersList().ShowDialog();
        }

        private void GetOrdersCountByCustomer_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(SelectedCustomer1))
            {
                using (var context = new AppDbContext())
                {
                    var customerTitle = SelectedCustomer1.Text;
                    var customer = context.Customers.FirstOrDefault(c => c.Title == customerTitle);
                    if (customer == null) 
                    {
                        notification.AddText("Заказчик не найден");
                        notification.Show();
                        return;
                    }

                    var count = context.Orders.Include(o => o.Customer).Where(o => o.Customer.Title == customer.Title).Count();
                    CountOfOrdersByCustomerDisplay.Text = "Количество заказов у заказчика: " + count.ToString();
                }
            }
            else 
            {
                notification.AddText("Выберите заказчика, чтобы собрать информацию");
                notification.Show();
            }
        }

        private void GetOrdersCountByDateRange_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(StartDate)
                && Validator.CheckByRequired(EndDate))
            {
                var startDate = DateTime.Parse(StartDate.Text);
                var endDate = DateTime.Parse(EndDate.Text);

                using (var context = new AppDbContext()) 
                {
                    var count = context.Orders.Where(o => (o.Date >= startDate) && (o.Date <= endDate)).Count();
                    CountOfOrdersByDateRangeDisplay.Text = "Количество заказов в периоде: " + count.ToString();
                }
            }
            else
            {
                notification.AddText("Выберите период дат, чтобы собрать информацию");
                notification.Show();
            }
        }

        private void GetOrderedProductsCountByCustomer_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(SelectedCustomer2))
            {
                using (var context = new AppDbContext())
                {
                    var customerTitle = SelectedCustomer2.Text;
                    var customer = context.Customers.FirstOrDefault(c => c.Title == customerTitle);
                    if (customer == null)
                    {
                        notification.AddText("Заказчик не найден");
                        notification.Show();
                        return;
                    }

                    var count = context.Orders.Include(o => o.Customer).Where(o => o.Customer.Title == customer.Title).Sum(o => o.Quantity);
                    CountOfOrderedProductsDisplay.Text = "Количество заказаных товаров у заказчика: " + count.ToString();
                }
            }
            else
            {
                notification.AddText("Выберите заказчика, чтобы собрать информацию");
                notification.Show();
            }
        }

        private void GetProductAmount_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(SelectedProduct))
            {
                using (var context = new AppDbContext())
                {
                    var productTitle = SelectedProduct.Text;
                    var product = context.Products.Include(p => p.DeliveryMethod).FirstOrDefault(p => p.Title == productTitle);
                    if (product == null)
                    {
                        notification.AddText("Товар не найден");
                        notification.Show();
                        return;
                    }

                    var amount = product.Price + product.DeliveryMethod.Amount;
                    ProductAmountDisplay.Text = "Цена товара учётом доставки: " + amount.ToString();
                }
            }
            else
            {
                notification.AddText("Выберите товар, чтобы собрать информацию");
                notification.Show();
            }
        }

        private void GetOrderDeliveryMethod_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(SelectedOrderNumber)
                && Validator.CheckByNumeric(SelectedOrderNumber))
            {
                using (var context = new AppDbContext())
                {
                    var orderId = Convert.ToInt32(SelectedOrderNumber.Text);
                    var order = context.Orders.Include(o => o.Product).Include(o => o.Product.DeliveryMethod).FirstOrDefault(o => o.Id == orderId);
                    if (order == null)
                    {
                        notification.AddText("Заказ не найден");
                        notification.Show();
                        return;
                    }

                    var deliveryMethod = order.Product.DeliveryMethod.Method;
                    DeliveryMethodDisplay.Text = "Кем доставляется заказ: " + deliveryMethod;
                }
            }
            else
            {
                notification.AddText("Выберите номер заказа, чтобы собрать информацию");
                notification.Show();
            }
        }

        private void GenerateOrderBill_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(SelectedOrderNumberForBill)
                && Validator.CheckByNumeric(SelectedOrderNumberForBill))
            {
                using (var context = new AppDbContext())
                {
                    var orderId = Convert.ToInt32(SelectedOrderNumberForBill.Text);
                    var order = context.Orders.Include(o => o.Product).Include(o => o.Product.DeliveryMethod).FirstOrDefault(o => o.Id == orderId);
                    if (order == null)
                    {
                        notification.AddText("Заказ не найден");
                        notification.Show();
                        return;
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Сохранить чек";
                    saveFileDialog.Filter = "PDF (*.pdf)|*.pdf";
                    if (saveFileDialog.ShowDialog() == true) 
                    {
                        BillFormater.GenerateAndOpenBill(order, saveFileDialog.FileName);
                        notification.AddText("Чек сохранён в файл " + saveFileDialog.FileName);
                        notification.Show();
                    }
                }
            }
            else
            {
                notification.AddText("Выберите номер заказа, чтобы сформировать чек");
                notification.Show();
            }
        }

        private void Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Открыть json-файл";
            openFileDialog.Filter = "JSON (*.json)|*.json";
            if (openFileDialog.ShowDialog() == true) 
            {
                JsonConnector.ImportJson(openFileDialog.FileName);
            }
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
