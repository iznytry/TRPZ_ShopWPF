using ShopWPF.Model;
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
using System.Windows.Shapes;

namespace ShopWPF
{
    /// <summary>
    /// Interaction logic for GoodsWindow.xaml
    /// </summary>
    public partial class GoodsWindow : Window
    {
        public string Name1 { get; private set; }
        public string Username { get; private set; }

        private ProductModel _model;
        private MainWindow mainWindow;

        public GoodsWindow(string name)
        {
            DataContext = _model;
            _model = new ProductModel(name);
            InitializeComponent();

            //TODO debug binding, doesn't work!!
            productsList.ItemsSource = _model.productsList;
            Name1 = name;
        }

        public GoodsWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow maiWindow = new MainWindow();
            maiWindow.Show();
            Close();
        }


        private void Makeorder_Button(object sender, RoutedEventArgs e)
        {
            MakeOrderWindow orderWindow = new MakeOrderWindow();
            orderWindow.Show();
            Close();
        }

        private void ShowmyOrders_Button(object sender, RoutedEventArgs e)
        {
            new OrdersWindow(Username).Show();
            Close();

        }

        private void productsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
