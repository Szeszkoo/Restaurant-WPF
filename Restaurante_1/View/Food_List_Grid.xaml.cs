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
    /// Interaction logic for Food_List_Grid.xaml
    /// </summary>
    public partial class Food_List_Grid : Page
    {
        public Food_List_Grid()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }       
    }
}
