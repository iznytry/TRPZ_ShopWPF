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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopWPF
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           /* var goodsWindow = new GoodsWindow(this);
            HideMe();
            adminPanel.Show();*/
            GoodsWindow goodsWindow = new GoodsWindow(Name);
            goodsWindow.Show();
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SingWindow singWindow = new SingWindow();
            singWindow.Show();
            Close();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            LogWindow logWindow = new LogWindow();
            logWindow.Show();
            Close();

        }
       /* public void HideMe()
        {
            (FindResource("hideMe") as Storyboard).Begin(this);
        }*/
    }
}
