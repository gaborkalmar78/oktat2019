using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _019.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _019.Controllers
{
    public class HomeController : Controller
    {
        private string SessionID;
        public HomeController()
        {

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            SessionID = HttpContext.Session.Id;
        }
        static int playernumber = 0;

        //private static Dictionary<int, List<User>> waitingroom = new Dictionary<int, List<User>>();
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("id", 0);
            ISession session = HttpContext.Session;

            return View("Index", session.Id);
        }

        public IActionResult Players(int playernumber)
        {
            ISession session = HttpContext.Session;
            HomeController.playernumber = playernumber;
            string[] names = new string[playernumber];
            return View("Players", names);
            //return Players(playernumber);
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
            Game.SessionPlayers[SessionID] = plyr;
            Player[] players = Waitingroom.AddPlayer(plyr, playernumber);
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
            Player player = Game.SessionPlayers[SessionID];
            if (player.MyGame != null)
            {
                return RedirectToAction(nameof(Play));
            }
            return View("Waiting");
        }
        public IActionResult Play()
        {
            Player player = Game.SessionPlayers[SessionID];
            Game game = player.MyGame;
            // if (game.IsFinished())
            // {
            //     return View("End", game);
            // }
            // else if (player.LookAtTable)
            if (player.LookAtTable)
            {
                return RedirectToAction("ShowTable");
            }
            return View(new PlayModel(game, player));
        }

        public IActionResult Call(int Card, string Prop)
        {
            Player player = Game.SessionPlayers[SessionID];
            Game game = player.MyGame;
            if (player != game.ActPlayer)
            {
                return RedirectToAction(nameof(Play));
            }
            game.CallProp = Prop;
            //game.CallCards[game.ActPlayerID] = Card;
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
                    //return View("End", game);
                }
                return RedirectToAction("ShowTable");
            }
            return RedirectToAction(nameof(Play));
            // return View(nameof(Play), new PlayModel(game, player));
            //return View("Game", game);
        }

        public IActionResult ShowTable()
        {
            Player player = Game.SessionPlayers[SessionID];
            if (!player.CheckedTable)
            {
                player.CheckedTable = true;
                return View("ShowTable", player.MyGame);
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
