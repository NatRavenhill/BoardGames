using BoardGames.Controllers;
using BoardGames.Models;
using BoardGames.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BoardGames.Tests.Controllers
{
    /// <summary>
    /// Tests for the BrowseLibraryController class
    /// </summary>
    [TestClass]
    public class TestBrowseLibraryController
    {
        private BrowseLibraryController controller;

        public TestBrowseLibraryController()
        {
            var mockBoardGameContext = new MockBoardGameContext();
            controller = new BrowseLibraryController(mockBoardGameContext.Object);
        }

        /// <summary>
        /// Verifies that all game details are returned when the search string is empty
        /// </summary>
        [TestMethod]
        public void TestBrowseLibrary_Empty()
        {
            //Act
            var result = controller.BrowseLibrary();
            //Assert
            var model = (result as ViewResult).Model as BrowseLibraryViewModel;
            Assert.AreEqual(4, model.GameDetails.Count(), "Expected all game details to be retured");
        }

        /// <summary>
        /// Verifies that some game details are returned when the search string is empty
        /// </summary>
        [TestMethod]
        public void TestBrowseLibrary_NonEmpty()
        {
            //Act
            var result = controller.BrowseLibrary("Ludo");
            //Assert
            var model = (result as ViewResult).Model as BrowseLibraryViewModel;
            Assert.IsTrue(model.GameDetails.Any(), "Expected some game details to be retured");
        }
    }
}
