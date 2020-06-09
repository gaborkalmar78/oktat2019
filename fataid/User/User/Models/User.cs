using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User.Models
{
    public class User
    {
        public User()
        {
            ID = Guid.NewGuid();
        }

        public User(string name, string password)
            : this()
        {
            Name = name;
            Password = password;
        }

        public Guid ID { get; set; }
        [Display(Name="Név", Description ="Ez a felhasználó neve", Prompt ="Gipsz Jakab")]
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
