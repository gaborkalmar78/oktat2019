using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2020.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(Category[] categories, Product product)
        {
            Categories = categories;
            Product = product;
        }

        public Category[] Categories { get; set; }
        public Product Product { get; set; }
    }
}
