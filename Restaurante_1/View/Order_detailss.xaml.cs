using Restaurante_1.ViewModel;
using System;
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
    /// <summary>
    /// Interaction logic for Order_detailss.xaml
    /// </summary>
    public partial class Order_detailss : Page
    {
        public Order_detailss()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        //public int i = 0;
        //private void dataGrid_details_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        //{
        //    if (i > 0)
        //    {
        //        var dg = sender as DataGrid;
        //        if (dg != null && e.AddedCells != null && e.AddedCells.Count > 0)
        //        {
        //            var cell = e.AddedCells[0];
        //            if (!cell.IsValid)
        //                return;
        //            var generator = dg.ItemContainerGenerator;
        //            int columnIndex = cell.Column.DisplayIndex;
        //            int rowIndex = generator.IndexFromContainer(generator.ContainerFromItem(cell.Item));
        //            //TODO assign indexes to VM
        //            MainViewModel.Row_num = rowIndex;
        //        }
        //    }
        //    i++;
        //}
    }
}
