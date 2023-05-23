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
using WpfApp2.Pages;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyFrame.NavigationService.Navigate(new LoginPage());
        }

        //private void TextBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    var user = App.db.Users.FirstOrDefault(x => x.Login == TBLogin.Text && x.Password == TBPassword.Text);
        //    if (user == null)
        //    {
        //        MessageBox.Show("User not found");
        //    }
        //    else MessageBox.Show(user.Surname + " " + user.Name + " " + user.Patronymic);

        }
       

    }
