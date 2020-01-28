namespace _014.Models
{
    public abstract class Animal
    {
        private int LifeSpan;
        public Animal(int lifespan)
        {
            LifeSpan = lifespan;
        }
        // public int LifeSpan
        // {
        //     get;
        //     set;
        // }
        public bool IsAlive
        {
            get { return LifeSpan > 0; }
            //return LifeSpan > 0;
        }
        public void Age()
        {
            LifeSpan -= 1;
        }
    }
}