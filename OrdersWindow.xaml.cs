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
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public string Username { get; private set; }

        private OrderModel _model; 

        public OrdersWindow(string username)
        {
            DataContext = _model;
            _model = new OrderModel(username);
            InitializeComponent();

            //TODO debug binding, doesn't work!!
            ordersList.ItemsSource = _model.ordersList;
            Username = username;
        }
    

        private void ButtonBack1_Click(object sender, RoutedEventArgs e)
        {
            new GoodsWindow(Name).Show();
            Close();
        }
    }
}
