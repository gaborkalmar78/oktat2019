using _017.Models;
using Microsoft.AspNetCore.Mvc;

namespace _017.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult Index(int min, int max, bool inv)
        {
            if (min > 0 && min < max && max <= 100)
            {
                //return RedirectToAction("Index", "Data");
                return RedirectToAction("Index", "Data", new { min = min, max = max, inv = inv });
            }
            return View(new QueryModel(min, max, inv));
        }
    }
}