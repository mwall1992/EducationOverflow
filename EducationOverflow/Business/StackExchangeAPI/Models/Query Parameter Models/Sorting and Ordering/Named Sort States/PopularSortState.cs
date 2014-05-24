using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A sort state based on the popularity of a Stack Exchange entity.
    /// </summary>
    public class PopularSortState : NamedSortState<Int32> {

        private string API_SORT_NAME = "popular";

        /// <summary>
        /// Construct a popularity sort state for a given "popularity" range.
        /// </summary>
        /// <param name="min">The minimum bound on the popularity range.</param>
        /// <param name="max">The maximum bound on the popularity range.</param>
        public PopularSortState(Int32? min, Int32? max) : base(min, max) { }

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}

