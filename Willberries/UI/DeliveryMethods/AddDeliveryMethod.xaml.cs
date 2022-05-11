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

namespace Willberries.UI.DeliveryMethods
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddDeliveryMethod : Window
    {
        public AddDeliveryMethod()
        {
            InitializeComponent();
        }

        private void AddNewDeliveryMethod_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(MethodTitle)
                && Validator.CheckByRequired(Amount)
                && Validator.CheckByNumeric(Amount))
            {
                using (var context = new AppDbContext())
                {
                    var methodTitle = MethodTitle.Text;

                    if (context.DeliveryMethods.Any(d => d.Method == methodTitle))
                    {
                        notification.AddText("Ошибка добавления: такой метод доставки уже существует");
                        notification.Show();
                        return;
                    }

                    var amount = Convert.ToInt32(Amount.Text);

                    var newDeliveryMethod = new DeliveryMethod();
                    newDeliveryMethod.Method = methodTitle;
                    newDeliveryMethod.Amount = amount;

                    context.DeliveryMethods.Add(newDeliveryMethod);
                    context.SaveChanges();
                    notification.AddText("Способ доставки успешно добавлен, обновите список");
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
