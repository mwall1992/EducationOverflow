using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A sort state based on what is listed in the "week" tab on 
    /// a Stack Exchange website.
    /// </summary>
    public class WeekSortState : NamedSortState<Int64> {

        private string API_SORT_NAME = "week";

        /// <summary>
        /// Construct a week sort state.
        /// </summary>
        public WeekSortState() : base(null, null) { }

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}
