namespace _006.Classes
{
    public class Bird : WarmBlooded
    {
        private double maxflightheight = 0.0;
        private double currentflightheight = 0.0;
        public double MaxFlightHeight
        {
            get { return maxflightheight; }
            set { maxflightheight = value; }
        }
        public double CurrentFlightHeight
        {
            get { return currentflightheight; }
            //set { currentflightheight = value; }
        }
        public void SetFlyHeight(double height)
        {
            if (height > maxflightheight)
            {
                currentflightheight = maxflightheight;
            }
            else
            {
                currentflightheight = height;
            }
        }
    }
}