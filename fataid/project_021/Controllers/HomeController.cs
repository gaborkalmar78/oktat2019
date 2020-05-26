using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project_021.DataBase;
using project_021.Models;

namespace project_021.Controllers
{
    public class HomeController : Controller
    {
        private Category[] categories;
        public HomeController(BlogContext context)
        {
            Context = context;
            Random rnd = new Random();
            //GenericList<Post> posts = new GenericList<Post>();
            //posts.Add(new Post("Henry", "0"));
            //posts.Add(new Post("David", "1"));
            //posts.Add(new Post("Tom", "2"));
            //Post[] query=posts.Where(A);
            Topic top1 = Topic.Factory(1, rnd)[0];
            context.Topics.Add(top1);
            context.SaveChanges();
            categories = Category.Factory(100, rnd);
            IEnumerable<Category> filtered1 = categories.Where(B);
            IEnumerable<Category> filtered2 = categories.Where((c) => { return false; });
            IEnumerable<Category> filtered5 = categories.Where(c=> false);
            //Category[] filtered3
            Dictionary<Guid, Category> dict = categories
                .Where(c => c.Title.Contains("2") && c.Title.Contains("B"))
                .OrderByDescending(c => c.Topics.Count)
                .ThenBy(c => c.Title)
                .ToDictionary(c => c.ID);
            Dictionary<Guid, string> dict2 = categories
                .ToDictionary(c => c.ID, c => c.Title);
            int count = categories.Sum(c => c.Topics.Count);
            double aver = categories.Average(c => c.Topics.Count);
            var names3_7 = categories
                .OrderByDescending(c => c.Topics.Count)
                //.Where((c,i) => { return false; });
                .Where((c, i) => i>=3&&i<=7)
                .Select(c => c.Title);
            List<string> names3_7_B = categories
                .OrderByDescending(c => c.Topics.Count)
                .Skip(3)
                .Take(4)
                .Select(c => c.Title)
                .ToList();
        }
        BlogContext Context;
        private bool B(Category cat)
        {
            return cat.Title.Contains("2");
        }

        public IActionResult Index()
        {
            return View(Context.Topics.Count());
        }
        public bool A(Post post)
        {
            return post.Content.Length>100;
        }
        public bool StartsWithA(Post post)
        {
            return post.Content.Length > 100;
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
