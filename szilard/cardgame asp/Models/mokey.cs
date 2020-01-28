namespace cardgame_asp.T
{
    public class Monkey : Mamall, IHasLegs
    {
        public Monkey(int lifeSpam, int volume) : base(lifeSpam)
        {
            this.volume = volume;
        }

        public int Legscount { get; set; }

        public void Walk(int destini)
        {
            Age();
        }
        public int volume { get; set; }

        public void jump()
        {
            Age();
            Age();
            Age();
        }
    }
}