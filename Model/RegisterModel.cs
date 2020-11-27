using MySqlConnector;
using System;
using System.ComponentModel;
using System.Data;
using ShopWPF.dto;
using ShopWPF.Service;

namespace ShopWPF.Model
{
    class RegisterModel : INotifyPropertyChanged
    {
        private string _errMsg;
        public string ErrorMessage
        {
            get
            {
                return _errMsg;
            }
            set
            {
                _errMsg = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public bool tryRegister(UserDTO user)
        {
            if (userExists(user))
            {
                ErrorMessage = "User already exists";
                return false;
            }
            createUser(user);
            return true;
        }


        private Boolean userExists(UserDTO user)
        {
            using (MySqlConnection connection = ConnectionManager.getConnection())
            {
                string queryString = "SELECT EXISTS(SELECT id FROM `Users` WHERE username=@username)";
                MySqlCommand command = new MySqlCommand(queryString, connection);

                MySqlParameter usernameParam = new MySqlParameter("@username", SqlDbType.VarChar);
                usernameParam.Value = user.username;
                command.Parameters.Add(usernameParam);
                command.Connection.Open();
                return command.ExecuteScalar().ToString().Equals("1");
            }
        }

        private void createUser(UserDTO user)
        {
            using (MySqlConnection connection = ConnectionManager.getConnection())
            {
                string queryString = "INSERT INTO `Users`(username, password) VALUES(@username, @password)";
                MySqlCommand command = new MySqlCommand(queryString, connection);

                MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar);
                usernameParam.Value = user.username;
                command.Parameters.Add(usernameParam);

                MySqlParameter passwordParam = new MySqlParameter("@password", MySqlDbType.VarChar);
                passwordParam.Value = HashingService.GetHash(user.password);
                command.Parameters.Add(passwordParam);

                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}