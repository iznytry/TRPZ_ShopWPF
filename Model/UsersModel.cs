using MySqlConnector;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ShopWPF.dto;

namespace ShopWPF.Model
{
    class UsersModel : INotifyPropertyChanged
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
        public ObservableCollection<UserDTO> usersList { get; } = new ObservableCollection<UserDTO>();

        public event PropertyChangedEventHandler PropertyChanged;



        public UsersModel(string username)
        {
            Username = username;
            loadAllUserOrders(Username);
        }

        public UsersModel()
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
                string queryString = "SELECT Id, username " +
                "FROM Users ";

                MySqlCommand command = new MySqlCommand(queryString, connection);

                MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar);
                usernameParam.Value = username;
                command.Parameters.Add(usernameParam);

                command.Connection.Open();
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    usersList.Add(new UserDTO(dr.GetInt32(0), dr.GetString(1)));
                }

                OnPropertyChanged("usersList");
            }
        }

    }

}


