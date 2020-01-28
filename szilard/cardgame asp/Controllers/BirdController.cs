using System.Collections.Generic;
using cardgame_asp.T;
using Microsoft.AspNetCore.Mvc;

namespace cardgame_asp.Controllers
{
    public class BirdController : AnimalControllerBase<Bird>
    {
        public override Bird CreateItem()
        {
            return new Bird(1, 1);
        }
    }
}