using BoardGamesContextLib.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BoardGamesContextLib
{
    /// <summary>
    /// Database context for the BoardGames database
    /// </summary>
    public class BoardGameContext : DbContext, IBoardGameContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options">Database options</param>
        public BoardGameContext(DbContextOptions options)
            : base(options)
        {

        }

        /// <summary>
        /// Game details collection
        /// </summary>
        public DbSet<GameDetail> GameDetail { get; set; }

        /// <summary>
        /// Loan details collection
        /// </summary>
        public DbSet<Loan> Loan { get; set; }
        
        /// <summary>
        /// Model creation actions
        /// </summary>
        /// <param name="modelBuilder">The model builder to use</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #region Loan

        /// <summary>
        /// Return a loaned game with the given ID to the library
        /// </summary>
        /// <param name="gameID">Game ID</param>
        /// <returns>Save result as integer</returns>
        public int ReturnLoan(int gameID)
        {
            var loan = Loan.First(l => l.GameID == gameID && l.ReturnedDate == null);
            loan.ReturnedDate = DateTime.Now;
            int saveResult = SaveChanges();
            return saveResult;
        }

        #endregion Loan

    }
}
