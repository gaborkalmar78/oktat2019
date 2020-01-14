namespace _014.Models
{
    public class Game
    {
        public Game(int count)
        {
            Count = count;
            Names = new string[count];
        }
        public int Count
        {
            get;
            set;
        }

        public string[] Names
        {
            get;
            set;
        }
    }
}