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

namespace WpfApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Vxod_Click(object sender, RoutedEventArgs e)
        {
            var login = TbLogin.Text.Trim();
            var password = TbPassword.Text.Trim();
            var user = App.db.User.FirstOrDefault(us => us.Login == login && us.Password == password);
            if (user == null)
            {
                MessageBox.Show("Неправильный логин или пароль");



            }
            else
            {
                MessageBox.Show("Вы успешно вошли");

                NavigationService.Navigate(new MainPage());
            }
        }
    }
}
