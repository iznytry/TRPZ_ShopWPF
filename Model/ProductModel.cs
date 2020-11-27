
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ShopWPF.dto;

namespace ShopWPF.Model
{
    class ProductModel : INotifyPropertyChanged
    {

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public ObservableCollection<ProductDTO> productsList { get; } = new ObservableCollection<ProductDTO>();

        public event PropertyChangedEventHandler PropertyChanged;



        public ProductModel(string name)
        {
            Name = name;
            loadAllUserOrders(Name);
        }

        public ProductModel()
        {

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void loadAllUserOrders(string Name)
        {
            using (MySqlConnection connection = ConnectionManager.getConnection())
            {
                string queryString = "SELECT id, name, price,category,quantity, status " +
                "FROM product ";

                MySqlCommand command = new MySqlCommand(queryString, connection);

                //MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar);
                //usernameParam.Value = username;
                //command.Parameters.Add(usernameParam);

                command.Connection.Open();
                MySqlDataReader dr1 = command.ExecuteReader();
                while (dr1.Read())
                {
                    productsList.Add(new ProductDTO(dr1.GetInt32(0), dr1.GetString(1), dr1.GetInt32(2), dr1.GetString(3), dr1.GetInt32(4), dr1.GetString(5)));
                }

                OnPropertyChanged("productsList");
            }
        }
        public ProductDTO getProductByName(string name)
        {
            using (MySqlConnection connection = ConnectionManager.getConnection())
            {
                string queryString = "SELECT id FROM `product` WHERE name=@name";
                MySqlCommand command = new MySqlCommand(queryString, connection);

                MySqlParameter usernameParam = new MySqlParameter("@name", MySqlDbType.VarChar);
                usernameParam.Value = name;
                command.Parameters.Add(usernameParam);

                command.Connection.Open();
                MySqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    return new ProductDTO(dr.GetInt32(0), name, dr.GetInt32(2), dr.GetString(3), dr.GetInt32(4), dr.GetString(5));
                }
                throw new NullReferenceException("Could not find product");
            }

        }


    }
}
