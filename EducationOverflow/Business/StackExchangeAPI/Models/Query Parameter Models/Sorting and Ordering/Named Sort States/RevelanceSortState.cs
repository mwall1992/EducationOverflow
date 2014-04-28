using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class RelevanceSortState : NamedSortState<Int32> {

        private string API_SORT_NAME = "relevance";

        public RelevanceSortState() : base(null, null) { }

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}
