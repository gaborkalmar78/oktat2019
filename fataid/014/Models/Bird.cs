using System.Collections.Generic;

namespace _014.Models
{
    public class Bird : Animal, IHasLegs
    {
        public Bird(int lifespan, int ceiling) : base(lifespan)
        {
            Ceiling = ceiling;
        }
        public int Ceiling
        {
            get;
            set;
        }
        public int LegNumber { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Walk(int distance)
        {
            Age();
        }
        public void Fly(int distance)
        {
            for (int i = 0; i < 2; i++)
            {
                Age();
            }
        }
    }
}