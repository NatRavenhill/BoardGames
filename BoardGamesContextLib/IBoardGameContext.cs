using BoardGamesContextLib.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesContextLib
{
    /// <summary>
    /// Database context for the BoardGames database
    /// </summary>
    public interface IBoardGameContext
    {
        /// <summary>
        /// Game details collection
        /// </summary>
        DbSet<GameDetail> GameDetail { get; set; }

        /// <summary>
        /// Loan details collection
        /// </summary>
        DbSet<Loan> Loan { get; set; }

        /// <summary>
        /// Save changes method
        /// </summary>
        /// <returns>Integer save change result</returns>
        int SaveChanges();

        /// <summary>
        /// Return a loaned game with the given ID to the library
        /// </summary>
        /// <param name="gameID">Game ID</param>
        /// <returns>Save result as integer</returns>
        int ReturnLoan(int gameID);
    }
}
