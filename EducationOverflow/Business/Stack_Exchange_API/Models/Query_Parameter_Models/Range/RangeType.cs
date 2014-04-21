using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class RangeType<T> : IComparable<RangeType<T>>, IRangeType 
    where T : IComparable {
    
        protected T value;

        protected RangeType(T value) {
            this.value = value;
        }
        
        public static implicit operator RangeType<T>(T value) {
            return new RangeType<T>(value);
        }

        public static implicit operator T(RangeType<T> rangeType) {
            return rangeType.value;
        }

        public int CompareTo(RangeType<T> obj) {
            return this.value.CompareTo((T)obj);
        }

        public virtual bool IsUnspecifiedBound() {
            return false;
        }
    }
}
