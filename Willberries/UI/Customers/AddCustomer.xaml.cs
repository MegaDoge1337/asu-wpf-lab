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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
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

                    if (context.Customers.Any(c => c.Title == customerTitle))
                    {
                        notification.AddText("Ошибка добавления: такой заказчик уже существует");
                        notification.Show();
                        return;
                    }

                    var customerCode = CustomerCode.Text;
                    var customerAddress = CustomerAddress.Text;
                    var customerPhone = CustomerPhone.Text;
                    var customerDelegate = CustomerDelegate.Text;

                    var newCustomer = new Customer();
                    newCustomer.Code = customerCode;
                    newCustomer.Title = customerTitle;
                    newCustomer.Address = customerAddress;
                    newCustomer.Phone = customerPhone;
                    newCustomer.Delegate = customerDelegate;

                    context.Customers.Add(newCustomer);
                    context.SaveChanges();
                    notification.AddText("Заказчик успешно добавлен, обновите список");
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
