using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _019.Models.CantStop
{
    public class GameModel
    {
        public GameModel(PlayerModel[] players)
        {
            Players = players;
        }
        private Random rnd = new Random();
        private RollModel roll = null;
        public PlayerModel[] Players { get; set; }

        public void Roll()
        {
            roll = new RollModel(rnd);
        }
        public RollModel GetRoll()
        {
            return roll;
        }
    }
}
