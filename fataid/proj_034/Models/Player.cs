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
            OriginalID = -1;
            Rank = 0;
            LookAtTable = false;
            CheckedTable = false;
        }
        public string Name { get; set; }

        public bool Active
        {
            get { return Deck.Count > 0; }
        }
        public int Rank { get; set; }
        public int OriginalID { get; set; }
        public bool LookAtTable { get; set; }
        public bool CheckedTable { get; set; }
        public List<Card> Deck { get; set; }
        public Game MyGame { get; set; }
    }

}