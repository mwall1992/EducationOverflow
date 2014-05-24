using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A sort state based on the number of (up) votes a Stack Exchange entity has received.
    /// </summary>
    public class VotesSortState : NamedSortState<Int32> {
        
        private string API_SORT_NAME = "votes";

        /// <summary>
        /// Construct a votes sort state for a given range of votes.
        /// </summary>
        /// <param name="min">The lower bound on the number of votes.</param>
        /// <param name="max">The upper bound on the number of votes.</param>
        public VotesSortState(Int32? min, Int32? max) : base(min, max) {}

        public override string Name {
            get {
                return this.API_SORT_NAME;
            }
        }
    }
}
