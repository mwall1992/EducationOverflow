using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace StackExchangeAPI {

    [DataContract]
    public class Tag {

        [DataMember]
        public String name;

        [DataMember]
        public int count;
    }
}
