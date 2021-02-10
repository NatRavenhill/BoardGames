using BoardGames.Models;
using BoardGamesContextLib;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace BoardGames.Controllers
{
    /// <summary>
    /// Controller for the loans page
    /// </summary>
    public class LoansController : Controller
    {
        private IBoardGameContext db;
        private LoansViewModel viewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Database context</param>
        public LoansController(IBoardGameContext context)
        {
            db = context;
        }

        /// <summary>
        /// Database context
        /// </summary>
        public IBoardGameContext Database => db;

        /// <summary>
        /// Action to display the Index page for Loans
        /// </summary>
        /// <returns>The Loans view</returns>
        public IActionResult Index()
        {
            string currentUser = HttpContext?.User.Claims.First().Value;
            viewModel = new LoansViewModel(db, currentUser);
            return View(viewModel);
        }

        /// <summary>
        /// Returns the given game if it is currently on loan
        /// </summary>
        /// <param name="gameID">Id of the game to borrow</param>
        /// <param name="bbgID">Board Game Geek API ID of the game to borrow</param>
        /// <returns>A redirect to the details page </returns>
        public IActionResult Return(int gameID)
        {
            int saveResult = db.ReturnLoan(gameID);

            if (saveResult == 1)
                return Redirect("Index");
            else
                return StatusCode((int)HttpStatusCode.InternalServerError);
        }
    }
}
