using BoardGames.Models.API;
using System.Collections.Generic;

namespace BoardGames.Models
{
    /// <summary>
    /// Model for the AddGame page
    /// </summary>
    public class AddGameViewModel
    {
        /// <summary>
        /// Text to search board games
        /// </summary>
        public string SearchText { get; set; } = "";

        /// <summary>
        /// Board games returned from the search
        /// </summary>
        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
