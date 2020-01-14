using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cardgame_asp.Models;

namespace cardgame_asp.Controllers
{
    public class HomeController : Controller
    {




        public IActionResult game(Game game)
        {
            if (game.playername == null)
            {
                return RedirectToAction("Index", game);
            }
            if (game.playerscount > 5 || game.playerscount < 2)
            {
                return RedirectToAction("Index", game);
            }

            for (int i = 0; i < game.playername.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(game.playername[i]))
                {
                    return RedirectToAction("index", game);
                }

            }




            return View(game);
        }


        public IActionResult Index(int players)
        {




            Game game = new Game(Math.Clamp(players, 2, 5));


            return View(game);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
