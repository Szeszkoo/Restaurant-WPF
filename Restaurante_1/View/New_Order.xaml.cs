using Restaurante_1.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
    public partial class New_Order : Page
    {
        public New_Order()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
       
    }
}
