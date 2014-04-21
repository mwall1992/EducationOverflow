using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class ResponseWrapper<T> {

        [DataMember]
        private bool has_more = StackExchangeAPI.DEFAULT_BOOL_VALUE;

        [DataMember]
        private List<T> items = (List<T>)StackExchangeAPI.DEFAULT_OBJ_VALUE;

        public bool HasMoreItems {
            get {
                return this.has_more;
            }
        }

        public List<T> Items {
            get {
                return this.items;
            }
        }
    }
}
