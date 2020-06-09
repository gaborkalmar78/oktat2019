using System;
using System.Collections.Generic;

namespace _019.Models
{
    public class PlayModel
    {
        public PlayModel(Game game, Player player)
        {
            Game = game;
            Player = player;
        }

        public Game Game { get; set; }
        public Player Player { get; set; }
    }

}