using BoardGamesContextLib;
using BoardGamesContextLib.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoardGames.Tests.Mocks
{
    public class MockBoardGameContext : Mock<IBoardGameContext>
    {
        public MockBoardGameContext()
        {
            SetupGameDetails();
            SetupLoans();
            Setup(x => x.SaveChanges()).Returns(1);
            Setup(x => x.ReturnLoan(It.IsAny<int>())).Returns(MockReturnLoan());
        }

        private int MockReturnLoan()
        {
            Object.Loan.First().ReturnedDate = DateTime.Now;
            return 1;
        }

        private void SetupGameDetails()
        {
            List<GameDetail> gameDetails = new List<GameDetail>()
            {
                new GameDetail()
                {
                    Id = 1,
                    BBGId = 1,
                    Name = "Checkers",
                    Description = "Lorem ipsum dolor sit amet",
                    YearPublished = 1800,
                    MinPlayers = 2,
                    MaxPlayers = 2,
                    PlayingTime = 20
                },
                new GameDetail()
                {
                    Id = 2,
                    BBGId = 2,
                    Name = "Ludo",
                    Description = "Lorem ipsum dolor sit amet",
                    YearPublished = 1800,
                    MinPlayers = 2,
                    MaxPlayers = 2,
                    PlayingTime = 20
                },
                new GameDetail()
                {
                    Id = 3,
                    BBGId = 3,
                    Name = "Scrabble",
                    Description = "Lorem ipsum dolor sit amet",
                    YearPublished = 1800,
                    MinPlayers = 2,
                    MaxPlayers = 4,
                    PlayingTime = 20
                },
                new GameDetail()
                {
                    Id = 4,
                    BBGId = 4,
                    Name = "Monopoly",
                    Description = "Lorem ipsum dolor sit amet",
                    YearPublished = 1800,
                    MinPlayers = 2,
                    MaxPlayers = 4,
                    PlayingTime = 20
                },
            };
            DbSet<GameDetail> games = GetQueryableMockDbSet(gameDetails);
            Setup(x => x.GameDetail).Returns(games);
        }

        private void SetupLoans()
        {
            List<Loan> loanList = new List<Loan>()
            {
                new Loan()
                {
                    LoanID = 1,
                    GameID = 1,
                    UserID = "1"
                },
                new Loan()
                {
                    LoanID = 2,
                    GameID = 1,
                    UserID = "3"
                },
                new Loan()
                {
                    LoanID = 3,
                    GameID = 3,
                    UserID = "1"
                }
            };
            DbSet<Loan> loans = GetQueryableMockDbSet(loanList);
            Setup(x => x.Loan).Returns(loans);
        }

        private static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            IQueryable<T> queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }
    }

}
