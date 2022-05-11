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
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        public AddProduct()
        {
            InitializeComponent();

            using (var context = new AppDbContext())
            {
                foreach (var deliveryMethod in context.DeliveryMethods) 
                {
                    var item = new ComboBoxItem();
                    item.Foreground = Brushes.Purple;
                    item.BorderBrush = Brushes.Purple;
                    item.Content = deliveryMethod.Method;

                    SelectedDeliveryMethod.Items.Add(item);
                }
            }
        }

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
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

                    if (context.Products.Any(p => p.Title == productTitle))
                    {
                        notification.AddText("Ошибка добавления: такой товар уже существует");
                        notification.Show();
                        return;
                    }

                    var description = ProductDescription.Text;
                    var code = ProductCode.Text;
                    var price = Convert.ToInt32(ProductPrice.Text);
                    var deliveryMethod = context.DeliveryMethods.FirstOrDefault(d => d.Method == SelectedDeliveryMethod.Text);

                    var newProduct = new Product();
                    newProduct.Title = productTitle;
                    newProduct.Description = description;
                    newProduct.Code = code;
                    newProduct.Price = price;
                    newProduct.DeliveryMethod = deliveryMethod;

                    context.Products.Add(newProduct);
                    context.SaveChanges();
                    notification.AddText("Товар успешно добавлен, обновите список");
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
