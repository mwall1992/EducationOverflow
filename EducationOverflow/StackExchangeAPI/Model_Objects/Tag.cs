using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class Tag {

        [DataMember]
        private String name = StackExchangeAPI.DEFAULT_STRING_VALUE;

        [DataMember]
        private int count = StackExchangeAPI.DEFAULT_INT_VALUE;

        public String Name {
            get {
                return this.name;
            }
        }

        public int Count {
            get {
                return this.count;
            }
        }
    }
}
