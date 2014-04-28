using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class MonthSortState : NamedSortState<Int64> {

        private string API_SORT_NAME = "month";

        public MonthSortState() : base(null, null) {}

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}
