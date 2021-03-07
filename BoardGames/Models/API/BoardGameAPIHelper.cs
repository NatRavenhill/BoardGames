using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BoardGames.Models.API
{
    /// <summary>
    /// Helper methods for the BoardGameAPI class
    /// </summary>
    public class BoardGameAPIHelper
    {
        private IBoardGameAPI boardGameAPI;

        private BoardGameAPIHelper()
        {

        }

        private static readonly Lazy<BoardGameAPIHelper> lazy = new Lazy<BoardGameAPIHelper>
           (() => new BoardGameAPIHelper());

        /// <summary>
        /// Instance of singleton class
        /// </summary>
        public static BoardGameAPIHelper Instance => lazy.Value;

        /// <summary>
        /// Board game API 
        /// </summary>
        public IBoardGameAPI BoardGameAPI
        {
            get
            {
                if (boardGameAPI == null)
                {
                    if (IsTest())
                        boardGameAPI = new MockBoardGameAPI();
                    else
                        boardGameAPI =  new BoardGameAPI();
                }

                return boardGameAPI;
               
            }
        }

        /// <summary>
        /// Gets details for the game with the given id
        /// </summary>
        /// <param name="id">ID of game to find</param>
        /// <returns>A Game detail item with the matching id or null otherwise</returns>
        public async Task<Item> GetGameDetail(int id)
        {
            var boardGameAPI = BoardGameAPI;
            ItemList resultList = await boardGameAPI.FindGameByIdAsync(id);
            Item foundGame = resultList.Items.FirstOrDefault();
            return foundGame;
        }

        /// <summary>
        /// Are we in test mode?
        /// </summary>
        /// <returns>A bool</returns>
        public static bool IsTest() => Assembly.GetEntryAssembly().FullName.Contains("testhost");
    }
}
