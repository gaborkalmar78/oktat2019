using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Game
    {
        private CallBase[] Calls = new CallBase[]
        {
            new MaxSpeedCall(),
            new MinSpeedCall(),
            new MaxWeightCall(),
            new MinWeightCall()
        };

        private Card[] Deck = new Card[]
        {
            new Card() { MaxSpeed = 10, Weight = 120 },
            new Card() { MaxSpeed = 100, Weight = 120 },
            new Card() { MaxSpeed = 200, Weight = 120 },
            new Card() { MaxSpeed = 300, Weight = 120 },
            new Card() { MaxSpeed = 40, Weight = 120 },
            new Card() { MaxSpeed = 50, Weight = 120 },
            new Card() { MaxSpeed = 60, Weight = 120 },
        };
        private List<Player> Players = new List<Player>() {
            new Player() { Name = "Imre" },
            new Player() { Name = "Miklos" },
            new Player() { Name = "Gabor" }
        };

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

            do
            {
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

                //Vesztesek eliminálsa
                for (int i = Players.Count - 1; i >= 0; i--)
                {
                    if (Players[i].Cards.Count == 0)
                    {
                        Players.Remove(Players[i]);
                    }
                }
                //játék vége vizsgálat
            } while (Players.Count > 1);

            Console.WriteLine("A nyertes játékos:");
            Console.WriteLine(Players[0].Name);
        }
    }
}