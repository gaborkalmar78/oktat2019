namespace _014.Models
{
    public class Monkey : Mammal, IHasLegs
    {
        public Monkey(int lifespan, int maxvolume) : base(lifespan)
        {
            Volume = maxvolume;
        }

        public int Volume
        {
            get;
            set;
        }
        public int LegNumber { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Walk(int distance)
        {
            Age();
        }
        public void Jump(int distance)
        {
            for (int i = 0; i < 3; i++)
            {
                Age();
            }
        }
    }
}