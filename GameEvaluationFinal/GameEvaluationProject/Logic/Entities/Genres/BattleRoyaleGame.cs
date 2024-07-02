using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities.Genres
{
    public class BattleRoyaleGame : Genre
    {
        public int PlayerCapacity { get; set; }
        public override string Name => "BattleRoyaleGame";

        public override void AddGameToGenre(Game game, IGameAdministration gameAdmin)
        {
            gameAdmin.AddGameToBattleRoyaleGameTable(game, PlayerCapacity);
        }
    }
}
