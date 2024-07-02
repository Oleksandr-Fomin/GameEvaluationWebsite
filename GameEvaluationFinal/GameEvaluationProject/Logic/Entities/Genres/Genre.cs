using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Entities.Genres
{
    public abstract class Genre
    {
        public abstract string Name { get; }
        public abstract void AddGameToGenre(Game game, IGameAdministration gameAdmin);
    }
}
