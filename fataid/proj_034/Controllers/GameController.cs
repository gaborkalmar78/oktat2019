// using System;
// using System.Collections.Generic;
// using System.Diagnostics;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using _019.Models;

// namespace _019.Controllers
// {
//     public class GameController : Controller
//     {
//         public GameController()
//         {

//         }
//         public IActionResult Index()
//         {
//             return View();
//         }


//         public IActionResult Start(string[] players)
//         {
//             int size = 72;
//             Game.Instance = new Game(Card.Generate(size), players);
//             Game game = Game.Instance;
//             //Game.Instance = new Game(Card.Generate(size), Game.temp);
//             game.Deal(5);
//             return View("Game", game);
//         }

//         public IActionResult Call(int Card, string Prop)
//         {
//             Game game = Game.Instance;
//             game.CallProp = Prop;
//             game.CallCards[game.ActPlayerID] = Card;
//             do
//             {
//                 game.Next();
//             } while (!game.Players[game.ActPlayerID].Active);

//             if (game.ActPlayerID == game.CalleeID)
//             {
//                 game.CalleeID = game.GetWinner();
//                 game.ActPlayerID = game.CalleeID;
//                 game.Reward(game.CalleeID);
//                 game.UpdateRanks();
//                 if (game.IsFinished())
//                 {
//                     //game.Cheat();
//                     game.SortPlayers();
//                     return View("End", game);
//                 }
//             }
//             return View("Game", game);
//         }

//         [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//         public IActionResult Error()
//         {
//             return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//         }

//         protected override void Dispose(bool disposing)
//         {
//             base.Dispose(disposing);
//             //...do something additional
//         }
//     }
// }
