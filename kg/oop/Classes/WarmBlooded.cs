namespace oop.Classes
{
    public class WarmBlooded : Animal
    {
        private double temp = 0.0;
        public double Temp
        {
            get { return temp; }
            set { temp = value; }
        }
    }
}