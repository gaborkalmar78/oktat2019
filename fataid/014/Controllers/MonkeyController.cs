using System.Collections.Generic;
using _014.Models;
using Microsoft.AspNetCore.Mvc;

namespace _014.Controllers
{
    public class MonkeyController : AnimalControllerBase<Monkey>
    {
        public override Monkey CreateItem()
        {
            return new Monkey(50, 100);
        }
    }
}