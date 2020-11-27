using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ShopWPF.dto;
using MySqlConnector;

namespace ShopWPF.Model
{
    class OrderModel : INotifyPropertyChanged
    {

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }
        public ObservableCollection<OrderDTO> ordersList { get; } = new ObservableCollection<OrderDTO>();

        public event PropertyChangedEventHandler PropertyChanged;



        public OrderModel(string username)
        {
            Username = username;
            loadAllUserOrders(Username);
        }

        public OrderModel()
        {

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void loadAllUserOrders(string username)
        {
            using (MySqlConnection connection = ConnectionManager.getConnection())
            {
                string queryString = "SELECT order_id, time_order " +
                "FROM orders1 " +
                "JOIN Users ON orders1.user_id= `Users`.id " +
                "WHERE `Users`.id=@id ";

                MySqlCommand command = new MySqlCommand(queryString, connection);

                MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar);
                usernameParam.Value = username;
                command.Parameters.Add(usernameParam);

                command.Connection.Open();
                MySqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    ordersList.Add(new OrderDTO(dr.GetInt32(0),dr.GetDateTime(3)));
                }
                OnPropertyChanged("ordersList");
            }
        }

        public void saveOrder(OrderDTO order)
        {
            using (MySqlConnection connection = ConnectionManager.getConnection())
            {
                string queryString = "INSERT INTO " +
                    "orders1(product_name,user_id, time_order) " +
                    "VALUES(@product_name,@user_id, NOW())";
                MySqlCommand command = new MySqlCommand(queryString, connection);


                MySqlParameter usernameParam = new MySqlParameter("@user_id", MySqlDbType.Int32);
                usernameParam.Value = order.user.id;
                command.Parameters.Add(usernameParam);

                MySqlParameter productParam = new MySqlParameter("@product_name", MySqlDbType.String);
                productParam.Value = order.product.name;
                command.Parameters.Add(productParam);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
