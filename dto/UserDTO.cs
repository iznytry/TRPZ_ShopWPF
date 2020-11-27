using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.dto
{
    class UserDTO
    {
        public int id;
        public string username;
        public string password;

        public int Id { get { return id; } }
        public string Username { get { return username; } }

        public UserDTO(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }

        public UserDTO(int id, string username) : this(id, username, "")
        { }

        public UserDTO(string username, string password) : this(-1, username, password)
        { }
    }
}
