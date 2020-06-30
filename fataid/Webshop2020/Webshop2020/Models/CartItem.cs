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
        public CartItem(Product product, int count)
            : this()
        {
            Product = product;
            Count = count;
        }
        public Guid ID { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
