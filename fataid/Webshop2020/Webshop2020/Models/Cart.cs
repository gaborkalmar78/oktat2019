using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2020.Models
{
    public class Cart
    {
        public Cart()
        {
            ID = Guid.NewGuid();
            Items = new List<CartItem>();
            Buyer = string.Empty;
        }
        public Guid ID { get; set; }
        public List<CartItem> Items { get; set; }
        public string Buyer { get; set; }
    }
}
