using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace StackExchangeAPI {

    [DataContract]
    public class ResponseWrapper<T> {

        [DataMember]
        public bool has_more;

        [DataMember]
        public List<T> items;
    }
}
