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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Willberries.Helpers;
using Microsoft.Toolkit.Uwp.Notifications;
using Willberries.Enities;

namespace Willberries
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User _user { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            //JsonConnector.ImportJson("./import.json");
        }

        private void MakeAuth_Click(object sender, RoutedEventArgs e)
        {
            var notification = new ToastContentBuilder();

            if (Validator.CheckByRequired(Login) && Validator.CheckByRequired(Password))
            {
                using (var context = new AppDbContext())
                {
                    var login = Login.Text;
                    var password = Password.Password;

                    using (var MD5 = System.Security.Cryptography.MD5.Create())
                    {
                        byte[] passwordBytes = Encoding.ASCII.GetBytes(password);
                        byte[] hashBytes = MD5.ComputeHash(passwordBytes);

                        password = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
                    }

                    var user = context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

                    if (user != null)
                    {
                        Login.IsEnabled = false;
                        Password.IsEnabled = false;
                        MakeAuth.Visibility = Visibility.Hidden;
                        OpenDashboard.Visibility = Visibility.Visible;
                        Exit.Visibility = Visibility.Visible;
                        notification.AddText("Авторизация успешна, продолжайте работу");
                        _user = user;
                    }
                    else
                    {
                        Login.IsEnabled = true;
                        Password.IsEnabled = true;
                        MakeAuth.Visibility = Visibility.Visible;
                        OpenDashboard.Visibility = Visibility.Hidden;
                        Exit.Visibility = Visibility.Hidden;
                        notification.AddText("Ошибка авторизации: проверьте правильность введённых учётных данных");
                    }
                }
            }
            else 
            {
                notification.AddText("Ошибка авторизации: оба поля должны быть заполены");
            }

            notification.Show();
        }

        private void OpenDashboard_Click(object sender, RoutedEventArgs e) 
        {
            new UI.MainDashboard(_user).ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
