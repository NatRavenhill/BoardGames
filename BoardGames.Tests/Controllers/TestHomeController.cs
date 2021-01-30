using BoardGames.Controllers;
using BoardGames.Models;
using BoardGames.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BoardGames.Tests.Controllers
{
    /// <summary>
    /// Tests for the HomeController class
    /// </summary>
    [TestClass]
    public class TestHomeController
    {
        private HomeController controller;

        public TestHomeController()
        {
            var mockBoardGameContext = new MockBoardGameContext();
            controller = new HomeController(null, mockBoardGameContext.Object);
        }

        /// <summary>
        /// Verifies that the Index action returns some game details
        /// </summary>
        [TestMethod]
        public void TestIndex()
        {
            //Act
            var result = controller.Index();
            //Act
            var model = (result as ViewResult).Model as HomeIndexViewModel;
            Assert.IsTrue(model.GameDetails.Any(), "Expected some game details to be returned");
        }
    }
}
