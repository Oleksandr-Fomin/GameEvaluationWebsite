using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities.Genres
{
    public class StealthGame : Genre
    {
        public string StealthMechanics { get; set; }
        public override string Name => "StealthGame";

        public override void AddGameToGenre(Game game, IGameAdministration gameAdmin)
        {
            gameAdmin.AddGameToStealthGameTable(game, StealthMechanics);
        }
    }
}
