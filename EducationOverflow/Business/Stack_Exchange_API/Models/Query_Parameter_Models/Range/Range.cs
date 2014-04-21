using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {
    
    public class Range<T> where T : IComparable<T>, IRangeType {

        protected T min;

        protected T max;

        public Range(T min, T max) {
            Range<T>.ValidateRange(min, max);
            this.min = min;
            this.max = max;
        }

        public T Min {
            get {
                return this.min;
            }

            set {
                Range<T>.ValidateRange(value, this.max);
                this.min = value;
            }
        }

        public T Max {
            get {
                return this.max;
            }

            set {
                Range<T>.ValidateRange(this.min, value);
                this.max = value;
            }
        }

        private static void ValidateRange(T min, T max) {
            const int COMPARISON_EQUALITY_VALUE = 0;
            if (!min.IsUnspecifiedBound() || !max.IsUnspecifiedBound() 
                    || min.CompareTo(max) > COMPARISON_EQUALITY_VALUE) {
                throw new ArgumentException("Invalid range bounds: the minimum bound must"
                    + " be less than or equal to the maximum bound. Alternatively, the" 
                    + " bounds can be unspecified (see the IRangeType interface).");
            }
        }
    }
}
