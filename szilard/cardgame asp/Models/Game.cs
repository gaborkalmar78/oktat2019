namespace cardgame_asp.T
{
    public class Game
    {
        public int playerscount { get; set; }
        public string[] playername { get; set; }


        public Game(int count)
        {
            playername = new string[count];
            playerscount = count;
        }

        public Game()
        {

        }


    }
}