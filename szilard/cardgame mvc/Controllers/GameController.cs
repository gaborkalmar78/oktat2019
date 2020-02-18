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
    }
}