using Remotion.Linq.Clauses;
using System;
using System.Collections.Generic;

namespace project_021.Models
{
    public static class GenericListEx
    {
        public static int Count<T>(this GenericList<T> glist)
        {
            return glist.Items.Length;
            //return 0;
        }
        public static T[] Reverse<T>(this GenericList<T> glist)
        {
            //GenericList<T> nlist = new GenericList<T>();
            //for(int i=glist.Count()-1; i>=0; i--)
            //{
            //    nlist.Add(glist.Item(i));
            //}
            //return nlist.Items;
            int iC = glist.Items.Length-1;
            T[] items = new T[glist.Items.Length];
            for (int i=0; i<=iC; i++)
            {
                items[i] = glist.Item(iC-i);
            }
            return items;
        }
        public static T[] Part<T>(this GenericList<T> glist, int start, int length)
        {
            T[] items = new T[length];
            for (int i = 0; i<length; i++)
            {
                items[i] = glist.Item(start + i);
            }
            return items;
        }
        public static T[] First<T>(this GenericList<T> glist, int length)
        {
            T[] items = new T[length];
            for (int i = 0; i < length; i++)
            {
                items[i] = glist.Item(i);
            }
            return items;
        }
        public static T[] Last<T>(this GenericList<T> glist, int length)
        {
            T[] items = new T[length];
            int iC = glist.Items.Length-length;
            for (int i = 0; i < length; i++)
            {
                items[i] = glist.Item(iC+i);
            }
            return items;
        }
        public static T[] Where<T>(this GenericList<T> glist, Func<T, bool> func)
        {
            List<T> temp = new List<T>();
            for (int i = 0; i < glist.Items.Length; i++)
            {
                if(func(glist.Item(i)))
                {
                    temp.Add(glist.Item(i));
                }
            }
            return temp.ToArray();
        }
        public static bool X<T>(T item)
        {
            return false;
        }
    }
}
