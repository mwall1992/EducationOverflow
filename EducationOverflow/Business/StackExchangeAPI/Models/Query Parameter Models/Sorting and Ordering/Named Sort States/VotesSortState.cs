using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class VotesSortState : NamedSortState<Int32> {
        
        private string API_SORT_NAME = "votes";

        public VotesSortState(Int32? min, Int32? max) : base(min, max) {}

        public override string Name {
            get {
                return this.API_SORT_NAME;
            }
        }
    }
}
