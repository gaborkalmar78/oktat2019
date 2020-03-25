using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _019.Models;

namespace _019.Controllers
{
    public class GameController : Controller
    {
        public GameController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Start(string[] players)
        {
            int size = 72;
            Game.Instance = new Game(Card.Generate(size), players);
            Game game = Game.Instance;
            //Game.Instance = new Game(Card.Generate(size), Game.temp);
            game.Deal(5);
            return View("Game", game);
        }

        public IActionResult Call(int Card, string Prop)
        {
            Game game = Game.Instance;
            game.CallProp = Prop;
            game.CallCards[game.ActPlayer] = Card;
            do
            {
                game.Next();
            } while (!game.Players[game.ActPlayer].Active);

            if (game.ActPlayer == game.Callee)
            {
                game.Callee = game.GetWinner();
                game.ActPlayer = game.Callee;
                game.Reward(game.Callee);
                game.UpdateRanks();
                if (game.IsFinished())
                {
                    game.Cheat();
                    game.SortPlayers();
                    return View("End", game);
                }
            }
            return View("Game", game);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //...do something additional
        }
    }
}
