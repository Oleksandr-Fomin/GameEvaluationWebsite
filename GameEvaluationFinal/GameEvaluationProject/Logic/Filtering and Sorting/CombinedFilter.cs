using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Filtering_and_Sorting
{
    public class CombinedFilter<T> : IFiltering<T>
    {
        private readonly IEnumerable<IFiltering<T>> _filters;

        public CombinedFilter(IEnumerable<IFiltering<T>> filters)
        {
            _filters = filters;
        }

        public bool Match(T item)
        {
            if (_filters == null || !_filters.Any())
            {
                return true;
            }


            return _filters.All(filter => filter.Match(item));
        }
    }
}
