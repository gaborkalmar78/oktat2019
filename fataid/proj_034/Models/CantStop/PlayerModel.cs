using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _019.Models.CantStop
{
    public class PlayerModel
    {
        public PlayerModel()
        {
            Coloumns = new int[11];
            Temp = new int[11];
            for (int i = 0; i < Coloumns.Length; i++)
            {
                Coloumns[i] = -1;
                Temp[i] = 0;
            }
        }

        public int[] Coloumns { get; private set; }
        public int[] Temp { get; private set; }

        public bool CanStep(int col)
        {
            if (Temp[col] > 0)
            {
                return true;
            }
            int counter = 0;
            for (int i = 0; i < Temp.Length; i++)
            {
                if (Temp[i] > 0)
                {
                    counter++;
                }
            }
            return counter < 3;
        }
        public void Save()
        {
            for (int i = 0; i < Temp.Length; i++)
            {
                Coloumns[i] += Temp[i];
                Temp[i] = 0;
            }
        }
        public void Cancel()
        {
            for (int i = 0; i < Temp.Length; i++)
            {
                Temp[i] = 0;
            }
        }
        public void Step(int col)
        {
            Temp[col] += 1;
        }
    }
}
