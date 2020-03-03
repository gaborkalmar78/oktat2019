using System;

namespace cardgame_mvc.Models
{
    public class Card
    {
        public int Weight { get; set; }


        public int Price { get; set; }
        public int Speed { get; set; }


        public Card(Random r)
        {

            this.Weight = 900 + (r.Next(18) * 100);
            this.Speed = 150 + (r.Next(12) * 10);
            this.Price = 500000 + (r.Next(50) * 500000);

        }

        public static Card[] Generate(int db)
        {
            Random random = new Random();
            Card[] cards = new Card[db];
            for (int i = 0; i < db; i++)
            {
                cards[i] = new Card(random);
            }

            return cards;
        }

        public int Getvalue(string prop)
        {
            switch (prop)
            {
                case "Speed":
                    return Speed;
                    break;
                case "Weight":
                    return Weight;
                    break;
                case "Price":
                    return Price;
                    break;
                default:
                    return 0;
            }
        }


    }
}