using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _019.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;

namespace _019.Controllers
{
    public class HomeController : Controller
    {
        private string SessionID;

        public HomeController(Dictionary<string, Player> SessionPlayers, Waitingroom Waitroom)
        {
            sessionPlayers = SessionPlayers;
            waitingroom = Waitroom;
        }
        private readonly Dictionary<string, Player> sessionPlayers;
        private readonly Waitingroom waitingroom;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            SessionID = HttpContext.Session.Id;
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("id", 0);
            ISession session = HttpContext.Session;

            return View("Index", session.Id);
        }

        public IActionResult PlayerNew(string playername, int playernumber)
        {
            ISession session = HttpContext.Session;
            if (string.IsNullOrWhiteSpace(playername) || playernumber < 2 || playernumber > 5)
            {
                return View("Index", session.Id);
            }
            session.SetString("playername", playername);
            session.SetInt32("playerscount", playernumber);
            Player plyr = new Player(playername);
            sessionPlayers[SessionID] = plyr;
            Player[] players = waitingroom.AddPlayer(plyr, playernumber);
            if (players != null)
            {
                //jatek inditasa
                int size = 72;
                Game game = new Game(Card.Generate(size), players);
                for (int i = 0; i < players.Length; i++)
                {
                    players[i].MyGame = game;
                    players[i].OriginalID = i;
                }
                game.Deal(3);
                return RedirectToAction(nameof(Play));
            }
            else
            {
                return RedirectToAction("Wait");
            }
        }

        public IActionResult Wait()
        {
            if (!sessionPlayers.ContainsKey(SessionID))
            {
                RedirectToAction(nameof(Index));
            }
            Player player = sessionPlayers[SessionID];
            if (player.MyGame != null)
            {
                return RedirectToAction(nameof(Play));
            }
            return View("Waiting");
        }
        public IActionResult Play()
        {
            if (!sessionPlayers.ContainsKey(SessionID))
            {
                RedirectToAction(nameof(Index));
            }
            Player player = sessionPlayers[SessionID];
            Game game = player.MyGame;
            if (player.LookAtTable)
            {
                return RedirectToAction("ShowTable");
            }
            return View(new PlayModel(game, player));
        }

        public IActionResult Call(int Card, string Prop)
        {
            if (!sessionPlayers.ContainsKey(SessionID))
            {
                RedirectToAction(nameof(Index));
            }
            Player player = sessionPlayers[SessionID];
            Game game = player.MyGame;
            if (player != game.ActPlayer)
            {
                return RedirectToAction(nameof(Play));
            }
            game.CallProp = Prop;
            Card SelCard = game.ActPlayer.Deck[Card];
            game.SelectedCards.Add(SelCard);
            game.ActPlayer.Deck.Remove(SelCard);
            do
            {
                game.Next();
            } while (!game.Players[game.ActPlayerID].Active);

            if (game.ActPlayerID == game.CalleeID)
            {
                game.CalleeID = game.GetWinner();
                game.ActPlayerID = game.CalleeID;
                game.Reward(game.CalleeID);
                game.UpdateRanks();
                if (game.IsFinished())
                {
                    //game.Cheat();
                    game.SortPlayers();
                }
                return RedirectToAction("ShowTable");
            }
            return RedirectToAction(nameof(Play));
        }

        public IActionResult ShowTable()
        {
            if (!sessionPlayers.ContainsKey(SessionID))
            {
                RedirectToAction(nameof(Index));
            }
            Player player = sessionPlayers[SessionID];
            if (!player.CheckedTable)
            {
                player.CheckedTable = true;
                return View("ShowTable", new PlayModel(player.MyGame, player));
            }
            player.CheckedTable = false;
            player.LookAtTable = false;
            if (player.MyGame.IsFinished())
            {
                return View("End", player.MyGame);
            }
            return RedirectToAction(nameof(Play));
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //...do something additional
        }
    }
}
