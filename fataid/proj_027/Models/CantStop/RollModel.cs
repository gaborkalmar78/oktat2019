using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _019.Models.CantStop
{
    public class RollModel
    {
        public RollModel()
        {
            Dices = new int[4];
        }
        public RollModel(Random rnd)
        : this()
        {
            for (int i = 0; i < Dices.Length; i++)
            {
                Dices[i] = rnd.Next(1,7);
            }
        }
        public int[] Dices { get; private set; }

        public int[,] GetPairs()
        {
            return new int[,]{
                { Dices[0]+Dices[1], Dices[2]+Dices[3] },
                { Dices[0]+Dices[2], Dices[1]+Dices[3] },
                { Dices[0]+Dices[3], Dices[1]+Dices[2] }
            };
        }
    }
}
