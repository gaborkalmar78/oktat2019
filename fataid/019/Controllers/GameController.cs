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
            //Game.Instance = new Game(Card.Generate(size), Game.temp);
            Game.Instance.Deal(5);
            return View("Game", Game.Instance);
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
