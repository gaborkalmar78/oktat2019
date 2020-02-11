﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _019.Models;

namespace _019.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        static int playernumber = 0;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Players(int playernumber)
        {

            HomeController.playernumber = playernumber;
            string[] names = new string[playernumber];
            return View("Players", names);
            //return Players(playernumber);
        }

        public IActionResult Game(string[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(players[i]))
                {
                    return View("Players", players);
                    //return RedirectToAction("Players", "Home", players);
                }
            }
            return View("Gamestart", players);
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
