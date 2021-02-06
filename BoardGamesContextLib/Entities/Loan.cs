using System;

namespace BoardGamesContextLib.Entities
{
    /// <summary>
    /// A record of a loan from the library
    /// </summary>
    public class Loan
    {
        /// <summary>
        /// ID of this loan
        /// </summary>
        public int LoanID { get; set; }

        /// <summary>
        /// Id of user who is borrowing the game
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// ID of game borrowed
        /// </summary>
        public int GameID { get; set; }

        /// <summary>
        /// Date the game was borrowed
        /// </summary>
        public DateTime BorrowedDate { get; set; }

        /// <summary>
        /// Date the game was returned
        /// </summary>
        public DateTime? ReturnedDate { get; set; }
    }
}
