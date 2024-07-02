using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic.Filtering_and_Sorting
{
    public class GameFiltering : IFiltering<Game>
    {
        private string _filter;

        public GameFiltering(string filter)
        {
            _filter = filter;
        }

        public bool Match(Game game)
        {
            return game.Title.Contains(_filter)
                || game.Genre.Contains(_filter)
                || game.Description.Contains(_filter);
        }
    }
}
