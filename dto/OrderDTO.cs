using System;

namespace ShopWPF.dto
{
    class OrderDTO
    {
        public int id;
        public UserDTO user;
        public ProductDTO product;
        public DateTime orderTime;

        public int Id { get { return id; } }
        public DateTime OrderTime { get { return orderTime; } }

        public OrderDTO(UserDTO user, ProductDTO product,DateTime orderTime)
            : this(-1,user, product, orderTime)
        { }

        public OrderDTO(int id,DateTime orderTime)
            : this(id, null, null, orderTime)
        { }

        public OrderDTO(int id, UserDTO user,ProductDTO product, DateTime orderTime)
        {
            this.id = id;
            this.product = product;
            this.user = user;
            this.orderTime = orderTime;
            
           
        }
    }
}

