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
    /// Логика взаимодействия для EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        private int _entityId { get; set; }
        private string _previousLogin { get; set; }

        public EditUser(int id, string login, bool isAdministrator)
        {
            InitializeComponent();

            _entityId = id;
            _previousLogin = login;
            Login.Text = login;
            IsAdmin.IsChecked = isAdministrator;

            Header.Text += _entityId.ToString() + ")";
        }

        private void UpdateUser_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(Login)
                && Validator.CheckByRequired(IsAdmin))
            {
                using (var context = new AppDbContext())
                {
                    var login = Login.Text;

                    if (context.Users.Any(u => u.Login == login) && login != _previousLogin)
                    {
                        notification.AddText("Ошибка редактирования: пользователь с таким логином уже существует");
                        notification.Show();
                        return;
                    }

                    var password = Password.Password;

                    if (!string.IsNullOrEmpty(password) && !string.IsNullOrWhiteSpace(password)) 
                    {
                        using (var MD5 = System.Security.Cryptography.MD5.Create())
                        {
                            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
                            byte[] hashBytes = MD5.ComputeHash(passwordBytes);

                            password = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
                        }
                    }

                    var isAdministrator = IsAdmin.IsChecked;

                    var user = context.Users.Find(_entityId);

                    if (user == null) 
                    {
                        notification.AddText("Ошибка редактирования: запись не найдена");
                        notification.Show();
                        return;
                    }

                    user.Login = login;
                    if (!string.IsNullOrEmpty(password) && !string.IsNullOrWhiteSpace(password))
                    {
                        user.Password = password;
                    }
                    user.IsAdministartor = isAdministrator == true;

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

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            using (var context = new AppDbContext())
            {
                var user = context.Users.Find(_entityId);

                if (user == null)
                {
                    notification.AddText("Ошибка удаления: запись не найдена");
                    notification.Show();
                    return;
                }

                context.Users.Remove(user);
                context.SaveChanges();
                notification.AddText("Запись успешно удалена, обновите список");
                notification.Show();
                this.Close();
            }
        }
    }
}
