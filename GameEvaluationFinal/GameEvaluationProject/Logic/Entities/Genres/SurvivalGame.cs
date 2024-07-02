using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities.Genres
{
    public class SurvivalGame : Genre
    {
        public string EnvironmentType { get; set; }
        public override string Name => "SurvivalGame";

        public override void AddGameToGenre(Game game, IGameAdministration gameAdmin)
        {
            gameAdmin.AddGameToSurvivalGameTable(game, EnvironmentType);
        }
    }
}
