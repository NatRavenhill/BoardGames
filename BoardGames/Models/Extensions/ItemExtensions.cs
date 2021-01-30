using BoardGames.Models.API;
using BoardGamesContextLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Models.Extensions
{
    public static class ItemExtensions
    {

        public static GameDetail GetGameDetail(this Item item)
        {
            return new GameDetail()
            {
                Id = 0,
                Name = item.Name.Value,
                Description = item.Description,
                YearPublished = short.Parse(item.YearPublished.Value),
                MinPlayers = byte.Parse(item.MinPlayers.Value),
                MaxPlayers = byte.Parse(item.MaxPlayers.Value),
                PlayingTime = Int16.Parse(item.PlayingTime.Value),
                ImageLink = item.ImageUrl,
                BBGId = item.ID,
            };
        }
    }
}
