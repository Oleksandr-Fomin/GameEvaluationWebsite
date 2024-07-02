using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Filtering_and_Sorting
{
    public class ReverseComparer<T> : IComparer<T>
    {
        private IComparer<T> _originalComparer;

        public ReverseComparer(IComparer<T> originalComparer)
        {
            _originalComparer = originalComparer;
        }

        public int Compare(T x, T y)
        {
            return _originalComparer.Compare(y, x);
        }
    }
}
