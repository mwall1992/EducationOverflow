using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class PopularSortState : NamedSortState<Int32> {

        private string API_SORT_NAME = "popular";

        public PopularSortState(Int32? min, Int32? max) : base(min, max) { }

        public override string Name {
            get {
                return API_SORT_NAME;
            }
        }
    }
}

