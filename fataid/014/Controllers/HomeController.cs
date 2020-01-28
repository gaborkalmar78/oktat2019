using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _014.Models;

namespace _014.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int players = 2)
        {
            //ControllerBase cb = new ControllerBase();
            //return View(Math.Clamp(players, 2, 5));
            // int count = Math.Clamp(players, 2, 5);
            // Game game = new Game();
            // game.Count = players;
            // game.Names = new string[count];
            Game game = new Game(Math.Clamp(players, 2, 5));
            return View(game);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult Game(string[] names)
        public IActionResult Game(string[] names)
        {
            int count = names.Length;
            Game game = new Game(count);
            for (int j = 0; j < count; j++)
            {
                game.Names[j] = names[j];
            }
            return Game(game);
        }
        public IActionResult Game(Game game)
        {
            if (game.Names == null)
            {
                //return View("Index", 2);
                return RedirectToAction("Index");
            }
            if (game.Names.Length < 2 || game.Names.Length > 5)
            {
                //return View("Index", 2);
                int count = Math.Clamp(game.Names.Length, 2, 5);
                //Game game = new Game(count);
                //game.Names = new string[count];
                // for (int j = 0; j < count; j++)
                // {
                //     game.Names[j] = names[j];
                // }
                //return View("Index", game);
                return RedirectToAction("Index", new Game(count));
            }
            for (int i = 0; i < game.Names.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(game.Names[i]))
                {
                    //Game game = new Game(names.Length);
                    // for (int j = 0; j < names.Length; j++)
                    // {
                    //     game.Names[j] = names[j];
                    // }
                    //return View("Index", game);
                    return RedirectToAction("Index", game);
                    // return View("Index", 2);
                }
            }
            return View(game);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
