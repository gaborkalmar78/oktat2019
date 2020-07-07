using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Webshop2020.Data;
using Webshop2020.Models;

namespace Webshop2020.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebshopDbContext context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(WebshopDbContext context, ILogger<HomeController> logger)
        {
            this.context = context;
            _logger = logger;
            /*
            //Product prod = context.Products.Include(x => x.Categories).AsNoTracking().FirstOrDefault(x => x.Name == "Tej");
            Product prod = context.Products.FirstOrDefault(x => x.Name == "Tej");
            //Category cat = context.Categories.FirstOrDefault(x => x.Name == "Tejtermékek");
            Category cat = context.Categories.FirstOrDefault(x => x.Name == "Tejtermékek");
            CategoryProduct tmp = new CategoryProduct(cat, prod);
            prod.Categories.Add(tmp);
            //context.Products.Add(prod);
            int result = context.SaveChanges();
            */
        }

        //public IActionResult Index(Guid? ID, Nullable<Guid> ID2)
        public IActionResult Index(Guid? ID)
        {
            //Category[] cats = context.Categories.Include(x => x.Parent).AsNoTracking().ToArray();
            Category[] cats = context.Categories.Include(x => x.Children).Include(x => x.Parent).AsNoTracking().ToArray();
            Product[] products = null;
            if(ID!=null)
            {
                products = context.Products.Where(x => x.Categories.Any(y => y.CategoryID == ID)).OrderBy(x => x.Name).ToArray();
                //bool okay = products[0].Categories.Any(y => y.CategoryID==ID);
            }
            return View(new IndexViewModel(cats, products));
        }
        public IActionResult Product(Guid? ID)
        {
            Category[] cats = context.Categories.Include(x => x.Children).Include(x => x.Parent).AsNoTracking().ToArray();
            Product product = null;
            if (ID != null)
            {
                product = context.Products.FirstOrDefault(x => x.ID == ID);
            }
            return View(new ProductViewModel(cats, product));
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
