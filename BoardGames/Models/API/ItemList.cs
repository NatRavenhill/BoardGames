using System;
using System.Collections.Generic;
using System.Net;
using System.Xml.Serialization;

namespace BoardGames.Models.API
{
    /// <summary>
    /// Object to represent a list of items in the API
    /// </summary>
    [Serializable()]
    [XmlRoot("items", Namespace = "", IsNullable = false)]
    public class ItemList
    {
        /// <summary>
        /// List of items
        /// </summary>
        [XmlElement("item")]
        public List<Item> Items { get; set; }


        /// <summary>
        /// Decode special characters in HTML response
        /// </summary>
        public void DecodeHtml() 
        {
            foreach(Item item in Items)
             item.Description = WebUtility.HtmlDecode(item.Description);
           
        }
    }
}
