using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace BoardGames.Models.API
{
    /// <summary>
    /// Class to get data from the BoardGameGeek API
    /// </summary>
    public class BoardGameAPI : IBoardGameAPI
    {
        const string apiUrl = "https://www.boardgamegeek.com/xmlapi2/";

        /// <summary>
        /// Gets the board games with name matching the search text
        /// </summary>
        /// <param name="searchText">Text to search for</param>
        /// <returns>A list of board games</returns>
        public async Task<ItemList> SearchBoardGamesAsync(string searchText)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(apiUrl)
            };
            string content = await GetContentAsync($"search?query={searchText}&type=boardgame", client);
            return XmlToObject<ItemList>(content);
        }

        /// <summary>
        /// Gets the board game item list where the ids match the id parameter 
        /// </summary>
        /// <param name="objectid">Object id to find</param>
        /// <returns>A list of items</returns>
        public async Task<ItemList> FindGameByIdAsync(int objectid)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(apiUrl)
            };

            string content = await GetContentAsync($"thing?id={objectid}", client);
            ItemList response = XmlToObject<ItemList>(content);
            response.DecodeHtml();
            return response;

        }

        #region Helper methods

        /// <summary>
        /// Converts XMl input to a T
        /// </summary>
        /// <param name="input">XML string to convert</param>
        /// <returns>A T</returns>
        private T XmlToObject<T>(string input)
        {
            var xmls = new XmlSerializer(typeof(T));

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
            return (T)xmls.Deserialize(stream);
        }

        private async Task<string> GetContentAsync(string query, HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(query);
            HttpStatusCode statusCode = response.StatusCode;

            if (statusCode == HttpStatusCode.OK)
            {
                string asString = await response.Content.ReadAsStringAsync();
                return asString;

            }

            return "";
        }

        #endregion Helper methods

        

    }
}
