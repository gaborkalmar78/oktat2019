using login_nvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace login_nvc.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult Index()
        {
            return View(new QueryModel(21, 1));
        }

        public IActionResult query(int min, int max)
        {
            if (min > 0 && max < 100 && min < max)
                return RedirectToAction("Index", "Data", new QueryModel(max, min));
            else
                return View("Index", new QueryModel(max, min));
        }




    }
}