using System.Collections.Generic;

namespace CardGame
{
    public class Player
    {
        public string Name { get; set; }

        private List<Card> cards = new List<Card>();
        public List<Card> Cards
        {
            get { return cards; }
            private set { cards = value; }
        }
    }
}