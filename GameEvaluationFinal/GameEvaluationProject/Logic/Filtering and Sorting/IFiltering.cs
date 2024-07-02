using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Filtering_and_Sorting
{
    public interface IFiltering<T>
    {
        bool Match(T item);
    }
}
