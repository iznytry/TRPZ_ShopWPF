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
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow : Window
    {
        private LoginModel _model = new LoginModel();

        public string Username { get; private set; }

        public LogWindow()
        {
            InitializeComponent();
            DataContext = _model;
        }
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Password;
            if (_model.tryLogin(new dto.UserDTO(username, password)))
            {
                goToMainWindow(username);
            }
        }
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow maiWindow = new MainWindow();
            maiWindow.Show();
            Close();
        }
        private void goToMainWindow(string username)
        {
            new MainWindow().Show();
            Close();
        }



        private void goToRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameText.Text;
            string password = passwordText.Password;
            if (_model.tryLogin(new dto.UserDTO(username, password)))
            {
                goToMainWindow(username);
            }
        }


        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            new UsersWindow(Username).Show();
            Close();
        }

        private void SingButton_Click(object sender, RoutedEventArgs e)
        {
            new SingWindow().Show();
            Close();

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            MessageBox.Show(textBox.Text);
        }
    }
}