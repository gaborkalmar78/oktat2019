using System.Collections.Generic;

namespace cardgame_mvc.Models
{
    public class Game
    {
        public Player[] Players { get; set; }
        public Card[] Deck { get; set; }

        private int index = 0;

        public int ActualPlayer { get; set; }

        public static Game Instance { get; set; }

        public int Callee { get; set; }

        public string Prop { get; set; }

        public int[] Cards { get; set; }
        public Game(Card[] deck, string[] names)
        {
            Deck = deck;
            Players = new Player[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                Players[i] = new Player(names[i]);
            }
            index = Deck.Length;

            ActualPlayer = 0;

            Callee = 0;

            Prop = null;

            Cards = new int[Players.Length];


        }

        public void Deal(int count)
        {


            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < Players.Length; i++)
                {
                    index--;
                    Players[i].Deck.Add(Deck[index]);
                }
            }


        }

        public void Next()
        {
            ActualPlayer = (ActualPlayer + 1) % Players.Length;
        }

        public int GetWinner()
        {
            int best = 0;

            while (Players[best].Deck.Count == 0)
            {
                best++;
            }

            for (int i = best + 1; i < Players.Length; i++)

            {
                if (Players[i].Deck.Count != 0)
                {
                    Card card1 = Players[i].Deck[Cards[i]];
                    Card card2 = Players[best].Deck[Cards[best]];
                    if (card1.Getvalue(Prop) > card2.Getvalue(Prop))
                    {
                        best = i;
                    }
                }
            }

            return best;
        }

        public void MoveCarsdToPLayer(int best)
        {
            List<Card> cards = new List<Card>();
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Deck.Count != 0)
                {
                    cards.Add(Players[i].Deck[Cards[i]]);
                    Players[i].Deck.RemoveAt(Cards[i]);
                }

            }
            Players[best].Deck.AddRange(cards);
        }

        public bool EndOfTurn()
        {
            return ActualPlayer == Callee;
        }

        public bool EndOFGame()
        {
            int count = 0;
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Deck.Count > 0)
                {
                    count++;
                }

            }
            return count == 1;
        }

        public void UppDateRanks()
        {
            for (int i = 0; i < Players.Length; i++)
            {
                Players[i].UppDateRank();
            }
        }
    }
}