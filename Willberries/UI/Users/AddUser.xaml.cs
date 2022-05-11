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

namespace Willberries.UI.Users
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(Login)
                && Validator.CheckByRequired(Password)
                && Validator.CheckByRequired(IsAdmin))
            {
                using (var context = new AppDbContext())
                {
                    var login = Login.Text;

                    if (context.Users.Any(u => u.Login == login))
                    {
                        notification.AddText("Ошибка добавления: пользователь с таким логином уже существует");
                        notification.Show();
                        return;
                    }

                    var password = Password.Password;

                    using (var MD5 = System.Security.Cryptography.MD5.Create())
                    {
                        byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
                        byte[] hashBytes = MD5.ComputeHash(passwordBytes);

                        password = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
                    }

                    var isAdministrator = IsAdmin.IsChecked;

                    var newUser = new User();
                    newUser.Login = login;
                    newUser.Password = password;
                    newUser.IsAdministartor = isAdministrator == true;

                    context.Users.Add(newUser);
                    context.SaveChanges();
                    notification.AddText("Пользователь успешно добавлен, обновите список");
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
