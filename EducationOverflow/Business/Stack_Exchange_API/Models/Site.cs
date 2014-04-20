using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class Site {

        [DataMember]
        private String api_site_parameter = StackExchangeAPI.DEFAULT_STRING_VALUE;

        [DataMember]
        private String name = StackExchangeAPI.DEFAULT_STRING_VALUE;

        [DataMember]
        private String site_url = StackExchangeAPI.DEFAULT_STRING_VALUE;

        public String APISiteParameter {
            get {
                return this.api_site_parameter;
            }
        }

        public String Name {
            get {
                return this.name;
            }
        }

        public String URL {
            get {
                return this.site_url;
            }
        }
    }
}
