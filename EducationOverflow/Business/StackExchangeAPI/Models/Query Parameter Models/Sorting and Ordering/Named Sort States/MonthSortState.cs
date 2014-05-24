using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A sort state based on what is listed in the "month" tab on 
    /// a Stack Exchange website.
    /// </summary>
    public class MonthSortState : NamedSortState<Int64> {

        private string API_SORT_NAME = "month";

        /// <summary>
        /// Construct a month sort state.
        /// </summary>
        public MonthSortState() : base(null, null) {}

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}
