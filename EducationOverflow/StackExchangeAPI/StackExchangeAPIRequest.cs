using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {
    public class StackExchangeAPIRequest {

        private String method;

        private String parameterPairs;

        private String siteParameter;

        public String Method {
            get {
                return this.method;
            }

            set {
                this.method = value;
            }
        }

        public String ParameterPairs {
            get {
                return this.parameterPairs;
            }

            set {
                this.parameterPairs = value;
            }
        }

        public String SiteParameter {
            get {
                return this.siteParameter;
            }

            set {
                this.siteParameter = value;
            }
        }

    }
}
