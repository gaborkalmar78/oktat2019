using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using teszt_nvc.Models;

namespace teszt_nvc.Controllers
{
    public class HomeController : Controller

    {

        static int testnumber = 0;
        public HomeController()
        {

        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);







        }


        public IActionResult Index()
        {
            testnumber = testnumber + 1;
            return View(testnumber);
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
