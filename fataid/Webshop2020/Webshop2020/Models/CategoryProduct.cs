using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2020.Models
{
    public class CategoryProduct
    {
        public CategoryProduct()
        {

        }
        public CategoryProduct(Category category, Product product)
        {
            Category = category;
            Product = product;
        }

        public Category Category { get; set; } //navigation property
        public Product Product { get; set; } //navigation property

        public Guid CategoryID { get; set; }
        public Guid ProductID { get; set; }
    }
}
