using BoardGames.Models.API;
using BoardGamesContextLib.Entities;
using System.Collections.Generic;
using System.Linq;

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
        /// Item object for the current board game
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// Is a user logged in?
        /// </summary>
        public bool IsLoggedIn { get; set; }

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

        #endregion Loan
    }
}
