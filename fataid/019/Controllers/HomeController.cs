using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _019.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace _019.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        static int playernumber = 0;

        private static Dictionary<int, List<User>> waitingroom = new Dictionary<int, List<User>>();
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("id", 0);
            ISession session = HttpContext.Session;

            return View("Index", session.Id);
        }

        public IActionResult Players(int playernumber)
        {
            ISession session = HttpContext.Session;
            HomeController.playernumber = playernumber;
            string[] names = new string[playernumber];
            return View("Players", names);
            //return Players(playernumber);
        }

        public IActionResult PlayerNew(string playername, int playernumber)
        {
            ISession session = HttpContext.Session;
            if (string.IsNullOrWhiteSpace(playername) || playernumber < 2 || playernumber > 5)
            {
                return View("Index", session.Id);
            }
            session.SetString("playername", playername);
            session.SetInt32("playerscount", playernumber);
            User plyr = new User(playername, session.Id);
            if (!waitingroom.ContainsKey(playernumber))
            {
                waitingroom.Add(playernumber, new List<User>());
            }
            List<User> temp = waitingroom[playernumber];
            if (temp.Count == (playernumber - 1))
            {
                //jatek inditasa
                //return RedirectToAction("StartGameNew");
            }
            else
            {
                temp.Add(plyr);
                return RedirectToAction("Wait");
            }
            //kitorolni kesobb
            return RedirectToAction("Wait");
        }

        public IActionResult Wait()
        {
            // ISession session = HttpContext.Session;
            // int count = session.GetInt32("playerscount").Value;
            // string name = session.GetString("playername");
            // if (!waitingroom.ContainsKey(count))
            // {
            //     waitingroom.Add(count, new List<User>());
            // }
            // List<User> temp = waitingroom[count];
            // for (int i = 0; i < temp.Count; i++)
            // {
            //     //...
            // }
            return View("Waiting");
        }
        public IActionResult StartGameNew(int pnumber)
        {
            string[] names = new string[pnumber];
            List<User> temp = waitingroom[pnumber];
            for (int i = 0; i < temp.Count; i++)
            {
                names[i] = temp[i].Name;
            }
            RouteValueDictionary rwd = new RouteValueDictionary();
            rwd.Add("players", names);
            return RedirectToAction("Start", "Game", rwd);
        }

        public IActionResult StartGame(string[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(players[i]))
                {
                    return View("Players", players);
                }
            }
            RouteValueDictionary rwd = new RouteValueDictionary();
            rwd.Add("players", players);
            //return View("Gamestart", players);
            //Game.temp = players;
            //rwd.Add
            //return RedirectToAction("Start", "Game", players.ToList());
            return RedirectToAction("Start", "Game", rwd);
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //...do something additional
        }
    }
}
