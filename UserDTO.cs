namespace ShopWPF.dto
{
    class UserDTO
    {
        public int id;
        public string username;
        public string password;

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
