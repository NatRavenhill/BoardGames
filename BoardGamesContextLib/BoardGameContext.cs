﻿using BoardGamesContextLib.Entities;
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
            modelBuilder.Entity<GameDetail>().HasData(
                new GameDetail()
                {
                    Id = 1,
                    Name = "Scrabble",
                    Description = "Carefully place your lettered tiles to make high-scoring words.",
                    YearPublished = 1948,
                    MinPlayers = 2,
                    MaxPlayers = 4,
                    PlayingTime = 90,
                    ImageLink = "https://cf.geekdo-images.com/mVmmntn2oQd0PfFrWBvwIQ__original/img/11jrKPiOVTNl5NwX83KGtTZEq40=/0x0/filters:format(jpeg)/pic404651.jpg",
                    BBGId = 320
                }, 
                new GameDetail()
                {
                    Id = 2,
                    Name = "Forbidden Island",
                    Description = "The island is sinking! Will the brave adventurers save the treasures in time?",
                    YearPublished = 2010,
                    MinPlayers = 2,
                    MaxPlayers = 4,
                    PlayingTime = 30,
                    ImageLink = "https://cf.geekdo-images.com/JgAkEBUaiHOsOS94iRMs2w__original/img/H5d4I5z_HSpPEu7EAl0DqLt9_pM=/0x0/filters:format(jpeg)/pic646458.jpg",
                    BBGId = 65244
                });

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
