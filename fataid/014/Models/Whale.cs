namespace _014.Models
{
    public class Whale : Mammal
    {

        public Whale(int lifespan, int maxdepth) : base(lifespan)
        {
            DiveDepth = maxdepth;
        }

        public int DiveDepth
        {
            get;
            set;
        }
        public void Walk(int distance)
        {
            Age();
        }
        public void Dive(int depth)
        {
            Age();
        }
    }
}