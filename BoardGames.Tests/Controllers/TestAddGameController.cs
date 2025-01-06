using BoardGames.Controllers;
using BoardGames.Models;
using BoardGames.Tests.Mocks;
using BoardGamesContextLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BoardGames.Tests.Controllers
{

    /// <summary>
    /// Tests for the AddGameController class
    /// </summary>
    [TestClass]
    public class TestAddGameController
    {
        private AddGameController controller;
        private IBoardGameContext mockBoardGameContext;

        public TestAddGameController()
        {
            //Arrange
            mockBoardGameContext = new MockBoardGameContext().Object;
            controller = new AddGameController(mockBoardGameContext);
        }

        #region AddGame

        /// <summary>
        /// Verifies that when the model is null when there is no search string
        /// </summary>
        [TestMethod]
        public void TestAddGame_Null()
        {
            //Arrange
            //Act
            controller.AddGame(null);
            //Assert
            Assert.IsNull(controller.View().Model, "Expected no model to be returned");
        }

        /// <summary>
        /// Verifies that we get a list of board games returned when the search string matches all game titles
        /// </summary>
        [TestMethod]
        public void TestAddGame_Success()
        {
            //Arrange
            //Act
            IActionResult result = controller.AddGame("Ludo");
            //Assert
            var model = (result as ViewResult).Model;
            var boardGames = (model as AddGameViewModel).BoardGames;
            Assert.IsTrue(boardGames.Items.Any(), "Expected some board games to be found");
        }

        /// <summary>
        /// Verifies that we get a model but no board games when the searchs tring does not match
        /// </summary>
        [TestMethod]
        public void TestAddGame_UnmatchedSearchString()
        {
            //Arrange
            //Act
            IActionResult result = controller.AddGame("adfsadghfs");
            //Assert
            var model = (result as ViewResult).Model;
            var boardGames = (model as AddGameViewModel).BoardGames;
            Assert.IsFalse(boardGames.Items.Any(), "Expected no board games to be found");
        }

        #endregion AddGame

        #region AddToDatabase

        /// <summary>
        /// Verfies that adding a game that is not found in the API returns a NotFoudn result
        /// </summary>
        [TestMethod]
        public void TestAddToDatabase_NotFound()
        {
            //Arrange
            //Act
            var result = controller.AddToDatabase(12);
            //Assert
            Assert.IsTrue(result is NotFoundResult, "Expected a not found result");
        }

        /// <summary>
        /// Verifies flags passed to the GameDetail controller are set correctly when a game is added
        /// </summary>
        [TestMethod]
        public void TestAddToDatabase_SuccessFlags()
        {
            //Arrange
            //Act
            var result = controller.AddToDatabase(5) as RedirectToActionResult;
            //Assert
            bool isAdded = (bool)result.RouteValues["isAdded"];
            bool alreadyInDatabase = (bool)result.RouteValues["alreadyInDatabase"];
            Assert.IsTrue(isAdded && !alreadyInDatabase, "Expected new game to be added");
        }

        /// <summary>
        /// Verifies that the result is redirected to the game detail action when a game is added
        /// </summary>
        [TestMethod]
        public void TestAddToDatabase_SuccessAction()
        {
            //Arrange
            //Act
            var result = controller.AddToDatabase(5) as RedirectToActionResult;
            //Assert
            Assert.AreEqual("GameDetail", result.ActionName);
        }

        /// <summary>
        /// Verifies that a game is not added when it is alreadty in the database
        /// </summary>
        [TestMethod]
        public void TestAddToDatabase_AlreadyAdded()
        {
            //Arrange
            int totalGames = mockBoardGameContext.GameDetail.Count();
            //Act
            var result = controller.AddToDatabase(1) as RedirectToActionResult;
            //Assert
            Assert.AreEqual(totalGames, mockBoardGameContext.GameDetail.Count(), "Expected no change in total board games");
        }


        /// <summary>
        /// Verifies flags passed to the GameDetail controller are set correctly when a game has already been added
        /// </summary>
        [TestMethod]
        public void TestAddToDatabase_AlreadyAddedFlags()
        {
            //Arrange
            //Act
            var result = controller.AddToDatabase(1) as RedirectToActionResult;
            //Assert
            bool isAdded = (bool)result.RouteValues["isAdded"];
            bool alreadyInDatabase = (bool)result.RouteValues["alreadyInDatabase"];
            Assert.IsTrue(isAdded && alreadyInDatabase, "Expected Checkers to not be added");
        }

        #endregion AddToDatabase
    }
}
