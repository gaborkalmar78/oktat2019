using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webshop2020.Models
{
    public class Category
    {
        public Category()
        {
            ID = Guid.NewGuid();
            Products = new List<CategoryProduct>();
        }

        public Category(string name, Category parent)
            : this()
        {
            Name = name;
            Parent = parent;
        }

        public Guid ID { get; set; }
        public string Name { get; set; }
        public Category Parent { get; set; } //Navigation property
        public List<Category> Children { get; set; } //Navigation property
        public List<CategoryProduct> Products { get; set; } //Navigation property

    }
}
