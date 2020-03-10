using System;

namespace _019.Models
{
    public class Card
    {
        public static Card[] Generate(int size)
        {
            Card[] deck = new Card[size];
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                deck[i] = new Card(random);
            }
            return deck;
        }
        public Card(Random rand)
        {

            Weight = 900 + 100 * rand.Next(17);
            Speed = 150 + 10 * rand.Next(11);
            Price = 500000 + 500000 * rand.Next(50);
        }
        public int Weight { get; set; }
        public int Speed { get; set; }
        public int Price { get; set; }
        public int Strength(string prop)
        {
            switch (prop)
            {
                case "Weight":
                    return Weight;
                case "Speed":
                    return Speed;
                case "Price":
                    return Price;
                default:
                    return 0;
            }
        }
    }
}