using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cardgame_mvc.Models;

namespace cardgame_mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int Players)
        {
            if (Players >= 2 && Players <= 5)
            {
                return View("playersname", new string[Players]);
            }

            return View();
        }


        public IActionResult playersname(string[] playersname)
        {
            bool stringtest = true;
            for (int i = 0; i < playersname.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(playersname[i]))
                {
                    stringtest = false;
                }
            }
            if (stringtest == true)
            {
                RedirectToAction("Index,Game,");
            }
            return View(playersname);


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
