using BoardGamesContextLib;
using BoardGamesContextLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Controllers
{
    public class GameDetailController : Controller
    {
        private IBoardGameContext db;

        public GameDetailController(IBoardGameContext injectedContext)
        {
            db = injectedContext;
        }

        public IBoardGameContext Database => db;

        /// <summary>
        /// Add a loan for the given game to the currently logged in user
        /// </summary>
        /// <param name="gameID">Id of the game to borrow</param>
        /// <param name="bbgID">Board Game Geek API ID of the game to borrow</param>
        /// <returns></returns>
        public IActionResult Borrow(int gameID, int bbgID)
        {
            string loggedInUser = HttpContext?.User.Claims.First().Value;
            int maxId = db.Loan.Any() ? db.Loan.Max(l => l.LoanID) : 0;

            Loan loan = new Loan()
            {
                LoanID = maxId + 1,
                GameID = gameID,
                UserID = loggedInUser,
                BorrowedDate = DateTime.Now,
            };

            db.Loan.Add(loan);
            
            int result = db.SaveChanges();

            return Redirect($"../AddGame/GameDetail/{bbgID}");
        }
    }
}
