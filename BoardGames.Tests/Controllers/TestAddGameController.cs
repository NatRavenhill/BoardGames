using BoardGames.Controllers;
using BoardGames.Models;
using BoardGames.Models.API;
using BoardGames.Tests.Mocks;
using BoardGamesContextLib;
using BoardGamesContextLib.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Tests.Controllers
{

    /// <summary>
    /// Tests for the AddGameController class
    /// </summary>
    [TestClass]
    public class TestAddGameController
    {
        private AddGameController controller;

        public TestAddGameController()
        {
            //Arrange
            var mockBoardGameContext = new MockBoardGameContext();
            controller = new AddGameController(mockBoardGameContext.Object);
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
            Assert.IsTrue(boardGames.Any(), "Expected some board games to be found");
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
            Assert.IsFalse(boardGames.Any(), "Expected no board games to be found");
        }

        #endregion AddGame

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

        #endregion GameDetail

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
        /// Verifies that the success text is set when a game is added
        /// </summary>
        [TestMethod]
        public void TestAddToDatabase_SuccessText()
        {
            //Arrange
            //Act
            controller.AddToDatabase(2);
            //Assert
            var viewModel = controller.Model;
            Assert.AreEqual("Ludo was successfully added!", viewModel.GameAddedText, "Expected success text");
        }

        /// <summary>
        /// Verifies that the result is redirected to the game detail action when a game is added
        /// </summary>
        [TestMethod]
        public void TestAddToDatabase_SuccessAction()
        {
            //Arrange
            //Act
            var result = controller.AddToDatabase(2) as RedirectToActionResult;
            //Assert
            Assert.AreEqual("GameDetail", result.ActionName);
        }

        #endregion AddToDatabase
    }
}
