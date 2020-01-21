using System.Collections.Generic;
using cardgame_asp.T;
using Microsoft.AspNetCore.Mvc;

namespace cardgame_asp.Controllers
{
    public class MonkeyControllers : AnimalControllerBase<Monkey>
    {
        public override Monkey CreateItem()
        {
            return new Monkey(1, 1);
        }
    }
}