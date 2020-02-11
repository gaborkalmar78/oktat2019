using System.Collections.Generic;

namespace cardgame_mvc.Models
{
    public class Player
    {
        public List<Card> Deck { get; set; }
        public string Name { get; set; }

        public Player(string Name)

        {
            this.Name = Name;
            Deck = new List<Card>();
        }
    }
}