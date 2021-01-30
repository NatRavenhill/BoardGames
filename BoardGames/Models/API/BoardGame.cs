using System;
using System.Xml.Serialization;

namespace BoardGames.Models.API
{
    /// <summary>
    /// Object to represent a BoardGame in the API
    /// </summary>
    [Serializable()]
    public class BoardGame
    {
        /// <summary>
        /// Object ID
        /// </summary>
        [XmlAttribute("objectid")]
        public int ObjectId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Year published
        /// </summary>
        [XmlElement("yearpublished")]
        public int YearPublished { get; set; }
    }
}
