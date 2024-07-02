using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities.Genres
{
    public class ActionGame : Genre
    {


        public string CombatSystem { get; set; }

        public override string Name => "ActionGame";

        public override void AddGameToGenre(Game game, IGameAdministration gameAdmin)
        {
            gameAdmin.AddGameToActionGameTable(game, CombatSystem);
        }
    }
}
