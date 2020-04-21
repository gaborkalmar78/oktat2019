using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_021.Models
{
    public static class CategoryEx
    {
        public static void Rename1(this Category category)
        {
            category.Title = "mas1";
        }
    }
}
