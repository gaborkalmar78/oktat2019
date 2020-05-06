using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace project_021.Models
{
    public class GenericList<T>
    {
        public GenericList()
        {
           items = new T[0];
        }

        private T[] items;
        public T[] Items {
            get { return items; }
        }
        public void Add(T item)
        {
            T[] temp = items;
            items = new T[temp.Length + 1];
            for (int i = 0; i < temp.Length; i++)
            {
                items[i] = temp[i];
            }
            items[temp.Length] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index > (items.Length - 1))
            {
                return;
            }
            T[] temp = items;
            items = new T[temp.Length - 1];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = i < index ? temp[i] : temp[i + 1];
            }
        }

        public T Item(int index)
        {
            if (index < 0 || index > (items.Length - 1))
            {
                throw new ArgumentOutOfRangeException();
            }
            return items[index];
        }
    }

    public class TopicList
    {
        //topic elemeket tartalmazzon
        //legyen add funkciója topic paraméterrel
        public TopicList()
        {
            topics = new Topic[0];
        }

        private Topic[] topics;

       // public Topic[] Topics { get; set; }

        public void Add(Topic topic)
        {
            Topic[] temp = topics;
            topics = new Topic[temp.Length + 1];
            for(int i=0; i<temp.Length; i++)
            {
                topics[i] = temp[i];
            }
            topics[temp.Length] = topic;
            //topics[topics.Length-1] = topic;
        }

        public void RemoveAt(int index)
        {
            if(index<0||index>(topics.Length-1))
            {
                return;
            }
            Topic[] temp = topics;
            topics = new Topic[temp.Length - 1];
            for(int i=0; i<topics.Length; i++)
            {
                //if(j==index)
                //{
                //    j++;
                //    //vagy az alábbi két sor kell, és a felső nem
                //    //i--;
                //    //continue;
                //}
                //topics[i] = temp[j];
                topics[i] = i<index ? temp[i]:temp[i+1];
            }
        }

        public Topic Item(int index)
        {
            if (index < 0 || index > (topics.Length - 1))
            {
                return null;
                //
            }
            return topics[index];
        }
    }
}
