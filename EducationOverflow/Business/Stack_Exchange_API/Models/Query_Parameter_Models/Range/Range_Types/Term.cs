using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class Term : RangeType<string> {

        public static string UNSPECIFIED_TERM = "";

        public Term() : base(UNSPECIFIED_TERM) {}

        public Term(string term) : base(term) {}

        public override bool IsUnspecifiedBound() {
            return (this.value == UNSPECIFIED_TERM);
        }
    }
}
