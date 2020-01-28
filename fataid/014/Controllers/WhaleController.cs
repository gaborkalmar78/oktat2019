using System.Collections.Generic;
using _014.Models;
using Microsoft.AspNetCore.Mvc;

namespace _014.Controllers
{
    public class WhaleController : AnimalControllerBase<Whale>
    {
        public override Whale CreateItem()
        {
            return new Whale(50, 100);
        }
    }
}