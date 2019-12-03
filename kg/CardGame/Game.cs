using System;
using System.Collections.Generic;
using System.IO;

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
            new Card() { MaxSpeed = 10, Weight = 1000},
            new Card() { MaxSpeed = 100, Weight = 700},
            new Card() { MaxSpeed = 200, Weight = 600},
            new Card() { MaxSpeed = 300, Weight = 550},
            new Card() { MaxSpeed = 40, Weight = 500},
            new Card() { MaxSpeed = 50, Weight = 820},
            new Card() { MaxSpeed = 60, Weight = 420},
            new Card() { MaxSpeed = 36, Weight = 330},
            new Card() { MaxSpeed = 23, Weight = 280},
            new Card() { MaxSpeed = 400, Weight = 360},
            new Card() { MaxSpeed = 220, Weight = 822},
            new Card() { MaxSpeed = 180, Weight = 910},
            new Card() { MaxSpeed = 265, Weight = 730},
            new Card() { MaxSpeed = 340, Weight = 1500},
            new Card() { MaxSpeed = 282, Weight = 1660},
            new Card() { MaxSpeed = 12, Weight = 1700},
            new Card() { MaxSpeed = 163, Weight = 1550},
            new Card() { MaxSpeed = 258, Weight = 1200},
            new Card() { MaxSpeed = 313, Weight = 1300},
            new Card() { MaxSpeed = 128, Weight = 1024},
            new Card() { MaxSpeed = 256, Weight = 1536},
        };
        private List<Player> Players = new List<Player>() {
            new Player() { Name = "Gabor" },
            new Player() { Name = "Miklos" },
            new Player() { Name = "Imre" }
        };

        public void Play()
        {
            object o = new object();
            o = Players[0];

            Deck.CardSort(CardEx.SortByMaxSpeed);

            Func<string> func = o.GetType().ToString;

            Random rnd = new Random((int)DateTime.Now.Ticks);

            //Osztás
            for (int i = 0; i < Deck.Length; i++)
            {
                Players[i % Players.Count].Cards.Add(Deck[i]);
            }

            //Játékos választás
            Player player = Players[0];
            int winner = 0;

            int turn = 1;

            do
            {
                //Print :)
                File.WriteAllText($"Turn{turn}.html", ToHtml(Players, winner));

                Card c = new Card();
                File.WriteAllText("teszt.html", c.ToHtml());

                //Hívás váasztás
                CallBase call = Calls[rnd.Next(Calls.Length)];

                Console.WriteLine($"Forduló: {turn}: {call}");

                //Kártya választás
                Card[] cards = new Card[Players.Count];
                for (int i = 0; i < Players.Count; i++)
                {
                    cards[i] = call.BestCard(Players[i].Cards);
                }
                for (int i = 0; i < Players.Count; i++)
                {
                    Console.WriteLine($"{Players[i]}: {cards[i]}");
                    Players[i].Cards.Remove(cards[i]);
                }

                //Nyertes választás
                winner = call.WinnerIndex(cards);
                Console.WriteLine($"Winner: {Players[winner]}");
                Players[winner].Cards.AddRange(cards);

                player = Players[winner];

                //Vesztesek eliminálsa
                for (int i = Players.Count - 1; i >= 0; i--)
                {
                    if (Players[i].Cards.Count == 0)
                    {
                        Console.WriteLine($"{Players[i]} loose.");
                        Players.Remove(Players[i]);
                    }
                }
                //játék vége vizsgálat

                turn++;
            } while (Players.Count > 1);

            Console.WriteLine("A nyertes játékos:");
            Console.WriteLine(Players[0].Name);
        }

        private string ToHtml(List<Player> players, int winner)
        {
            return $@"<!DOCTYPE html>
<html>
<body>
<form method=""GET"">
    <table>
    {players.ToHtml(winner)}
    </table>
</form>
</body>
</html>";
        }
    }
}