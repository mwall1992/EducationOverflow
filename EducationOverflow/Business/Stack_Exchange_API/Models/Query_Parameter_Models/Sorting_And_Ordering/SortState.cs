using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class SortState<T> : Range<T>, ISortState where T : struct, IComparable<T> {

        public SortState(T? min, T? max) : base(min, max) {}

        public string MinBound {
            get {
                return this.min.Value.ToString();
            }
        }

        public string MaxBound {
            get {
                return this.max.Value.ToString();
            }
        }
    }
}
