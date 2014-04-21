using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Abstract Builder

    public abstract class StackExchangeSiteAPIQueryBuilder<T> {
        
        protected string siteParameter;

        protected string apiVersion;

        protected string apiMethod;

        protected string filter;

        public abstract List<T> GetResponse();

        public virtual void Reset() {
            this.siteParameter = null;
            this.apiVersion = null;
            this.apiMethod = null;
            this.filter = null;
        }

        public StackExchangeSiteAPIQueryBuilder<T> SetSite(string siteParameter) {
            this.siteParameter = siteParameter;
            return this;
        }

        public StackExchangeSiteAPIQueryBuilder<T> SetAPIVersion(string apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }

        public StackExchangeSiteAPIQueryBuilder<T> SetFilter(string filter) {
            this.filter = filter;
            return this;
        }
    }
}
