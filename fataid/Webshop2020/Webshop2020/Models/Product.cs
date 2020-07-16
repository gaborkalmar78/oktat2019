using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2020.Models
{
    public class Product
    {
        public Product()
        {
            ID = Guid.NewGuid();
            Categories = new List<CategoryProduct>();
            CartItems = new List<CartItem>();
        }

        public Product(string name, int price, int stock)
            : this()
        {
            Name = name;
            Price = price;
            Stock = stock;
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public List<CategoryProduct> Categories { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
