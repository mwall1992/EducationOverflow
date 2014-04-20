using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class SiteInfo {

        [DataMember]
        private Site site = (Site)StackExchangeAPI.DEFAULT_OBJ_VALUE;

        [DataMember]
        private int total_accepted = StackExchangeAPI.DEFAULT_INT_VALUE;

        public Site Site {
            get {
                return this.site;
            }
        }

        public int TotalAcceptedQuestions {
            get {
                return this.total_accepted;
            }
        }
    }
}
