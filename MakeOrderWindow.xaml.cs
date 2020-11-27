using MySql.Data.MySqlClient;
using ShopWPF.dto;
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
    /// Interaction logic for MakeOrderWindow.xaml
    /// </summary>
    public partial class MakeOrderWindow : Window
    {
        private OrderModel _model = new OrderModel();

        public string Username { get; private set; }

        public MakeOrderWindow()
        {
            DataContext = _model;
           
            InitializeComponent();
            

            try
            {
                MySqlConnection connection = new MySqlConnection("server = localhost; user = root; password = Vickotya27; database = shop");

                string selectName = "SELECT * FROM shop.product";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectName, connection);
                MySqlDataReader reader = command.ExecuteReader();
               

                while (reader.Read())
                {
                    comboBox1.Items.Add(new ProductDTO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4), reader.GetString(5)));

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
      /*  private ProductDTO selectedPerson = new ProductDTO();

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set { selectedPerson = value; OnPropertyChanged(); }
        }
*/


        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }

        private void ButtonBack1_Click(object sender, RoutedEventArgs e)
        {
            new GoodsWindow(Name).Show();
            Close();
        }

        private void comboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ProductDTO selectedProduct = (ProductDTO)comboBox1.SelectedItem;

            priceText.Text = selectedProduct.price.ToString();
            categoryText.Text = selectedProduct.category;
          
        }

      
        private void ButtonMakeOrder_Click(object sender, RoutedEventArgs e)
        {

            ProductDTO selectedProduct = (ProductDTO)comboBox1.SelectedItem;
            //user.id(створти змінну)
            UserDTO selectedUser = new UserDTO(1, "vic");
            string product_id = selectedProduct.id.ToString();
            DateTime time_order =new DateTime();
            //insert in database;
            OrderDTO order = new OrderDTO(selectedUser,selectedProduct,time_order);
            _model.saveOrder(order);



        }

        private void priceText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void categoryText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

