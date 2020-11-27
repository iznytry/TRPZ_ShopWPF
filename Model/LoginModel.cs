using MySqlConnector;
using System;
using System.ComponentModel;
using System.Data;
using ShopWPF.dto;
using ShopWPF.Service;

namespace ShopWPF.Model
{
    class LoginModel : INotifyPropertyChanged
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

        public bool tryLogin(UserDTO user)
        {
            return checkIfUserExistsAndSetErrorMessage(user) && checkIfCredentialsMatchAndSetErrorMessage(user);
        }

        private bool checkIfUserExistsAndSetErrorMessage(UserDTO user)
        {
            if (!checkIfUserExists(user))
            {
                ErrorMessage = "User not found";
                return false;
            }
            return true;
        }

        private bool checkIfCredentialsMatchAndSetErrorMessage(UserDTO user)
        {
            if (!checkCredentials(user))
            {
                ErrorMessage = "Incorrect password";
                return false;
            }
            return true;
        }

        private bool checkCredentials(UserDTO user)
        {
            using (MySqlConnection connection = ConnectionManager.getConnection())
            {
                string queryString = "SELECT EXISTS(SELECT id FROM `Users` WHERE username=@username AND password=@password)";
                MySqlCommand command = new MySqlCommand(queryString, connection);

                MySqlParameter usernameParam = new MySqlParameter("@username", SqlDbType.VarChar);
                usernameParam.Value = user.username;
                command.Parameters.Add(usernameParam);

                MySqlParameter passwordParam = new MySqlParameter("@password", SqlDbType.VarChar);
                passwordParam.Value = HashingService.GetHash(user.password);
                command.Parameters.Add(passwordParam);

                command.Connection.Open();
                return command.ExecuteScalar().ToString().Equals("1");
            }
        }

        private Boolean checkIfUserExists(UserDTO user)
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


    }
}
