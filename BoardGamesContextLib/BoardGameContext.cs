using BoardGamesContextLib.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BoardGamesContextLib
{
    public interface IBoardGameContext
    {
        DbSet<GameDetail> GameDetail { get; set; }

        int SaveChanges();
    }

    public class BoardGameContext : DbContext, IBoardGameContext
    {
        public DbSet<GameDetail> GameDetail { get; set; }

        public BoardGameContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
