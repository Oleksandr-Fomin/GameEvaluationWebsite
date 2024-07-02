using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities.Genres
{
    public class PlatformGame : Genre
    {
        public int NumberOfLevels { get; set; }
        public override string Name => "PlatformGame";

        public override void AddGameToGenre(Game game, IGameAdministration gameAdmin)
        {
            
            gameAdmin.AddGameToPlatformGameTable(game, NumberOfLevels);
        }
    }
}
