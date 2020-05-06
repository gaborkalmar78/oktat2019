using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project_021.Models;

namespace project_021.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            GenericList<Post> posts = new GenericList<Post>();
            posts.Add(new Post("Henry", "0"));
            posts.Add(new Post("David", "1"));
            posts.Add(new Post("Tom", "2"));
            Post[] query=posts.Where(A);
        }
        public IActionResult Index()
        {
            return View();
        }
        public bool A(Post post)
        {
            return post.Content.Length>100;
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
