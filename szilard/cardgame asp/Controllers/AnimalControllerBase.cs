using System.Collections.Generic;
using cardgame_asp.T;
using Microsoft.AspNetCore.Mvc;

namespace cardgame_asp.Controllers
{
    public abstract class AnimalControllerBase<T> : Controller
    {
        public IActionResult Index(T[] items)
        {
            return base.View(new List<T>(items));
        }

        public IActionResult Create(T[] items)
        {
            List<T> list = new List<T>(items);
            list.Add(CreateItem());
            return View("Index", list);
        }

        public abstract T CreateItem();


    }
}