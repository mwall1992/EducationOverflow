using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A sort state based on the relevance of a Stack Exchange entity.
    /// </summary>
    public class RelevanceSortState : NamedSortState<Int32> {

        private string API_SORT_NAME = "relevance";

        /// <summary>
        /// Construct a relevance sort state.
        /// </summary>
        public RelevanceSortState() : base(null, null) { }

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}
