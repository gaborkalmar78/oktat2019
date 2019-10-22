namespace oop.Classes
{
    public class Bird : WarmBlooded
    {
        private double maxHight = 0.0;
        public double MaxhtHeight
        {
            get { return maxHight; }
            set { maxHight = value; }
        }

        private double currentHeight = 0.0;
        public double CurrentHeigh
        {
            get { return currentHeight; }
        }

        public void SetHeight(double height)
        {
            if (height > maxHight)
            {
                currentHeight = maxHight;
            }
            else
            {
                currentHeight = height;
            }
        }
    }
}