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

namespace Willberries.UI.Customers
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        private int _entityId { get; set; }
        private string _previousTitle { get; set; }

        public EditCustomer(int id, string customerCode, string customerTitle, string customerAddress, string customerPhone, string customerDelegate)
        {
            InitializeComponent();

            _entityId = id;
            _previousTitle = customerTitle;

            CustomerCode.Text = customerCode;
            CustomerTitle.Text = customerTitle;
            CustomerAddress.Text = customerAddress;
            CustomerPhone.Text = customerPhone;
            CustomerDelegate.Text = customerDelegate;

            Header.Text += _entityId.ToString() + ")";
        }

        private void UpdateDeliveryMethod_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(CustomerCode)
                && Validator.CheckByRequired(CustomerTitle)
                && Validator.CheckByRequired(CustomerAddress)
                && Validator.CheckByRequired(CustomerPhone)
                && Validator.CheckByRequired(CustomerDelegate))
            {
                using (var context = new AppDbContext())
                {
                    var customerTitle = CustomerTitle.Text;

                    if (context.Customers.Any(c => c.Title == customerTitle) && customerTitle != _previousTitle)
                    {
                        notification.AddText("Ошибка редактирования: такой заказчик уже существует");
                        notification.Show();
                        return;
                    }

                    var customerCode = CustomerCode.Text;
                    var customerAddress = CustomerAddress.Text;
                    var customerPhone = CustomerPhone.Text;
                    var customerDelegate = CustomerDelegate.Text;

                    var customer = context.Customers.Find(_entityId);

                    if (customer == null) 
                    {
                        notification.AddText("Ошибка редактирования: запись не найдена");
                        notification.Show();
                        return;
                    }

                    customer.Code = customerCode;
                    customer.Title = customerTitle;
                    customer.Address = customerAddress;
                    customer.Phone = customerPhone;
                    customer.Delegate = customerDelegate;

                    context.SaveChanges();
                    notification.AddText("Запись успешно отредактирована, обновите список");
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

        private void DeleteDeliveryMethod_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            using (var context = new AppDbContext())
            {
                var customer = context.Customers.Find(_entityId);

                if (customer == null)
                {
                    notification.AddText("Ошибка удаления: запись не найдена");
                    notification.Show();
                    return;
                }

                context.Customers.Remove(customer);
                context.SaveChanges();
                notification.AddText("Запись успешно удалена, обновите список");
                notification.Show();
                this.Close();
            }
        }
    }
}
