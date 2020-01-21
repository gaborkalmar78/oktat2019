
using Microsoft.AspNetCore.Mvc;
using _014.Models;
using System.Collections.Generic;

namespace _014.Controllers
{
    public class BirdController : AnimalControllerBase<Bird>
    {
        public override Bird CreateItem()
        {
            return new Bird(50, 100);
        }
    }
}
