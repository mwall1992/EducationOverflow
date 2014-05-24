using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A range of values used to restrict results from a query to the Stack Exchange API.
    /// </summary>
    /// <typeparam name="T">The type of value defining the range.</typeparam>
    public class SortState<T> : Range<T>, ISortState where T : struct, IComparable<T> {

        /// <summary>
        /// Construct a sort state for a given range.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        public SortState(T? min, T? max) : base(min, max) {}

        /// <summary>
        /// Retrieve a string representation of the lower bound.
        /// </summary>
        public string MinBound {
            get {
                return this.min.Value.ToString();
            }
        }

        /// <summary>
        /// Retrieve a string representation of the upper bound.
        /// </summary>
        public string MaxBound {
            get {
                return this.max.Value.ToString();
            }
        }
    }
}
