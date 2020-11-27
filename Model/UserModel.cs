using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using ShopWPF.dto;

namespace ShopWPF.Model
{
    class UserModel
    {

        public UserDTO getUserByUsername(string username)
        {
            using (MySqlConnection connection = ConnectionManager.getConnection())
            {
                string queryString = "SELECT id FROM `Users` WHERE username=@username";
                MySqlCommand command = new MySqlCommand(queryString, connection);

                MySqlParameter usernameParam = new MySqlParameter("@username", MySqlDbType.VarChar);
                usernameParam.Value = username;
                command.Parameters.Add(usernameParam);

                command.Connection.Open();
                MySqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    return new UserDTO(dr.GetInt32(0), username);
                }
                throw new NullReferenceException("Could not find user");
            }
        }


    }
}