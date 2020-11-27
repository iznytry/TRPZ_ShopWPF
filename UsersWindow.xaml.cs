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
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        public UsersWindow()
        {
        }
        public string Username { get; private set; }

        private UsersModel _model;

        public UsersWindow(string username)
        {
            DataContext = _model;
            _model = new UsersModel(username);
            InitializeComponent();

            //TODO debug binding, doesn't work!!
            usersList.ItemsSource = _model.usersList;
            Username = username;

        }

        private void ButtonBack1_Click(object sender, RoutedEventArgs e)
        {
            new LogWindow().Show();
            Close();
        }

        private void usersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
    

