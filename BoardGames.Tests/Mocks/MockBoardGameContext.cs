using BoardGamesContextLib;
using BoardGamesContextLib.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGames.Tests.Mocks
{
    public class MockBoardGameContext : Mock<IBoardGameContext>
    {
        public MockBoardGameContext()
        {
            List<GameDetail> gameDetails = new List<GameDetail>()
            {
                new GameDetail()
                {
                    Id = 1,
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
                    Name = "Ludo",
                    Description = "Lorem ipsum dolor sit amet",
                    YearPublished = 1800,
                    MinPlayers = 2,
                    MaxPlayers = 2,
                    PlayingTime = 20
                }
            };
            DbSet<GameDetail> games = GetQueryableMockDbSet(gameDetails);
            Setup(x => x.GameDetail).Returns(games);
            Setup(x => x.SaveChanges()).Returns(1);
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
