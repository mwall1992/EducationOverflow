using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public abstract class NamedSortState<T> : SortState<T>, INamedSortState where T : struct, IComparable<T> {

        public NamedSortState(T? min, T? max) : base(min, max) {}

        public abstract string Name {
            get;
        }
    }
}
