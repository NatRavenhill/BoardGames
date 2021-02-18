using BoardGames.Models;
using BoardGamesContextLib;
using BoardGamesContextLib.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BoardGames.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IBoardGameContext db;

        public HomeController(ILogger<HomeController> logger, IBoardGameContext injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel()
            {
                MostPopularGames = GetMostPopularGames()
            };
            return View(model);
        }

        private List<GameDetail> GetMostPopularGames()
        {
            Dictionary<GameDetail, int> gamesWithNoLoans = new Dictionary<GameDetail, int>();
            foreach(GameDetail game in db.GameDetail)
            {
                int loanTotal = db.Loan.Count(l => l.GameID == game.Id);
                gamesWithNoLoans.Add(game, loanTotal);
            }

            IOrderedEnumerable<KeyValuePair<GameDetail, int>> orderedGames = gamesWithNoLoans.OrderByDescending(p => p.Value);

            return orderedGames.Take(3).Select(p => p.Key).ToList();

        }

        #region Auto generated actions

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion Auto generated actions
    }
}
