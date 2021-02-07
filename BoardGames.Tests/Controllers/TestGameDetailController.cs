using BoardGames.Controllers;
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

        #region Borrow

        /// <summary>
        /// Verifies that Borrow redirects to the given game's details page after completion
        /// </summary>
        [TestMethod]
        public void TestBorrow_Result()
        {
            //Arrange
            string expectedURL = "../AddGame/GameDetail/2";
            //Act
            var result = controller.Borrow(2, 2);
            //Assert
            Assert.AreEqual(expectedURL, (result as RedirectResult).Url, $"Expected {expectedURL}");
        }

        /// <summary>
        /// Verifies that ID of new loan object is max ID + 1
        /// </summary>
        [TestMethod]
        public void TestBorrow_LoanID()
        {
            //Arrange
            int maxID = controller.Database.Loan.Max(l => l.LoanID);
            //Act
            controller.Borrow(2, 2);
            //Assert
            Loan newLoan = controller.Database.Loan.Last();
            Assert.AreEqual(maxID + 1, newLoan.LoanID, $"Expected ID to be {maxID + 1}");
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
            string expectedURL = "../AddGame/GameDetail/1";
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