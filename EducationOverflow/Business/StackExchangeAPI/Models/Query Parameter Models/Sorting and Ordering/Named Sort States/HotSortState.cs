using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A sort state based on what is listed in the "hot" tab on 
    /// a Stack Exchange website.
    /// </summary>
    public class HotSortState : NamedSortState<Int64> {

        private string API_SORT_NAME = "hot";

        /// <summary>
        /// Construct a hot sort state.
        /// </summary>
        public HotSortState() : base(null, null) { }

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}
