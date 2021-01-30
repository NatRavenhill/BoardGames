using BoardGames.Models.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BoardGames.Tests.Models.Extensions
{
    /// <summary>
    /// Tests for the string extensions class
    /// </summary>
    [TestClass]
    public class TestStringExtensions
    {
        /// <summary>
        /// Verifies that the Contains ignoring case method is ony true when the strings match ignoring case
        /// </summary>
        /// <param name="string1">First string</param>
        /// <param name="string2">Second string</param>
        /// <param name="expectedResult">Expected result</param>
        [TestMethod]
        [DataRow("test", "TeST", true)]
        [DataRow("test", "TE", true)]
        [DataRow("test", "dsafdgsf", false)]
        public void TestContainsIgnoringCase(string string1, string string2, bool expectedResult)
        {
            //Arrange
            //Act
            bool result = string1.ContainsIgnoringCase(string2);
            //Assert
            Assert.AreEqual(expectedResult, result, $"Expected result to be {expectedResult}");
        }
    }
}
