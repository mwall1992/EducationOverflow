using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Abstract Builder

    public abstract class StackExchangeAPIQueryBuilder<T, V> 
    where T : class 
    where V : StackExchangeAPIQueryBuilder<T, V> {
        
        protected static string BASE_QUERY_URL = "http://api.stackexchange.com";

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

        public V SetSite(string siteParameter) {
            this.siteParameter = HttpUtility.UrlEncode(siteParameter);
            return (V)this;
        }

        public V SetAPIVersion(string apiVersion) {
            if (apiVersion == null) {
                throw new ArgumentNullException("The api version cannot be null.");
            }
            
            this.apiVersion = HttpUtility.UrlEncode(apiVersion);
            return (V)this;
        }

        public V SetAPIMethod(string apiMethod) {
            this.apiMethod = apiMethod;
            return (V)this;
        }

        public V SetFilter(string filter) {
            this.filter = filter;
            return (V)this;
        }

        protected string GetFilterString() {
            return string.Format("filter={0}&", this.filter);
        }

        protected string GetBaseQueryURL() {
            if (apiVersion == null && apiMethod == null) {
                throw new ArgumentException("Missing Arguments: All Stack Exchange API queries" 
                    + "must specify an API version and an API method.");
            }

            return string.Format("{0}/{1}/", BASE_QUERY_URL, this.apiVersion);
        }
    }
}
