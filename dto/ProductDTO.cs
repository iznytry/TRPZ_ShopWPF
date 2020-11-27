using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWPF.dto
{
    class ProductDTO
    {
        public int id;
        public string name;
        public int price;
        public string category;
        public int quantity;
        public string status;

        public int Id { get { return id; } }
        public string Name  { get { return name; } }
        public int Price { get { return price; } }
        public string Category { get { return category; } }
        public int Quantity { get { return quantity; } }
        public string Status { get { return status; } }



        public ProductDTO(int id, string name, int price,string category, int quantity,string status)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.category = category;
            this.quantity = quantity;
            this.status = status;

        }
        /*public ProductDTO(int id, string name,int price,string category,int quantity,string status) : this(id, name, price,category,quantity,status, "")
        { }

        public ProductDTO(int id, string name, int price, string category, int quantity, string status) : this(-1, id, name, price, category, quantity, status)
        { }*/


    }
}
