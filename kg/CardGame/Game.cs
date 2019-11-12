using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Game
    {
        private CallBase[] Calls = new CallBase[2];

        private Card[] Deck = new Card[0];
        private List<Player> Players = new List<Player>();

        public void Play()
        {
            Random rnd = new Random();

            //Osztás
            for (int i = 0; i < Deck.Length; i++)
            {
                Players[i % Players.Count].Cards.Add(Deck[i]);
            }

            //Játékos választás
            Player player = Players[0];

            //Hívás váasztás
            CallBase call = Calls[rnd.Next(Calls.Length)];

            //Kártya választás
            Card[] cards = new Card[Players.Count];
            for (int i = 0; i < Players.Count; i++)
            {
                cards[i] = call.BestCard(Players[i].Cards);
            }
            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Cards.Remove(cards[i]);
            }

            //Nyertes választás
            int winner = call.WinnerIndex(cards);
            Players[winner].Cards.AddRange(cards);

            player = Players[winner];

            //játék vége vizsgálat
        }
    }
}