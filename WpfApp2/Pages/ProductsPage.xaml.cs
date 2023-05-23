using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        Product contextProducts;
        DbPropertyValues Oldvalues;

        private Action _onCloseCallback;

        public byte[] Photo { get; private set; }

        //Action onCloseCallback
        public ProductsPage(Product prod)
        {
            InitializeComponent();

            

            CBTypes.ItemsSource = App.db.Type.ToList();
            CBProvider.ItemsSource = App.db.Provider.ToList();

            contextProducts = prod;
            DataContext = contextProducts;
            ImageLW.ItemsSource = contextProducts.ProductPhoto.ToList();    
            if (contextProducts.Id !=0)
            {
                Oldvalues = App.db.Entry(contextProducts).CurrentValues.Clone();
            }
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CBTypes.SelectedItem != null)
                contextProducts.Type = (Model.Type)CBTypes.SelectedItem;

            if (CBProvider.SelectedItem != null)
                contextProducts.Provider = (Provider)CBProvider.SelectedItem;

            App.db.Product.Add(contextProducts);
            App.db.SaveChanges();
            NavigationService.GoBack();

            _onCloseCallback?.Invoke();
        }

        private void BCancel_Click(object sender, RoutedEventArgs e)
        { 
            if (Oldvalues!= null)
            {
                App.db.Entry(contextProducts).CurrentValues.SetValues(Oldvalues);
            }
            NavigationService.GoBack();

            _onCloseCallback?.Invoke();
        }

        private void BCImage_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog() { Multiselect = true};
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                foreach (var item in dialog.FileNames)
                {
                contextProducts.ProductPhoto.Add(new ProductPhoto()
                {
                    Photo = File.ReadAllBytes(item),
                    Product = contextProducts
                });
                
                }
                Reshre();
                DataContext = null;
                DataContext = contextProducts;
            }
        }
        private void Reshre() 
        {
            ImageLW.ItemsSource = contextProducts.ProductPhoto.ToList();
        }
    }
}

