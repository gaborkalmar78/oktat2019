namespace cardgame_mvc.Models
{
    public class Game
    {
        public Player[] Players { get; set; }
        public Card[] Deck { get; set; }

        private int index = 0;

        public static Game Instance { get; set; }


        public Game(Card[] deck, string[] names)
        {
            Deck = deck;
            Players = new Player[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                Players[i] = new Player(names[i]);
            }
            index = Deck.Length;
        }

        public void Deal(int count)
        {


            for (int j = 0; j < count; j++)
            {
                for (int i = 0; i < Players.Length; i++)
                {
                    index--;
                    Players[i].Deck.Add(Deck[index]);
                }
            }








        }


    }
}