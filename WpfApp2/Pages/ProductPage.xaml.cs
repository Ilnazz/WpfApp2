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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        private void Top_Click(object sender, RoutedEventArgs e)
        {
            //RefreshProductDataGrid
            NavigationService.Navigate(new ProductsPage(new Product()));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
            => RefreshProductDataGrid();

        private void RefreshProductDataGrid()
            => DGProduct.ItemsSource = App.db.Product.ToList();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var prod = DGProduct.SelectedItem as Product;
            if (prod == null) 
            {
                MessageBox.Show("");
                return;
            }
            NavigationService.Navigate(new ProductsPage(prod));

        }
    }
}
