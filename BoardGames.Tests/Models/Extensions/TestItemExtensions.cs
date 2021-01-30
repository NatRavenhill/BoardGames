using BoardGames.Models.API;
using BoardGames.Models.Extensions;
using BoardGamesContextLib.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BoardGames.Tests.Models.Extensions
{
    /// <summary>
    /// Tests for the ItemExtensions class
    /// </summary>
    [TestClass]
    public class TestItemExtensions
    {
        private Item item;
        public TestItemExtensions()
        {
            item = new Item()
            {
                ID = 1,
                Name = new ValueHolder() { Value = "Test Game" },
                Description = "A game for testing",
                YearPublished = new ValueHolder { Value = "2012" },
                MinPlayers = new ValueHolder { Value = "2" },
                MaxPlayers = new ValueHolder { Value = "4" },
                PlayingTime = new ValueHolder { Value = "60" },
                ImageUrl = "http://test.com/img.jpg",
            };
        }

        #region GetGameDetail

        /// <summary>
        /// Verifies that the id of the resulting game detail is 0
        /// </summary>
        [TestMethod]
        public void TestGetGameDetail_Id()
        {
            //Arrange
            //Act
            GameDetail result = item.GetGameDetail();
            //Assert
            Assert.AreEqual(result.Id, 0, "Expected ID to be 0");
        }

        /// <summary>
        /// Verifies that the name of the resulting game detail is the item's name
        /// </summary>
        [TestMethod]
        public void TestGetGameDetail_Name()
        {
            //Arrange
            //Act
            GameDetail result = item.GetGameDetail();
            //Assert
            Assert.AreEqual(item.Name.Value, result.Name, "Expected name to be item name");
        }

        /// <summary>
        /// Verifies that the description of the resulting game detail is the item's description
        /// </summary>
        [TestMethod]
        public void TestGetGameDetail_Description()
        {
            //Arrange
            //Act
            GameDetail result = item.GetGameDetail();
            //Assert
            Assert.AreEqual(item.Description, result.Description, "Expected description to be item description");
        }

        /// <summary>
        /// Verifies that the year published of the resulting game detail is the item's year published
        /// </summary>
        [TestMethod]
        public void TestGetGameDetail_YearPublished()
        {
            //Arrange
            //Act
            GameDetail result = item.GetGameDetail();
            //Assert
            Assert.AreEqual(short.Parse(item.YearPublished.Value), result.YearPublished, "Expected year published to be item year published");
        }

        /// <summary>
        /// Verifies that the min players of the resulting game detail is the item's min players
        /// </summary>
        [TestMethod]
        public void TestGetGameDetail_MinPlayers()
        {
            //Arrange
            //Act
            GameDetail result = item.GetGameDetail();
            //Assert
            Assert.AreEqual(byte.Parse(item.MinPlayers.Value), result.MinPlayers, "Expected min players to be item min players");
        }

        /// <summary>
        /// Verifies that the max players of the resulting game detail is the item's max players
        /// </summary>
        [TestMethod]
        public void TestGetGameDetail_MaxPlayers()
        {
            //Arrange
            //Act
            GameDetail result = item.GetGameDetail();
            //Assert
            Assert.AreEqual(byte.Parse(item.MaxPlayers.Value), result.MaxPlayers, "Expected max players to be item max players");
        }

        /// <summary>
        /// Verifies that the playing time of the resulting game detail is the item's playing time
        /// </summary>
        [TestMethod]
        public void TestGetGameDetail_PlayingTime()
        {
            //Arrange
            //Act
            GameDetail result = item.GetGameDetail();
            //Assert
            Assert.AreEqual(Int16.Parse(item.PlayingTime.Value), result.PlayingTime, "Expected playing time to be item playing time");
        }

        /// <summary>
        /// Verifies that the image url of the resulting game detail is the item's image link
        /// </summary>
        [TestMethod]
        public void TestGetGameDetail_ImageLink()
        {
            //Arrange
            //Act
            GameDetail result = item.GetGameDetail();
            //Assert
            Assert.AreEqual(item.ImageUrl, result.ImageLink, "Expected image link to be item image url");

        }

        /// <summary>
        /// Verifies that the BBGId of the resulting game detail is the item's ID
        /// </summary>
        [TestMethod]
        public void TestGetGameDetail_BBGId()
        {
            //Arrange
            //Act
            GameDetail result = item.GetGameDetail();
            //Assert
            Assert.AreEqual(item.ID, result.BBGId, "Expected BBGId to be item ID");

        }
        #endregion GetGameDetail
    }
}
