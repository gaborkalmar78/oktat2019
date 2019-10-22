namespace obiektum.Classes
{
    public class Animal
    {
        private int age = 0;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public void Live()
        {
            age += 1;
        }
    }

}