using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI  {

    /// <summary>
    /// A sort state based on the most recent activity of a Stack Exchange entity.
    /// </summary>
    public class ActivitySortState : NamedSortState<Int64> {
        
        private string API_SORT_NAME = "activity";

        /// <summary>
        /// Construct an activity sort state for a given date range.
        /// </summary>
        /// <param name="min">The lower bound on the date range (in Unix epoch time).</param>
        /// <param name="max">The upper bound on the date range (in Unix epoch time).</param>
        public ActivitySortState(Int64? min, Int64? max) : base(min, max) {}

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}
