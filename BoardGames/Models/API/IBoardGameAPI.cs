using System.Threading.Tasks;

namespace BoardGames.Models.API
{
    public interface IBoardGameAPI
    {
        /// <summary>
        /// Gets the board games with name matching the search text
        /// </summary>
        /// <param name="searchText">Text to search for</param>
        /// <returns>A list of board games</returns>
        public Task<ItemList> SearchBoardGamesAsync(string searchText);

        /// <summary>
        /// Gets the board game item list where the ids match the id parameter 
        /// </summary>
        /// <param name="objectid">Object id to find</param>
        /// <returns>A list of items</returns>
        public Task<ItemList> FindGameByIdAsync(int objectid);
    }
}
