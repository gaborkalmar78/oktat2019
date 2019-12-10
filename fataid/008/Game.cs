using System;
using System.Collections.Generic;
using System.IO;

namespace _008
{
    public class Game
    {
        private CallBase[] Calls = new CallBase[]{
            new MaxSpeedCall(),
            new MinSpeedCall(),
            new MaxWeightCall(),
            new MinWeightCall()
        };

        // private Card[] Deck = new Card[]{
        // new Card() {Name = "car1", MaxSpeed = 10, Weight = 1500, Price = 0, Brand = "", Engine = 0},
        // new Card() {Name = "car2", MaxSpeed = 100, Weight = 1300, Price = 0, Brand = "", Engine = 0},
        // new Card() {Name = "car3", MaxSpeed = 200, Weight = 1280, Price = 0, Brand = "", Engine = 0},
        // new Card() {Name = "car4", MaxSpeed = 300, Weight = 1400, Price = 0, Brand = "", Engine = 0},
        // new Card() {Name = "car5", MaxSpeed = 40, Weight = 1460, Price = 0, Brand = "", Engine = 0},
        // new Card() {Name = "car6", MaxSpeed = 128, Weight = 1190, Price = 0, Brand = "", Engine = 0},
        // new Card() {Name = "car7", MaxSpeed = 256, Weight = 1380, Price = 0, Brand = "", Engine = 0},
        // new Card() {Name = "car8", MaxSpeed = 80, Weight = 1200, Price = 0, Brand = "", Engine = 0},
        // new Card() {Name = "car9", MaxSpeed = 180, Weight = 1600, Price = 0, Brand = "", Engine = 0},
        // new Card() {Name = "car10", MaxSpeed = 230, Weight = 1510, Price = 0, Brand = "", Engine = 0},
        // };
        private Card[] Deck = CardEx.CreateDeck(8);
        private List<Player> Players = new List<Player>(){
            new Player() { Name = "Imre" },
            new Player() { Name = "Miklos" },
            new Player() { Name = "Gabor" }
        };

        // public Game(Card[] cards, List<Player> players)
        // {
        //     NumOfCards = cards.Length;
        //     //Cards = new List<Card>(cards);
        //     Players = players;
        // }
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
            Deck.SortByAttribute(CardArrayEx.SortCardsBySpeed);
            Deck.Shuffle();
            //deal
            Deal();
            Player First = Players[0];
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int turn = 1;
            int winner = 0;
            do
            {
                File.WriteAllText($"Round_{turn}.html", ToHtml(Players, turn));
                CallBase call = Calls[rnd.Next(Calls.Length)];
                Console.WriteLine($"Forduló: {turn}. Hívás típusa: {call}");

                //select card
                Card[] cards = new Card[Players.Count];
                for (int i = 0; i < Players.Count; i++)
                {
                    cards[i] = call.BestCard(Players[i].Cards);
                }
                for (int i = 0; i < Players.Count; i++)
                {
                    Console.WriteLine($"Player {Players[i]}: {cards[i]}");
                    Players[i].Cards.Remove(cards[i]);
                }

                //select winner
                winner = call.WinnerIndex(cards);
                Console.WriteLine($"Winner {Players[winner]}");
                Players[winner].Cards.AddRange(cards);

                First = Players[winner];
                for (int i = Players.Count - 1; i >= 0; i--)
                {
                    if (Players[i].Cards.Count == 0)
                    {
                        Console.WriteLine($"dropped out: {Players[i]}");
                        Players.Remove(Players[i]);
                    }
                }
                turn++;
                //check gameover
            } while (Players.Count > 1);
            Console.WriteLine("A nyertes: ");
            Console.Write(Players[0].Name);
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
        // public void Shuffle()
        // {
        //     Card[] Original = new Card[](Deck);
        //     Cards.Clear();
        //     Random rand = new Random((int)DateTime.Now.Ticks);
        //     for (int i = 0; i < NumOfCards; i++)
        //     {
        //         int iR = rand.Next(Original.Count);
        //         Cards.Add(Original[iR]);
        //         Original.RemoveAt(iR);

        //     }
        // }

        private string ToHtml(List<Player> players, int Round)
        {
            return $@"<!DOCTYPE html>
            <html>
             	<head>
             		<meta charset=""utf-8"">
                    <title>Round {Round}</title>
                </head>
                <body>
                    <table rules=""all"" frame=""border"">
                        {players.ToHtml()}
                    </table>
                </body>
            </html> ";
        }
    }

}