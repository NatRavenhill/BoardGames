using BoardGamesContextLib.Entities;
using System.Collections.Generic;

namespace BoardGames.Models
{
    /// <summary>
    /// View model for the Home Page
    /// </summary>
    public class HomeIndexViewModel
    {
        /// <summary>
        /// List of most popular games to display on the Home page
        /// </summary>
        public List<GameDetail> MostPopularGames { get; set; }
    }
}
