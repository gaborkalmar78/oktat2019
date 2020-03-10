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
            Ranked = false;
            Rank = 0;
        }
        public string Name { get; set; }

        public bool Active
        {
            get { return Deck.Count > 0; }
        }
        public bool Ranked { get; set; }
        public int Rank { get; set; }
        public List<Card> Deck { get; set; }
    }

}