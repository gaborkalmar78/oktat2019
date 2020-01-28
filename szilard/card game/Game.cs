using System;

namespace card_game
{
    public static class Game
    {
        static Card[] Deck;
        static Player[] Players = new Player[0];

        public static void play(Player[] players)
        {
            Deck = Card.CreateDeck(12);
            for (int i = 0; i < Deck.Length; i++)
            {
                players[i % players.Length].Hand.Add(Deck[i]);
            }

            Func<Card, Card, bool>[] functions = new Func<Card, Card, bool>[4];
            functions[0] = byMaySpeed;


            Card[] deskcard = null;
            int winner = buborek(deskcard, byMaySpeed);




            //eredmény
        }



        public static int buborek(Card[] cards, Func<Card, Card, bool> fugg)
        {
            int[] index = new int[Players.Length];
            Card temp1;
            int temp2;

            for (int i = 0; i < Players.Length; i++)
            {
                index[i] = i;
            }

            for (int i = 0; i < Players.Length; i++)
            {
                for (int a = 1; a < Players.Length; a++)
                {
                    if (!fugg(cards[a], cards[a - 1]))
                    {

                        temp1 = cards[a - 1];
                        cards[a - 1] = cards[a];
                        cards[a] = temp1;
                        temp2 = index[a - 1];
                        index[a - 1] = index[a];
                        index[a] = temp2;
                    }
                }
            }
            return index[0];
        }

        private static bool byMaySpeed(Card a, Card b)

        {
            return a.MaXSpeed > b.MaXSpeed;
        }

    }
}