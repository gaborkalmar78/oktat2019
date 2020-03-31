using System;
using System.Collections.Generic;

namespace _019.Models
{
    public class User
    {
        public User(string iD, string name)
        {
            ID = iD;
            Name = name;
        }

        public string ID { get; set; }
        public string Name { get; set; }
    }
}