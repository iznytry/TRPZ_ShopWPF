using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace ShopWPF.Model
{
    sealed class ConnectionManager
    {

        private ConnectionManager() { }

        private static string connectionString = "server=localhost;user=root;password=Vickotya27;database=shop";

        public static MySqlConnection getConnection()
        {
            return new MySqlConnection(connectionString);
        }

    }
}
