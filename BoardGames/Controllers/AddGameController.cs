using BoardGames.Models;
using BoardGames.Models.API;
using BoardGames.Models.Extensions;
using BoardGamesContextLib;
using BoardGamesContextLib.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BoardGames.Controllers
{
    /// <summary>
    /// Controller for the Add Game page
    /// </summary>
    public class AddGameController : Controller
    {
        private IBoardGameContext db;

        public AddGameController(IBoardGameContext injectedContext)
        {
            db = injectedContext;
            Model = new AddGameViewModel();
        }

        public AddGameViewModel Model { get; }

        /// <summary>
        /// Action for the AddGame page
        /// </summary>
        /// <returns>The Add Game view</returns>
        public IActionResult AddGame(string searchText = "")
        {
            if (string.IsNullOrEmpty(searchText))
                return View();

            Model.SearchText = searchText;

            Task<ItemList> task = GetData(searchText);
            task.Wait();

            Model.BoardGames = task.Result;
            return View(Model);
        }

        private async Task<ItemList> GetData(string searchText)
        {
            var boardGameAPI = BoardGameAPIHelper.Instance.BoardGameAPI;
            return await boardGameAPI.SearchBoardGamesAsync(searchText);
        }

        /// <summary>
        /// Adds the game to the database
        /// </summary>
        /// <param name="id">Id of game to retrieve</param>
        /// <returns>The game detail view</returns>
        [Authorize]
        public IActionResult AddToDatabase(int id)
        {
            Item foundGame = BoardGameAPIHelper.Instance.GetGameDetail(id).Result;
            if (foundGame == null)
                return NotFound();

            GameDetail gameDetail = foundGame.GetGameDetail();

            if (CheckNotAlreadyAdded(id))
            {
                var result = db.GameDetail.Add(gameDetail);
                if (result != null || db.GameDetail.Contains(gameDetail))
                {
                    int entriesWritten = db.SaveChanges();
                    if (entriesWritten > 0)
                    {
                        return RedirectToAction("GameDetail", "GameDetail", new { id, isAdded = true, alreadyInDatabase = false });
                    }
                }
            }
            else
            {
                return RedirectToAction("GameDetail", "GameDetail", new { id, isAdded = true, alreadyInDatabase = true });
            }

            return StatusCode((int)HttpStatusCode.InternalServerError);


        }

        private bool CheckNotAlreadyAdded(int id)
        {
            return !db.GameDetail.Any(g => g.BBGId == id);
        }
    }
}
