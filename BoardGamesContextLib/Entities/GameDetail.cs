using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGamesContextLib.Entities
{
    public class GameDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Int16 YearPublished { get; set; }
        public byte MinPlayers { get; set; }
        public byte MaxPlayers { get; set; }
        public Int16 PlayingTime { get; set; }
        public string ImageLink { get; set; }
        public int BBGId { get; set; }

    }
}
