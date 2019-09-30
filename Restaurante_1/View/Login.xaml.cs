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
using Restaurante_1.ViewModel;
using System.Threading;

namespace Restaurante_1.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("View/Orders_Grid.xaml", UriKind.Relative));
            //tb_username.IsEnabled = false;
            //tb_username.Text = "";
            //tb_passwordbox.IsEnabled = false;
            //tb_passwordbox.Password = "";
            //lbl_message.Content = "Succesfull login!";
        }

        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("View/Orders_Grid.xaml", UriKind.Relative));
        }

       

       
    }
}
