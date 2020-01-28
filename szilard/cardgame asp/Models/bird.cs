namespace cardgame_asp.T
{
    public class Bird : Animal, IHasLegs
    {
        public Bird(int lifeSpam, int ceiling) : base(lifeSpam)
        {
            Flightalitude = ceiling;
        }

        public int Legscount { get; set; }

        public void Walk(int destini)
        {
            Age();
        }

        public void Fly()
        {
            Age();
            Age();
        }

        public int Flightalitude { get; set; }



    }
}