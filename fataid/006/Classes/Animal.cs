namespace _006.Classes
{
    public class Animal
    {
        private int age = 0;
        private int mass = 0;
        private string eating;
        private string reproduction;
        private string sex;
        public int Age
        {
            get { return age; }
            // set { age = value; }
        }
        public void Live()
        {
            age += 1;
        }
    }
}