namespace oop.Classes
{
    public class Animal
    {
        private int age = 0;
        public int Age
        {
            get { return age; }
        }

        public void Live()
        {
            age += 1;
        }
    }
}