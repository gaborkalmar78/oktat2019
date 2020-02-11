using System;

namespace _019.Models
{
    public class Game
    {
        public Game(Card[] deck, string[] names)
        {
            Deck = deck;
            Players = new Player[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                Players[i].Name = names[i];
            }
        }
        public Player[] Players { get; set; }
        public Card[] Deck { get; set; }
    }
}