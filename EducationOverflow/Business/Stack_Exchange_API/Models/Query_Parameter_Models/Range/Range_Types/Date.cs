using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class Date : RangeType<Int64> {
        
        public enum Ordering {
            ASCENDING = 0,
            DESCENDING
        }

        public static Int64 UNSPECIFIED_DATE = -1;

        public Date() : base(UNSPECIFIED_DATE) {}

        public Date(Int64 date) : base(date) {}

        public override bool IsUnspecifiedBound() {
            return (this.value == UNSPECIFIED_DATE);
        }
    }
}
