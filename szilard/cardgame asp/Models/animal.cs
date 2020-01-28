namespace cardgame_asp.T
{
    public abstract class Animal
    {
        private int lifeSpam;

        public Animal(int lifeSpam)
        {

        }

        public void Age()
        {
            lifeSpam = lifeSpam - 1;
        }
        public bool Isalive
        {
            get
            {
                return lifeSpam > 0;
            }
        }



    }
}