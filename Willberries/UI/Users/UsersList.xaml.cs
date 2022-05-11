using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Willberries.UI.Users
{
    /// <summary>
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class UsersList : Window
    {
        private ObservableCollection<User> _users = null;

        public UsersList()
        {
            InitializeComponent();
            RefreshUsersCollection();
        }

        private void RefreshUsersCollection() 
        {
            if (_users == null)
            {
                _users = new ObservableCollection<User>();
            }

            _users.Clear();

            using (var context = new AppDbContext())
            {
                foreach (var user in context.Users)
                {
                    _users.Add(new User(user.Id, user.Login, user.IsAdministartor));
                }
            }

            UsersDataGrid.ItemsSource = _users;
        }

        private void OpenAddUserForm_Click(object sender, RoutedEventArgs e)
        {
            new AddUser().ShowDialog();
        }

        private void RefreshUsersList_Click(object sender, RoutedEventArgs e)
        {
            RefreshUsersCollection();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public class User
        {
            public User(int id, string login, bool isAdmin)
            {
                Id = id;
                Login = login;
                Role = isAdmin ? "Администратор" : "Пользователь";
            }
            public int Id { get; set; }
            public string Login { get; set; }
            public string Role { get; set; }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rowData = (User)UsersDataGrid.SelectedItem;
            var id = rowData.Id;
            var login = rowData.Login;
            var isAdministrator = rowData.Role == "Администратор";

            new EditUser(id, login, isAdministrator).Show();
        }
    }
}
