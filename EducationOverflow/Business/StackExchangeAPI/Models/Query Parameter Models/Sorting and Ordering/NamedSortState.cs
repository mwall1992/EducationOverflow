using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A sort state on a Stack Exchange query that is identified by a string.
    /// </summary>
    /// <typeparam name="T">The type of value defining the range.</typeparam>
    public abstract class NamedSortState<T> : SortState<T>, INamedSortState where T : struct, IComparable<T> {

        /// <summary>
        /// Construct a named sort state for a given range.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public NamedSortState(T? min, T? max) : base(min, max) {}

        /// <summary>
        /// Retrieve the string that identifies the sort state.
        /// </summary>
        public abstract string Name {
            get;
        }
    }
}
