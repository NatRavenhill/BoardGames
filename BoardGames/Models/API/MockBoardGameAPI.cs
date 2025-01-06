using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Models.API
{
    internal class MockBoardGameAPI : IBoardGameAPI
    {
        /// <summary>
        /// Gets the board game item list where the ids match the id parameter 
        /// </summary>
        /// <param name="objectid">Object id to find</param>
        /// <returns>A list of items</returns>
        public async Task<ItemList> FindGameByIdAsync(int objectid)
        {
            var list = new ItemList()
            {
                Items = new List<Item>()
                {
                    new Item()
                    {
                        ID = 1,
                        Name = new ValueHolder(){ Value = "Checkers" },
                        YearPublished = new ValueHolder(){ Value = "1800" },
                        MinPlayers = new ValueHolder(){ Value = "2" },
                        MaxPlayers = new ValueHolder(){ Value = "2" },
                        PlayingTime = new ValueHolder(){ Value = "20" },
                    },
                    new Item()
                    {
                        ID = 2,
                        Name = new ValueHolder(){ Value = "Ludo" },
                        YearPublished = new ValueHolder(){ Value = "1900" },
                        MinPlayers = new ValueHolder(){ Value = "2" },
                        MaxPlayers = new ValueHolder(){ Value = "4" },
                        PlayingTime = new ValueHolder(){ Value = "20" },
                    },
                    new Item()
                    {
                        ID = 3,
                        Name = new ValueHolder(){ Value = "Scrabble" },
                        YearPublished = new ValueHolder(){ Value = "1948" },
                        MinPlayers = new ValueHolder(){ Value = "2" },
                        MaxPlayers = new ValueHolder(){ Value = "4" },
                        PlayingTime = new ValueHolder(){ Value = "20" },
                    },
                    new Item()
                    {
                        ID = 4,
                        Name = new ValueHolder(){ Value = "Monopoly" },
                        YearPublished = new ValueHolder(){ Value = "1800" },
                        MinPlayers = new ValueHolder(){ Value = "2" },
                        MaxPlayers = new ValueHolder(){ Value = "4" },
                        PlayingTime = new ValueHolder(){ Value = "20" }
                    },
                    new Item()
                    {
                        ID = 5,
                        Name = new ValueHolder(){ Value = "Dobble" },
                        YearPublished = new ValueHolder(){ Value = "2012" },
                        MinPlayers = new ValueHolder(){ Value = "2" },
                        MaxPlayers = new ValueHolder(){ Value = "4" },
                        PlayingTime = new ValueHolder(){ Value = "20" }
                    }
                }
            };


            return new ItemList() { Items = list.Items.Where(i => i.ID == objectid).ToList() };
        }

        /// <summary>
        /// Gets the board games with name matching the search text
        /// </summary>
        /// <param name="searchText">Text to search for</param>
        /// <returns>A list of board games</returns>
        public async Task<ItemList> SearchBoardGamesAsync(string searchText)
        {
            var list = new ItemList()
            {
                Items = new List<Item>()
                {
                    new Item()
                    {
                        ID = 1,
                        Name = new ValueHolder(){ Value = "Checkers" },
                        YearPublished = new ValueHolder(){ Value = "1800" }
                    },
                    new Item()
                    {
                        ID  = 2,
                        Name = new ValueHolder(){ Value = "Ludo" },
                        YearPublished = new ValueHolder(){ Value = "1900" }
                    },
                    new Item()
                    {
                        ID = 3,
                        Name = new ValueHolder(){ Value = "Scrabble" },
                        YearPublished= new ValueHolder(){ Value = "1948" }
                    },
                    new Item()
                    {
                        ID = 4,
                        Name = new ValueHolder() { Value = "Monopoly" },
                        YearPublished = new ValueHolder(){ Value = "1800" }
                    },
                    new Item()
                    {
                        ID = 5,
                        Name = new ValueHolder() { Value = "Dobble" },
                        YearPublished = new ValueHolder(){ Value = "2012" }
                    }
                }
            };

            List<Item> matchingGames = list.Items.Where(g => g.Name.Value.Contains(searchText)).ToList();
            return new ItemList() { Items = matchingGames };
            

        }
    }
}