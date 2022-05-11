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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditDeliveryMethod : Window
    {
        private int _entityId { get; set; }
        private string _previousTitle { get; set; }

        public EditDeliveryMethod(int id, string methodTitle, int amount)
        {
            InitializeComponent();

            _entityId = id;
            _previousTitle = methodTitle;
            MethodTitle.Text = methodTitle;
            Amount.Text = amount.ToString();

            Header.Text += _entityId.ToString() + ")";
        }

        private void UpdateDeliveryMethod_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(MethodTitle)
                && Validator.CheckByRequired(Amount)
                && Validator.CheckByNumeric(Amount))
            {
                using (var context = new AppDbContext())
                {
                    var methodTitle = MethodTitle.Text;

                    if (context.DeliveryMethods.Any(d => d.Method == methodTitle) && methodTitle != _previousTitle)
                    {
                        notification.AddText("Ошибка редактирования: такой метод доставки уже существует");
                        notification.Show();
                        return;
                    }

                    var amount = Convert.ToInt32(Amount.Text);

                    var deliveryMethod = context.DeliveryMethods.Find(_entityId);

                    if (deliveryMethod == null) 
                    {
                        notification.AddText("Ошибка редактирования: запись не найдена");
                        notification.Show();
                        return;
                    }

                    deliveryMethod.Method = methodTitle;
                    deliveryMethod.Amount = amount;

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
                var deliveryMethod = context.DeliveryMethods.Find(_entityId);

                if (deliveryMethod == null)
                {
                    notification.AddText("Ошибка удаления: запись не найдена");
                    notification.Show();
                    return;
                }

                context.DeliveryMethods.Remove(deliveryMethod);
                context.SaveChanges();
                notification.AddText("Запись успешно удалена, обновите список");
                notification.Show();
                this.Close();
            }
        }
    }
}
