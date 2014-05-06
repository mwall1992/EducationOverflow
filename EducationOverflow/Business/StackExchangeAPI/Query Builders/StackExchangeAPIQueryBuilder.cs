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

        public static int MAX_PARAMETER_COUNT = 100;

        private static string BASE_QUERY_URL = "http://api.stackexchange.com";

        private string apiVersion;

        private string apiMethod;
        public string ApiMethod { 
            get {
                return this.apiMethod;
            }
        }

        private string apiMethodExtension;
        public string ApiMethodExtension {
            get {
                return this.apiMethodExtension;
            }
        }

        private List<String> parameterValues;

        private string filter;
        public string Filter {
            get {
                return this.filter;
            }
        }

        public virtual void Reset() {
            this.apiVersion = null;
            this.apiMethod = null;
            this.apiMethodExtension = null;
            this.filter = null;
            this.parameterValues = null;
        }

        public abstract IQuery<T> GetQuery();

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

        public V SetApiMethodExtension(string methodExtension) {
            this.apiMethodExtension = HttpUtility.UrlEncode(methodExtension);
            return (V)this;
        }

        public V SetMethodParameterValues(List<String> parameterValues) {
            if (parameterValues.Count > MAX_PARAMETER_COUNT) {
                throw new ArgumentException(
                    string.Format("The number of parameter values specified is {0}. "
                                    + "The maximum number of parameter values allowed is {1}.",
                                    parameterValues.Count, MAX_PARAMETER_COUNT)
                );
            }

            for (int i = 0; i < parameterValues.Count; i++) {
                parameterValues[i] = HttpUtility.UrlEncode(parameterValues[i]);
            }

            this.parameterValues = parameterValues;
            return (V)this;
        }

        public V SetFilter(string filter) {
            this.filter = filter;
            return (V)this;
        }

        protected virtual string GetBaseQueryUrl() {
            if (this.apiVersion == null || this.apiMethod == null) {
                throw new ArgumentException("Missing Arguments: All Stack Exchange API queries" 
                    + "must specify an API version and an API method.");
            }

            string queryUrl = string.Format("{0}/{1}/{2}?", BASE_QUERY_URL, this.apiVersion, this.GetApiMethod());

            if (this.filter != null) {
                queryUrl = string.Format("{0}filter={1}&", queryUrl, this.filter);
            }

            return queryUrl;
        }

        // helper methods 

        private string GetApiMethod() {
            if (this.ApiMethod == null) {
                throw new ArgumentNullException("The api method cannot be null.");
            }

            const string PARAMETER_DELIMITER = ";";
            string apiMethod = this.ApiMethod;

            // add parameters to the api method
            if (this.parameterValues != null && this.parameterValues.Count > 0) {

                apiMethod = apiMethod + "/";

                string methodParameter;
                for (int i = 0; i < this.parameterValues.Count; i++) {

                    // format parameter
                    methodParameter = this.parameterValues[i];
                    if (i < this.parameterValues.Count - 1) {
                        methodParameter = string.Concat(methodParameter, PARAMETER_DELIMITER);
                    }

                    // append parameter to api method string
                    apiMethod = apiMethod + methodParameter;
                }
            }

            // add any method name qualifiers to the method string
            if (this.ApiMethodExtension != null) {
                apiMethod = string.Format("{0}/{1}", apiMethod, this.ApiMethodExtension);
            }

            return apiMethod;
        }
    }
}
