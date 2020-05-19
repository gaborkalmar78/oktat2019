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
        public static T[] Where<T>(this GenericList<T> clist, Func<T, bool> func)
        {
            List<T> temp = new List<T>();
            for (int i = 0; i < clist.Items.Length; i++)
            {
                if (func(clist.Item(i)))
                {
                    temp.Add(clist.Item(i));
                }
            }
            return temp.ToArray();
        }
    }
}
