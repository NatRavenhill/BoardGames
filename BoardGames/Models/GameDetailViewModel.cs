using BoardGames.Models.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Models
{
    public class GameDetailViewModel
    {
        public bool Added { get; set; }

        public Item Item { get; set; }
    }
}
