using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BoardGames.Models.API
{
    /// <summary>
    /// Object to represent a list of board games in the API
    /// </summary>
    [Serializable()]
    [XmlRoot("boardgames", Namespace = "", IsNullable = false)]
    public class BoardGameList
    {
        public BoardGameList()
        {

        }

        public BoardGameList(List<BoardGame> boardGames)
        {
            this.BoardGames = boardGames;
        }

        /// <summary>
        /// List of board games
        /// </summary>
        [XmlElement("boardgame")]
        public List<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
