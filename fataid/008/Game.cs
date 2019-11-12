using System;
using System.Collections.Generic;
namespace _008
{
    public class Game
    {
        private CallBase[] Calls = new CallBase[2];

        private Card[] Deck = new Card[0];
        private List<Player> Players = new List<Player>();

        public Game(Card[] cards, List<Player> players)
        {
            NumOfCards = cards.Length;
            //Cards = new List<Card>(cards);
            Players = players;
        }
        private int NumOfCards = 0;

        public void Deal()
        {
            int MaxDeal = (Deck.Length / Players.Count) * Players.Count;
            for (int i = 0; i < MaxDeal; i++)
            {
                Players[i % Players.Count].Cards.Add(Deck[i]);
            }
        }
        public void Play()
        {
            //shuffle
            //Shuffle();
            //deal
            Deal();
            Player First = Players[0];
            Random rnd = new Random((int)DateTime.Now.Ticks);
            do
            {
                CallBase call = Calls[rnd.Next(Calls.Length)];

                //select card
                Card[] cards = new Card[Players.Count];
                for (int i = 0; i < Players.Count; i++)
                {
                    cards[i] = call.BestCard(Players[i].Cards);
                }
                for (int i = 0; i < Players.Count; i++)
                {
                    Players[i].Cards.Remove(cards[i]);
                }

                //select winner
                int winner = call.WinnerIndex(cards);
                Players[winner].Cards.AddRange(cards);

                First = Players[winner];
                //check gameover
            } while (Players.Count > 1);
        }

        public Player WhoIsWinner()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                if (Players[i].Cards.Count == NumOfCards)
                {
                    return Players[i];
                }
            }
            return null;
        }
    }

    // public void Shuffle()
    // {
    //     List<Card> Original = new List<Card>(Cards);
    //     Cards.Clear();
    //     Random rand = new Random();
    //     for (int i = 0; i < NumOfCards; i++)
    //     {
    //         int iR = rand.Next(Original.Count);
    //         Cards.Add(Original[iR]);
    //         Original.RemoveAt(iR);

    //     }
    // }
}