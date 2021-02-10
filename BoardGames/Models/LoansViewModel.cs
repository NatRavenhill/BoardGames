using BoardGamesContextLib;
using BoardGamesContextLib.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BoardGames.Models
{
    public class LoansViewModel
    {
        /// <summary>
        /// View model for the loans page
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="currentUser">Current user</param>
        public LoansViewModel(IBoardGameContext context, string currentUser)
        {
            MyLoans = context.Loan.Where(l => l.UserID.Equals(currentUser));
            GameDetails = context.GameDetail.ToList();
        }

        /// <summary>
        /// Current loans for this user
        /// </summary>
        public IEnumerable<Loan> CurrentLoans => MyLoans.Where(l => l.ReturnedDate == null);

        /// <summary>
        /// Previous loans for this user
        /// </summary>
        public IEnumerable<Loan> ReturnedLoans => MyLoans.Where(l => l.ReturnedDate != null);

        /// <summary>
        /// All loans for this user
        /// </summary>
        public IEnumerable<Loan> MyLoans { get; set; }

        /// <summary>
        /// Game details in the database
        /// </summary>
        public List<GameDetail> GameDetails { get; set; }

        /// <summary>
        /// Gets a game name from a given game id
        /// </summary>
        /// <param name="gameID">ID of game to find</param>
        /// <returns></returns>
        public string GetGameNameFromID(int gameID)
        {
            var game = GameDetails.FirstOrDefault(g => g.Id == gameID);
            if (game == null)
                return "";

            return game.Name;
        }
    }
}
