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
    /// Interaction logic for SingWindow.xaml
    /// </summary>
    public partial class SingWindow : Window
    {
        private RegisterModel _model = new RegisterModel();
        public string Username { get; private set; }
        public SingWindow()
        {
            InitializeComponent();
            DataContext = _model;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow maiWindow = new MainWindow();
            maiWindow.Show();
            Close();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Password;
            bool result = _model.tryRegister(new dto.UserDTO(username, password));
            if (result)
            {
                goToLogWindow();
            }

        }
        private void goToLogWindow()
        {
            new LogWindow().Show();
            Close();
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            new UsersWindow(Username).Show();
            Close();
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            new LogWindow().Show();
            Close();
        }
    }
    
}
