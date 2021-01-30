using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BoardGames.Models.API
{
    /// <summary>
    /// Helper methods for the BoardGameAPI class
    /// </summary>
    public static class BoardGameAPIHelper
    {
        public static IBoardGameAPI BoardGameAPI
        {
            get
            {
                if (IsTest())
                    return new MockBoardGameAPI();

                return new BoardGameAPI();
            }
        }

        public static bool IsTest() => Assembly.GetEntryAssembly().FullName.Contains("testhost");
    }
}
