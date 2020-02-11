using System;
using System.Collections.Generic;

namespace _019.Models
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Deck = new List<Card>();
        }
        public string Name { get; set; }
        public List<Card> Deck { get; set; }
    }
}