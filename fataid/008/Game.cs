using System;
using System.Collections.Generic;
namespace _008
{
    public class Game
    {
        public Game(Card[] cards, List<Player> players)
        {
            NumOfCards = cards.Length;
            //Cards = new List<Card>(cards);
            Players = players;
        }
        private Card[] Deck;
        private List<Player> Players;
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
            //deal
            Deal();
            Player First = Players[0];
            Random rnd = new Random();
            CallBase call = Calls[rnd.Next(Calls.Length];

            //select card
            //select winner
            int winner = call.WinnerIndex()
            //check gameover
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