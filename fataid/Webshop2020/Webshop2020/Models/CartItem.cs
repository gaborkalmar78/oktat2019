using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2020.Models
{
    public class CartItem
    {
        public CartItem()
        {
            ID = Guid.NewGuid();
        }
        public CartItem(Product product, int count, Cart cart)
            : this()
        {
            Product = product;
            Count = count;
            Cart = Cart;
        }
        public Guid ID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public Cart Cart { get; set; }
    }
}
