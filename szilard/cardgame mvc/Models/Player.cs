using System.Collections.Generic;

namespace cardgame_mvc.Models
{
    public class Player
    {
        public List<Card> Deck { get; set; }
        public string Name { get; set; }

        public int Rank { get; set; }

        public Player(string Name)

        {
            this.Name = Name;
            Deck = new List<Card>();
            Rank = 0;
        }

        public void UppDateRank()
        {
            if (Deck.Count == 0)
            {
                Rank++;
            }
        }
    }
}