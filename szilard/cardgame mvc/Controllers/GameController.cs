using System.Collections.Generic;
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
            do
            {
                game.Next();
            } while (game.Players[game.ActualPlayer].Deck.Count == 0);

            if (game.ActualPlayer == game.Callee)
            {
                int best = game.GetWinner();
                game.MoveCarsdToPLayer(best);

                game.UppDateRanks();

                game.Callee = best;
                game.ActualPlayer = best;

                if (game.EndOFGame())
                {
                    return View("Result", game);
                }


            }



            return View("Game", game);
        }


    }
}