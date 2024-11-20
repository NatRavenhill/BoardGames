using BoardGames.Controllers;
using BoardGames.Models;
using BoardGames.Tests.Mocks;
using BoardGamesContextLib.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BoardGames.Tests.Controllers
{
    /// <summary>
    /// Tests for the GameDetailController class
    /// </summary>
    [TestClass]
    public class TestGameDetailController
    {
        private GameDetailController controller;

        /// <summary>
        /// Constructor
        /// </summary>
        public TestGameDetailController()
        {
            var mockBoardGameContext = new MockBoardGameContext();
            controller = new GameDetailController(mockBoardGameContext.Object);
        }
        #region GameDetail

        /// <summary>
        /// Verifies that no item is set in the model when no matching game is found
        /// </summary>
        [TestMethod]
        public void TestGameDetail_NoMatch()
        {
            //Arrange
            //Act
            var result = controller.GameDetail(9999, false);
            //Assert
            var model = (result as ViewResult).Model as GameDetailViewModel;
            Assert.IsNull(model.Item, "Expected no item to returned from the model");
        }

        /// <summary>
        /// Verifies that GameDetail returns the expected game
        /// </summary>
        [TestMethod]
        public void TestGameDetail_Success()
        {
            //Arrange
            //Act
            controller.GameDetail(2, false);
            //Assert
            var item = controller.View().Model as GameDetailViewModel;
            Assert.AreEqual("Ludo", item.Item.Name.Value, "Expected Ludo");
        }

        /// <summary>
        /// Verifies that IsAdded is set correctly
        /// </summary>
        /// <param name="isAdded"></param>
        [TestMethod]
        [DataRow(false)]
        [DataRow(true)]
        public void TestGameDetail_IsAdded(bool isAdded)
        {
            //Arrange
            //Act
            controller.GameDetail(1, isAdded);
            var item = controller.View().Model as GameDetailViewModel;
            //Assert
            Assert.AreEqual(isAdded, item.Added, $"Expected isAdded to be {isAdded}");
        }

        /// <summary>
        /// Verifies that the Game Detail action adds loans for the given game when the game is in the database
        /// </summary>
        [DataRow(1, 2)]
        [DataRow(99, 0)]
        [TestMethod]
        public void TestGameDetail_Loans(int id, int expectedTotal)
        {
            //Arrange
            //Act
            controller.GameDetail(id, false);
            var item = controller.View().Model as GameDetailViewModel;
            //Assert
            Assert.AreEqual(expectedTotal, item.Loans.Count(), $"Expected {expectedTotal} Loans to be added for this game");
        }

        #endregion GameDetail

        #region Borrow

        /// <summary>
        /// Verifies that Borrow redirects to the given game's details page after completion
        /// </summary>
        [TestMethod]
        public void TestBorrow_Result()
        {
            //Arrange
            string expectedURL = "../GameDetail/GameDetail/2";
            //Act
            var result = controller.Borrow(2, 2);
            //Assert
            Assert.AreEqual(expectedURL, (result as RedirectResult).Url, $"Expected {expectedURL}");
        }

        /// <summary>
        /// Verfies that GameID of the new loan is the game's ID
        /// </summary>
        [TestMethod]
        public void TestBorrow_GameID()
        {
            //Arrange
            int gameID = 2;
            //Act
            controller.Borrow(gameID, 2);
            //Assert
            Loan newLoan = controller.Database.Loan.Last();
            Assert.AreEqual(gameID, newLoan.GameID, $"Expected ID to be {gameID}");
        }

        /// <summary>
        /// Verifies that Borrowed Date of new loan object is today
        /// </summary>
        [TestMethod]
        public void TestBorrow_BorrowedDate()
        {
            //Arrange
            string expectedDate = DateTime.Today.ToShortDateString();
            //Act
            controller.Borrow(2, 2);
            //Assert
            Loan newLoan = controller.Database.Loan.Last();
            Assert.AreEqual(expectedDate, newLoan.BorrowedDate.ToShortDateString(), $"Expected {expectedDate}");
        }

        /// <summary>
        /// Verifies that Returned Date of new loan object is null
        /// </summary>
        [TestMethod]
        public void TestBorrow_ReturnedDate()
        {
            //Act
            controller.Borrow(2, 2);
            //Assert
            Loan newLoan = controller.Database.Loan.Last();
            Assert.IsNull(newLoan.ReturnedDate, "Expected null");
        }

        #endregion Borrow

        #region Return

        /// <summary>
        /// Verifies that Return redirects to the given game's details page after completion
        /// </summary>
        [TestMethod]
        public void TestReturn_Result()
        {
            //Arrange
            string expectedURL = "../GameDetail/GameDetail/1";
            //Act
            var result = controller.Return(1,1);
            //Assert
            Assert.AreEqual(expectedURL, (result as RedirectResult).Url, $"Expected {expectedURL}");
        }

        /// <summary>
        /// Verifies that Returned date of loan is set to today
        /// </summary>
        [TestMethod]
        public void TestReturn_ReturnedDate()
        {
            //Arrange
            string expectedDate = DateTime.Today.ToShortDateString();
            //Act
            controller.Return(1, 1);
            //Assert
            Loan newLoan = controller.Database.Loan.First();
            Assert.AreEqual(expectedDate, newLoan.ReturnedDate.Value.ToShortDateString(), $"Expected {expectedDate}");
        }

        #endregion Return
    }
}