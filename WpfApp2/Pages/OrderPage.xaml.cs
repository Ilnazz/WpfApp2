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
using WpfApp2.Model;

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            InitializeComponent();
            RefreshOrderList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            // NavigationService.Navigate(new AddOrderPage());
        }

        private void RefreshOrderList() => LvOrders.ItemsSource = App.db.Order.ToList();
    }
}
