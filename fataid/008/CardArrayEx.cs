using System;
using System.Collections.Generic;

namespace _008
{
    public static class CardArrayEx
    {
        // public static void Shuffle(this Card[] cards)
        // {
        //     cards.Shuffle(100);
        // }
        public static void Shuffle(this Card[] cards, int Counter = 100)
        {
            Random rnd = new Random();
            int c1, c2;
            Card temp;
            for (int i = 0; i < Math.Max(Counter, 100); i++)
            {
                c1 = rnd.Next(cards.Length);
                do
                {
                    c2 = rnd.Next(cards.Length);
                } while (c1 == c2);
                temp = cards[c1];
                cards[c1] = cards[c2];
                cards[c2] = temp;
            }
        }
        public static void SortByAttribute(this Card[] cards, Func<Card, Card, bool> function)
        {
            Card temp;
            for (int i = 0; i < cards.Length; i++)
            {
                for (int j = 1; j < cards.Length - i; j++)
                {
                    if (function(cards[j - 1], cards[j]))
                    {
                        temp = cards[j - 1];
                        cards[j - 1] = cards[j];
                        cards[j] = temp;
                    }
                }
            }
        }
        public static bool SortCardsBySpeed(Card c1, Card c2)
        {
            return c1.MaxSpeed > c2.MaxSpeed;
        }
    }
}