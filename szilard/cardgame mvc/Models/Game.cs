namespace cardgame_mvc.Models
{
    public class Game
    {
        public Player[] Players { get; set; }
        public Card[] Deck { get; set; }


        public Game(Card[] deck, string[] names)
        {
            Deck = deck;
            Players = new Player[names.Length];

            for (int i = 0; i < names.Length; i++)
            {
                Players[i] = new Player(names[i]);
            }

        }
    }
}