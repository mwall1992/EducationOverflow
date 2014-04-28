using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI  {

    public class ActivitySortState : NamedSortState<Int64> {
        
        private string API_SORT_NAME = "activity";

        public ActivitySortState(Int64 min, Int64 max) : base(min, max) {}

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}
