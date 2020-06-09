using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using User.DAL;
using User.Models;

namespace User.Controllers
{
    public class AuthController : Controller
    {
        private Context context;
        private UserManager usermgr;

        public AuthController(Context context, UserManager usermgr)
        {
            this.context = context;
            this.usermgr = usermgr;
        }

        public IActionResult Login()
        {
            return View(new Models.User());
        }
        [HttpPost]
        public IActionResult Login(Models.User user)
        {
            if(context.Users.Any(x => user.Name==x.Name && user.Password==x.Password ))
            {
                usermgr.Login(HttpContext.Session.Id, user);
                return RedirectToAction("Index", "Home");
            }
            user.Password = "";
            return View(user);
        }
        public IActionResult Logout()
        {
            usermgr.Logout(HttpContext.Session.Id);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View(new RegisterModel());
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if(!(string.IsNullOrWhiteSpace(model.Name)
                ||string.IsNullOrWhiteSpace(model.Password1)
                || model.Password1!=model.Password2))
            {
                context.Users.Add(new Models.User(model.Name, model.Password1));
                context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(model);
        }
    }
}
