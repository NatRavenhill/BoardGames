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
    /// Tests for the LoansController class
    /// </summary>
    [TestClass]
    public class TestLoansController
    {
        private LoansController controller;

        public TestLoansController()
        {
            var mockBoardGameContext = new MockBoardGameContext();
            controller = new LoansController(mockBoardGameContext.Object);
        }

        #region Return

        /// <summary>
        /// Verifies that Return redirects to the loans page after completion
        /// </summary>
        [TestMethod]
        public void TestReturn_Result()
        {
            //Arrange
            string expectedURL = "Index";
            //Act
            var result = controller.Return(1);
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
            controller.Return(1);
            //Assert
            Loan newLoan = controller.Database.Loan.First();
            Assert.AreEqual(expectedDate, newLoan.ReturnedDate.Value.ToShortDateString(), $"Expected {expectedDate}");
        }

        #endregion Return
    }
}
