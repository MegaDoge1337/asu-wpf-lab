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

namespace Willberries.UI.Products
{
    /// <summary>
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        private int _entityId { get; set; }
        private string _previousTitle { get; set; }

        public EditProduct(int id, string productTItle, string productDescription, string productCode, int productPrice, string selectedDeliveryMethod)
        {
            InitializeComponent();

            _entityId = id;
            _previousTitle = productTItle;

            ProductTitle.Text = productTItle;
            ProductDescription.Text = productDescription;
            ProductCode.Text = productCode;
            ProductPrice.Text = productPrice.ToString();

            using (var context = new AppDbContext()) 
            {
                foreach (var deliveryMethod in context.DeliveryMethods) 
                {
                    var item = new ComboBoxItem();
                    item.Foreground = Brushes.Purple;
                    item.BorderBrush = Brushes.Purple;
                    item.Content = deliveryMethod.Method;

                    SelectedDeliveryMethod.Items.Add(item);

                    if (deliveryMethod.Method == selectedDeliveryMethod) 
                    {
                        SelectedDeliveryMethod.SelectedItem = item;
                    }
                }
            }

            Header.Text += _entityId.ToString() + ")";
        }

        private void UpdateDeliveryMethod_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(ProductTitle)
                && Validator.CheckByRequired(ProductDescription)
                && Validator.CheckByRequired(ProductCode)
                && Validator.CheckByRequired(ProductPrice)
                && Validator.CheckByNumeric(ProductPrice)
                && Validator.CheckByRequired(SelectedDeliveryMethod))
            {
                using (var context = new AppDbContext())
                {
                    var productTitle = ProductTitle.Text;

                    if (context.Products.Any(p => p.Title == productTitle) && productTitle != _previousTitle)
                    {
                        notification.AddText("Ошибка редактирования: такой товар уже существует");
                        notification.Show();
                        return;
                    }

                    var productDescription = ProductDescription.Text;
                    var productCode = ProductCode.Text;
                    var productPrice = Convert.ToInt32(ProductPrice.Text);

                    var deliveryMethod = context.DeliveryMethods.FirstOrDefault(d => d.Method == SelectedDeliveryMethod.Text);

                    var product = context.Products.Find(_entityId);

                    if (product == null) 
                    {
                        notification.AddText("Ошибка редактирования: запись не найдена");
                        notification.Show();
                        return;
                    }

                    product.Title = productTitle;
                    product.Description = productDescription;
                    product.Code = productCode;
                    product.Price = productPrice;
                    product.DeliveryMethod = deliveryMethod;

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

        private void DeleteDeliveryMethod_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            using (var context = new AppDbContext())
            {
                var product = context.Products.Find(_entityId);

                if (product == null)
                {
                    notification.AddText("Ошибка удаления: запись не найдена");
                    notification.Show();
                    return;
                }

                context.Products.Remove(product);
                context.SaveChanges();
                notification.AddText("Запись успешно удалена, обновите список");
                notification.Show();
                this.Close();
            }
        }
    }
}
