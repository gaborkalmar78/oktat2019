using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2020.Models
{
    public class IndexViewModel
    {
        public IndexViewModel(Category[] categories, Product[] product)
        {
            Categories = categories;
            Products = product;
        }

        public Category[] Categories { get; set; }
        public Product[] Products { get; set; }
    }
}
