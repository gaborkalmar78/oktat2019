using cardgame_mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace cardgame_mvc.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Start(string[] names)
        {
            Game.Instance = new Game(Card.Generate(25), names);
            Game.Instance.Deal(5);

            return View("Game", Game.Instance);
        }

        public IActionResult Call(int card, string prop)
        {
            Game game = Game.Instance;
            game.Prop = prop;
            game.Cards[game.ActualPlayer] = card;
            game.Next();
            if (game.ActualPlayer == game.Callee)
            {
                int best = game.GetWinner();
                Card[] cards = new Card[game.Players.Length];
                for (int i = 0; i < game.Players.Length; i++)
                {
                    cards[i] = game.Players[i].Deck[game.Cards[i]];
                    game.Players[i].Deck.RemoveAt(game.Cards[i]);

                }
                game.Players[best].Deck.AddRange(cards);

                game.Callee = best;
                game.ActualPlayer = best;

            }


            return View("Game", game);
        }
    }
}