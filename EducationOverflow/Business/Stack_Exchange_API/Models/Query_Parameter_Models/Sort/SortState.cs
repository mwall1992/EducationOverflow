using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // State design pattern - Abstract State

    public abstract class SortState<T> : ISortState where T : IComparable<T>, IRangeType {

        private Range<T> range;

        public SortState(Range<T> range) {
            this.range = range;
        }

        public Range<T> Range {
            get {
                return this.range;
            }

            set {
                this.range = value;
            }
        }

        public abstract string Name {
            get;
        }

        public string MinBound {
            get {
                return range.Min.ToString();
            }
        }

        public string MaxBound {
            get {
                return range.Max.ToString();
            }
        }
    }
}
