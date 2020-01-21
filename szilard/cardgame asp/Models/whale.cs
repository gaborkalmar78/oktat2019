namespace cardgame_asp.T
{
    public class Whale : Mamall, IHasLegs
    {
        public Whale(int lifeSpam, int Divedepth) : base(lifeSpam)
        {
            this.Divedepth = Divedepth;
        }

        public int Divedepth { get; set; }

        public int Legscount { get; set; }

        public void Walk(int destini)
        {
            Age();
        }

        public void dive()
        {
            Age();
        }
    }
}