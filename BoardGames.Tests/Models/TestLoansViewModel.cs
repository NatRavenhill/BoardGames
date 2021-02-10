using BoardGames.Models;
using BoardGames.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGames.Tests.Models
{
    [TestClass]
    public class TestLoansViewModel
    {
        private LoansViewModel viewModel;

        public TestLoansViewModel()
        {
            var mockBoardGameContext = new MockBoardGameContext();
            viewModel = new LoansViewModel(mockBoardGameContext.Object, "1");
        }

        [DataRow(1, "Checkers")]
        [DataRow(2, "Ludo")]
        [TestMethod]
        public void TestGetGameNameFromID(int gameID, string expectedName)
        {
            //Act + Assert
            Assert.AreEqual(expectedName, viewModel.GetGameNameFromID(gameID), $"Expected name to be to be {expectedName}");
        }
    }
}
