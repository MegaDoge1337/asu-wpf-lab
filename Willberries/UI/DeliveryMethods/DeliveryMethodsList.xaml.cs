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

namespace Willberries.UI.DeliveryMethods
{
    /// <summary>
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class DeliveryMethodsList : Window
    {
        private ObservableCollection<Method> _methods = null;

        public DeliveryMethodsList()
        {
            InitializeComponent();
            RefreshMethodsCollection();
        }

        private void RefreshMethodsCollection() 
        {
            if (_methods == null)
            {
                _methods = new ObservableCollection<Method>();
            }

            _methods.Clear();

            using (var context = new AppDbContext())
            {
                foreach (var method in context.DeliveryMethods)
                {
                    _methods.Add(new Method(method.Id, method.Method, method.Amount));
                }
            }

            DeliveryMethodsDataGrid.ItemsSource = _methods;
        }

        private void OpenAddMethodForm_Click(object sender, RoutedEventArgs e)
        {
            new AddDeliveryMethod().ShowDialog();
        }

        private void RefreshMethodsList_Click(object sender, RoutedEventArgs e)
        {
            RefreshMethodsCollection();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public class Method
        {
            public Method(int id, string method, int amount)
            {
                Id = id;
                MethodTitle = method;
                Amount = amount;
            }
            public int Id { get; set; }
            public string MethodTitle { get; set; }
            public int Amount { get; set; }
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var rowData = (Method)DeliveryMethodsDataGrid.SelectedItem;
            var id = rowData.Id;
            var methodTitle = rowData.MethodTitle;
            var amount = rowData.Amount;

            new EditDeliveryMethod(id, methodTitle, amount).Show();
        }
    }
}
