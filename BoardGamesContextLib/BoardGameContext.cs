using BoardGamesContextLib.Entities;
using Microsoft.EntityFrameworkCore;

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
    }
}
