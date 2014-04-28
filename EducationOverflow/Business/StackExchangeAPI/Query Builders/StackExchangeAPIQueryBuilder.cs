using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Abstract Builder

    public abstract class StackExchangeAPIQueryBuilder<T> where T : class {
        
        protected static string BASE_QUERY_URL = "http://http://api.stackexchange.com";

        protected string siteParameter;

        protected string apiVersion;

        protected string apiMethod;

        protected string filter;

        public virtual void Reset() {
            this.siteParameter = null;
            this.apiVersion = null;
            this.apiMethod = null;
            this.filter = null;
        }

        public abstract IQuery<T> GetQuery();

        public StackExchangeAPIQueryBuilder<T> SetSite(string siteParameter) {
            this.siteParameter = siteParameter;
            return this;
        }

        public StackExchangeAPIQueryBuilder<T> SetAPIVersion(string apiVersion) {
            if (apiVersion == null) {
                throw new ArgumentNullException("The api version cannot be null.");
            }
            
            this.apiVersion = apiVersion;
            return this;
        }

        public StackExchangeAPIQueryBuilder<T> SetFilter(string filter) {
            this.filter = filter;
            return this;
        }

        protected string GetBaseQueryURL() {
            if (apiVersion == null && apiMethod == null) {
                throw new ArgumentException("Missing Arguments: All Stack Exchange API queries" 
                    + "must specify an API version and an API method.");
            }

            return string.Format("{0}/{1}/{2}/", BASE_QUERY_URL, this.apiVersion, this.apiMethod);
        }
    }
}
