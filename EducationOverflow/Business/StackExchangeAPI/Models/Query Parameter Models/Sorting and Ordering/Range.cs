using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {
    
    /// <summary>
    /// A bounded range consisting of comparable values.
    /// </summary>
    /// <typeparam name="T">The type of the compared value defining the bound.</typeparam>
    public class Range<T> where T : struct, IComparable<T> {

        /// <summary>
        /// The minimum bound on the range.
        /// </summary>
        protected T? min;

        /// <summary>
        /// The maximum bound on the range.
        /// </summary>
        protected T? max;

        /// <summary>
        /// Construct a range with given bounds.
        /// </summary>
        /// <param name="min">The lower bound on the range.</param>
        /// <param name="max">The upper bound on the range.</param>
        public Range(T? min, T? max) {
            Range<T>.ValidateRange(min, max);
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Get and set the lower bound on the range.
        /// </summary>
        public T? Min {
            get {
                return this.min;
            }

            set {
                Range<T>.ValidateRange(value, this.max);
                this.min = value;
            }
        }

        /// <summary>
        /// Get and set the upper bound on the range.
        /// </summary>
        public T? Max {
            get {
                return this.max;
            }

            set {
                Range<T>.ValidateRange(this.min, value);
                this.max = value;
            }
        }

        // Helper Methods 

        /// <summary>
        /// Validate a given range.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        /// <remarks>
        /// An exception is thrown if an invalid range is specified.
        /// A range is deemed invalid if the lower bound is greater than
        /// the upper bound.
        /// </remarks>
        private static void ValidateRange(T? min, T? max) {
            const int COMPARISON_EQUALITY_VALUE = 0;
            if (min.HasValue && max.HasValue 
                    && min.Value.CompareTo(max.Value) > COMPARISON_EQUALITY_VALUE) {
                throw new ArgumentException("Invalid range bounds: the minimum bound must"
                    + " be less than or equal to the maximum bound. Alternatively, the" 
                    + " bounds can be unspecified (see the IRangeType interface).");
            }
        }
    }
}
