using System;
using System.Xml.Serialization;

namespace BoardGames.Models.API
{
    [Serializable()]

    public class Item
    {
        [XmlAttribute("id")]
        public int ID { get; set; }

        [XmlElement("name")]
        public ValueHolder Name { get; set; }

        [XmlElement("image")]
        public string ImageUrl { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("yearpublished")]
        public ValueHolder YearPublished { get; set; }

        [XmlElement("minplayers")]
        public ValueHolder MinPlayers { get; set; }

        [XmlElement("maxplayers")]
        public ValueHolder MaxPlayers { get; set; }

        [XmlElement("playingtime")]
        public ValueHolder PlayingTime { get; set; }
    }
}
