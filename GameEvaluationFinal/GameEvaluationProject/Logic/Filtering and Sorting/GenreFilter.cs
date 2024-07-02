using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;

namespace Logic.Filtering_and_Sorting
{
    public class GenreFilter : IFiltering<Game>
    {
        private string _selectedGenre;

        public GenreFilter(string selectedGenre)
        {
            _selectedGenre = selectedGenre;
        }

        public bool Match(Game game)
        {
            return game.Genre == _selectedGenre;
        }
    }
}
