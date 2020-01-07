using Microsoft.AspNetCore.Mvc;

namespace OnlineCardGame.Controllers
{
    public class CardGameController : Controller
    {
        public IActionResult New(int players = 2)
        {
            return View(players);
        }
    }
}