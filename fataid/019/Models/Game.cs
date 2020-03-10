using System;

namespace _019.Models
{
    public class Game
    {
        public static Game Instance { get; set; }
        public static string[] temp { get; set; }
        private int index = 0;
        public int ActPlayer { get; set; }
        public int Callee { get; set; }
        public string CallProp { get; set; }
        public int[] CallCards { get; set; }
        public string[] Result { get; set; }
        public int Step { get; set; }
        public Player[] Players { get; set; }
        public Card[] Deck { get; set; }
        public Game(Card[] deck, string[] names)
        {
            Deck = deck;
            Players = new Player[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                Players[i] = new Player(names[i]);
            }
            index = deck.Length;
            ActPlayer = 0;
            Callee = 0;
            CallProp = null;
            CallCards = new int[names.Length];
            Result = new string[names.Length];
            Step = (names.Length) - 1;
            //Game.Instance = this;
        }
        public void Deal(int size)
        {
            for (; size > 0; size--)
            {
                for (int i = 0; i < Players.Length; i++)
                {
                    index--;
                    if (index < 0)
                    {
                        return;
                    }
                    Players[i].Deck.Add(Deck[index]);
                }
            }
        }
        public void Next()
        {
            ActPlayer = (ActPlayer + 1) % Players.Length;
        }
        public int GetWinner()
        {
            int best = 0;
            while (!Players[best].Active)
            {
                best++;
            }
            for (int i = (best + 1); i < Players.Length; i++)
            {
                if (Players[i].Active && Players[best].Deck[CallCards[best]].Strength(CallProp) < Players[i].Deck[CallCards[i]].Strength(CallProp))
                {
                    best = i;
                }
            }
            return best;
        }
        public void Reward(int winner)
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Active)
                {
                    Players[winner].Deck.Add(Players[i].Deck[CallCards[i]]);
                    Players[i].Deck.RemoveAt(CallCards[i]);
                }
                if (!Players[i].Ranked && !Players[i].Active)
                {
                    Players[i].Ranked = true;
                    Result[Step] = Players[i].Name;
                    Step--;
                }
            }
        }
        public bool IsFinished()
        {
            int counter = 0;
            for (int i = 0; i < Players.Length; i++)
            {
                if (Players[i].Active)
                {
                    counter++;
                }
                else
                {
                    Players[i].Rank++;
                }
            }
            return counter < 2;
        }
        public void UpdateRanks()
        {
            for (int i = 0; i < Players.Length; i++)
            {
                if (!Players[i].Active)
                {
                    Players[i].Rank++;
                }
            }
        }
    }
}
