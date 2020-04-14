using System;
using System.Collections.Generic;
using System.Reflection;

namespace project_020
{
    class Program
    {
        // static Dictionary<string, object> dict1 = new Dictionary<string, object>();
        static Dictionary<Type, object> dict1 = new Dictionary<Type, object>();

        static void Invoke(object obj, string name)
        {
            var t = obj.GetType();
            MethodInfo m = t.GetMethod(name);
            ParameterInfo[] pis = m.GetParameters();
            object[] ps = new object[pis.Length]; //ps mint parameters
            // foreach (ParameterInfo pi in pis)
            for (int i = 0; i < pis.Length; i++)
            {
                ps[i] = dict1[pis[i].ParameterType];
                //pi.ParameterType
            }
            m.Invoke(obj, ps);
        }

        static void Main(string[] args)
        {
            //dict1[typeof(List<string>)] = new List<string>();
            dict1[typeof(List<string>)] = new List<string>();
            dict1[typeof(int)] = 1;
            dict1[typeof(DateTime)] = DateTime.Now;
            dict1[typeof(string)] = "Henry";
            //dict1["dolog3"] = (int param1, int param2) => { return param1 + param2 };
            //dict1["dolog3"] = Console.WriteLine;
            //Console.WriteLine("Hello World!");
            Welcome welc = new Welcome();
            // welc.Do((string)dict1["dolog4"], (DateTime)dict1["dolog3"]);
            //welc.Do((string)dict1[typeof(string)], (DateTime)dict1[typeof(DateTime)]);
            Invoke(welc, "Do");
        }
    }
    class Welcome
    {
        public void Do(string name, DateTime time, int counter)
        {
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine($"Üdvözöllek kedves {name}!");
                Console.WriteLine($"Pontos idő: {time}");
            }
        }
    }
}
