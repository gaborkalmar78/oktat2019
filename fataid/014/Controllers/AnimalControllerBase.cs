
using Microsoft.AspNetCore.Mvc;
using _014.Models;
using System.Collections.Generic;

namespace _014.Controllers
{
    public abstract class AnimalControllerBase<t> : Controller
    {
        public IActionResult Index(t[] items)
        {

            return View(new List<t>(items));
        }
        public IActionResult Create(t[] items)
        {
            List<t> list = new List<t>(items);
            list.Add(CreateItem());
            return View("Index", list);
        }
        public abstract t CreateItem();
    }
}
