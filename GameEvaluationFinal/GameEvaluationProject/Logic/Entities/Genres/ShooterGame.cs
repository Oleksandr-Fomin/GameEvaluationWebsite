using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities.Genres
{
    public class ShooterGame : Genre
    {
        public string WeaponTypes { get; set; }
        public override string Name => "ShooterGame";

        public override void AddGameToGenre(Game game, IGameAdministration gameAdmin)
        {
            gameAdmin.AddGameToShooterGameTable(game, WeaponTypes);
        }
    }
}
