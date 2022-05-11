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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditOrder : Window
    {
        private int _entityId { get; set; }

        public EditOrder(int id, string orderCustomer, string orderProduct, int orderQuantity, DateTime orderDate)
        {
            InitializeComponent();

            _entityId = id;

            using (var context = new AppDbContext())
            {
                foreach (var customer in context.Customers) 
                {
                    var item = new ComboBoxItem();
                    item.Foreground = Brushes.Purple;
                    item.BorderBrush = Brushes.Purple;
                    item.Content = customer.Title;

                    OrderCustomer.Items.Add(item);

                    if (orderCustomer == customer.Title) 
                    {
                        OrderCustomer.SelectedItem = item;
                    }
                }

                foreach (var products in context.Products)
                {
                    var item = new ComboBoxItem();
                    item.Foreground = Brushes.Purple;
                    item.BorderBrush = Brushes.Purple;
                    item.Content = products.Title;

                    OrderProduct.Items.Add(item);

                    if (orderProduct == products.Title)
                    {
                        OrderProduct.SelectedItem = item;
                    }
                }
            }

            OrderQuantity.Text = orderQuantity.ToString();
            OrderDate.Text = orderDate.ToShortDateString();

            Header.Text += _entityId.ToString() + ")";
        }

        private void UpdateOrder_Click(object sender, RoutedEventArgs e)
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
                        notification.AddText("Ошибка редактирования: заказчик не найден");
                        notification.Show();
                        return;
                    }

                    var orderProduct = context.Products.FirstOrDefault(p => p.Title == OrderProduct.Text);

                    if (orderProduct == null)
                    {
                        notification.AddText("Ошибка редактирования: товар не найден");
                        notification.Show();
                        return;
                    }

                    var orderQuantity = Convert.ToInt32(OrderQuantity.Text);
                    var orderDate = DateTime.Parse(OrderDate.Text);

                    var order = context.Orders.Find(_entityId);

                    if (order == null)
                    {
                        notification.AddText("Ошибка редактирования: запись не найдена");
                        notification.Show();
                        return;
                    }

                    order.Customer = orderCustomer;
                    order.Product = orderProduct;
                    order.Quantity = orderQuantity;
                    order.Date = orderDate;

                    context.SaveChanges();
                    notification.AddText("Запись успешно отредактирована, обновите список");
                    notification.Show();
                    this.Close();
                }
            }
            else 
            {
                notification.AddText("Ошибка редактирования: форма заполнена неверно");
                notification.Show();
            }
        }

        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            using (var context = new AppDbContext())
            {
                var order = context.Orders.Find(_entityId);

                if (order == null)
                {
                    notification.AddText("Ошибка удаления: запись не найдена");
                    notification.Show();
                    return;
                }

                context.Orders.Remove(order);
                context.SaveChanges();
                notification.AddText("Запись успешно удалена, обновите список");
                notification.Show();
                this.Close();
            }
        }
    }
}
