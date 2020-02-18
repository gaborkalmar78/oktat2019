using System;

namespace _019.Models
{
    public class Game
    {
        public static Game Instance { get; set; }
        public static string[] temp { get; set; }
        private int index = 0;
        public Game(Card[] deck, string[] names)
        {
            Deck = deck;
            Players = new Player[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                Players[i] = new Player(names[i]);
            }
            index = deck.Length;
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
        public Player[] Players { get; set; }
        public Card[] Deck { get; set; }
    }
}