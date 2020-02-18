using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using login_nvc.Models;

namespace login_nvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login(string user, string pass)
        {

            if (!string.IsNullOrWhiteSpace(user) && pass == user)
            {
                return RedirectToAction("Index", "Query");
            }
            else
                return View("Index", user);
        }



    }


}
