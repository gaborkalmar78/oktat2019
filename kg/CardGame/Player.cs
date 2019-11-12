using System.Collections.Generic;

namespace CardGame
{
    public class Player
    {
        private List<Card> cards;
        public List<Card> Cards
        {
            get { return cards; }
            private set { cards = value; }
        }
    }
}