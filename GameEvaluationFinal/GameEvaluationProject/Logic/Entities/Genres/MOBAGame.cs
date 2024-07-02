using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities.Genres
{
    public class MOBAGame : Genre
    {
        public int NumberOfHeroes { get; set; }
        public override string Name => "MOBAGame";

        public override void AddGameToGenre(Game game, IGameAdministration gameAdmin)
        {
            gameAdmin.AddGameToMOBAGameTable(game, NumberOfHeroes);
        }
    }
}
