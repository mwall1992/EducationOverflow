using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Abstract Builder

    public abstract class StackExchangeAPIQueryBuilder {
        
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

        public StackExchangeAPIQueryBuilder SetSite(string siteParameter) {
            this.siteParameter = siteParameter;
            return this;
        }

        public StackExchangeAPIQueryBuilder SetAPIVersion(string apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }

        public StackExchangeAPIQueryBuilder SetFilter(string filter) {
            this.filter = filter;
            return this;
        }

        public abstract StackExchangeAPIQuery GetQuery();
    }
}
