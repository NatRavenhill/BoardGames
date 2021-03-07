using BoardGames.Models.API;
using BoardGamesContextLib.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BoardGames.Models
{
    /// <summary>
    /// View model for the Game Detail page
    /// </summary>
    public class GameDetailViewModel
    {
        /// <summary>
        /// Has this game been added to the database
        /// </summary>
        public bool Added { get; set; }

        /// <summary>
        /// Was this game already in the database?
        /// </summary>
        public bool AlreadyInDatabase { get; set; }

        /// <summary>
        /// Item object for the current board game
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Game detail for the current board game  
        /// </summary>
        public GameDetail GameDetail { get; set; }

        /// <summary>
        /// Currently logged in user, if any
        /// </summary>
        public ClaimsPrincipal CurrentUser { get; set; }

        #region Loan

        /// <summary>
        /// Loans for this game
        /// </summary>
        public IEnumerable<Loan> Loans { get; set; } = new List<Loan>();

        /// <summary>
        /// Check if this game is on loan
        /// </summary>
        /// <returns>True if on loan, false otherwise</returns>
        public bool CheckOnLoan()
        {
            return Loans?.Any(l => l.ReturnedDate == null) ?? false;
        }

        /// <summary>
        /// Check if the current logged in user has borrowed this game
        /// </summary>
        /// <returns>True if borrowed by current user</returns>
        public bool IsBorrowedByCurrentUser()
        {
            if (CurrentUser == null)
                return false;
            string userID = CurrentUser.Claims.First().Value;

            return Loans.Any(l => userID.Equals(l.UserID));
        }

        #endregion Loan
    }
}
