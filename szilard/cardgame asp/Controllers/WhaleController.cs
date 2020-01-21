using System.Collections.Generic;
using cardgame_asp.T;
using Microsoft.AspNetCore.Mvc;

namespace cardgame_asp.Controllers
{
    public class WhaleController : AnimalControllerBase<Whale>
    {
        public override Whale CreateItem()
        {
            return new Whale(1, 1);
        }
    }
}