using Restaurante_1.ViewModel;
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

namespace Restaurante_1.View
{
    /// <summary>
    /// Interaction logic for Menu_users.xaml
    /// </summary>
    public partial class Menu_users : Page
    {
        public Menu_users()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("View/New_User.xaml", UriKind.Relative));
        }
    }
}
