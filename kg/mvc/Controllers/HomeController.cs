using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc.Models;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            this.HttpContext.Session.Set("a", BitConverter.GetBytes(0));
        }
        public IActionResult Index()
        {
            var x = this.HttpContext.Session.TryGetValue("a", out byte[] bs);
            int i = BitConverter.ToInt16(bs);
            return View();
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
