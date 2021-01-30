using System;
using System.Xml.Serialization;

namespace BoardGames.Models.API
{
    [Serializable()]
    public class ValueHolder
    {
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
}
