using BoardGames.Models;
using BoardGames.Models.Extensions;
using BoardGamesContextLib;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BoardGames.Controllers
{
    public class BrowseLibraryController : Controller
    {
        private IBoardGameContext db;
        private BrowseLibraryViewModel model;

        public BrowseLibraryController(IBoardGameContext injectedContext)
        {
            db = injectedContext;
        }

        /// <summary>
        /// Loads the Browse Library page
        /// </summary>
        /// <returns>The browse library view with the model passed in to it</returns>
        public IActionResult BrowseLibrary(string searchText = "")
        {
            model = new BrowseLibraryViewModel()
            {
                GameDetails = db.GameDetail.ToList()
            };

            if(!string.IsNullOrEmpty(searchText))
                model.GameDetails = model.GameDetails.Where(g => g.Name.ContainsIgnoringCase(searchText)).ToList();
            
            return View(model);
        }
    }
}
