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
using ClassLibrary;
using System.Data.OleDb;

namespace CBCDashboardWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TransformOrders_Click(object sender, RoutedEventArgs e)
        {
            CBCAccess.Util.AddItems(new());
            //if (!(CBCExcel.Util.OpenWorkbook(caption: "Open Workbook (Square Orders)") == string.Empty))
            //{ 
            //    return;
            //};
            
        }
    }
}
