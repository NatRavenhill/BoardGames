using BoardGames.Models;
using BoardGamesContextLib.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BoardGames.Tests.Models
{
    [TestClass]
    public class TestGameDetailViewModel
    {
        private GameDetailViewModel viewModel;

        public TestGameDetailViewModel()
        {
            viewModel = new GameDetailViewModel();
        }

        [TestMethod]
        public void TestCheckOnLoan_True()
        {
            //Arrange
            viewModel.Loans = new List<Loan>()
            {
                new Loan()
            };
            //Act + Assert
            Assert.IsTrue(viewModel.CheckOnLoan(), "Expected game to be on loan");
        }

        [TestMethod]
        public void TestCheckOnLoan_False()
        {
            //Arrange
            viewModel.Loans = new List<Loan>()
            {
                new Loan(){ ReturnedDate = DateTime.Now }
            };
            //Act + Assert
            Assert.IsFalse(viewModel.CheckOnLoan(), "Expected game to not be on loan");
        }
    }
}
