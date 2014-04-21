using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {
    
    public class Number : RangeType<Int32> {

        public static Int32 UNSPECIFIED_NUMBER = -1;

        public Number() : base(UNSPECIFIED_NUMBER) { }

        public Number(Int32 number) : base(number) { }

        public override bool IsUnspecifiedBound() {
            return (this.value == UNSPECIFIED_NUMBER);
        }
    }
}
