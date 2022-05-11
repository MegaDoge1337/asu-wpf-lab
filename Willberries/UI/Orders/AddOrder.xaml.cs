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
using System.Windows.Shapes;
using Microsoft.Toolkit.Uwp.Notifications;
using Willberries.Helpers;
using Willberries.Enities;

namespace Willberries.UI.Orders
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();

            using (var context = new AppDbContext()) 
            {
                foreach (var customer in context.Customers) 
                {
                    var item = new ComboBoxItem();
                    item.Foreground = Brushes.Purple;
                    item.BorderBrush = Brushes.Purple;
                    item.Content = customer.Title;

                    OrderCustomer.Items.Add(item);
                }

                foreach (var product in context.Products) 
                {
                    var item = new ComboBoxItem();
                    item.Foreground = Brushes.Purple;
                    item.BorderBrush = Brushes.Purple;
                    item.Content = product.Title;

                    OrderProduct.Items.Add(item);
                }
            }
        }

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(OrderCustomer)
                && Validator.CheckByRequired(OrderProduct)
                && Validator.CheckByRequired(OrderQuantity)
                && Validator.CheckByNumeric(OrderQuantity)
                && Validator.CheckByRequired(OrderDate))
            {
                using (var context = new AppDbContext())
                {
                    var orderCustomer = context.Customers.FirstOrDefault(c => c.Title == OrderCustomer.Text);

                    if (orderCustomer == null)
                    {
                        notification.AddText("Ошибка добавления: заказчик не найден");
                        notification.Show();
                        return;
                    }

                    var orderProduct = context.Products.FirstOrDefault(p => p.Title == OrderProduct.Text);

                    if (orderProduct == null)
                    {
                        notification.AddText("Ошибка добавления: товар не найден");
                        notification.Show();
                        return;
                    }

                    var orderQuantity = Convert.ToInt32(OrderQuantity.Text);
                    var orderDate = DateTime.Parse(OrderDate.Text);

                    var newOrder = new Order();
                    newOrder.Customer = orderCustomer;
                    newOrder.Product = orderProduct;
                    newOrder.Quantity = orderQuantity;
                    newOrder.Date = orderDate;


                    context.Orders.Add(newOrder);
                    context.SaveChanges();
                    notification.AddText("Заказ успешно добавлен, обновите список");
                    notification.Show();
                    this.Close();
                }
            }
            else 
            {
                notification.AddText("Ошибка добавления: форма заполнена неверно");
                notification.Show();
            }
        }
    }
}
