using BoardGames.Models.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoardGames.Tests.Models.API
{
    /// <summary>
    /// Tests for the ItemList class
    /// </summary>
    [TestClass]
    public class TestItemList
    {
        /// <summary>
        /// Verifies that the item descriptions in the list are decoded
        /// </summary>
        [TestMethod]
        public void TestDecodeHtml()
        {
            //Arrange
            var itemList = new ItemList()
            {
                Items = new List<Item>
                {
                    new Item()
                    {
                        Description = "Dolor ipsum sit amet&#10;"
                    }
                }
            };
            //Act
            itemList.DecodeHtml();
            //Assert
            string expectedResult = "Dolor ipsum sit amet\n";
            var item = itemList.Items.First();
            Assert.AreEqual(expectedResult, item.Description, $"Expected {expectedResult}");
        }
    }
}
