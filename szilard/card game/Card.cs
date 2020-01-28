using System;

namespace card_game
{
    public class Card
    {
        private int maxspeed = 0;
        public int MaXSpeed
        {
            get { return MaXSpeed; }
            set { maxspeed = value; }
        }




        public string Name { get; set; }
        public int Weight { get; set; }

        public int EngineSize { get; set; }

        public Card(Random rnd)
        {
            maxspeed = rnd.Next(160, 260);
            Weight = rnd.Next(1000, 2150);
            EngineSize = rnd.Next(650, 6500);
        }

        public static Card[] CreateDeck(int Count)
        {

            Random random = new Random();

            Card[] Deck = new Card[Count];
            for (int i = 0; i < Count; i++)
            {
                Deck[i] = new Card(random);
            }

            return Deck;

        }

    }
}