using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI  {

    public class ActivitySortState : SortState<Date> {
        
        private string API_SORT_NAME = "activity";

        public ActivitySortState(Range<Date> activityRange) : base(activityRange) {}

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}
