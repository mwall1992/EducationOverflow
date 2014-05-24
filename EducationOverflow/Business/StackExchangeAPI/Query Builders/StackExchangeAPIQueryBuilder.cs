using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StackExchangeAPI {

    /// <summary>
    /// An abstract builder for queries to the Stack Exchange servers. This class
    /// has a fluent interface.
    /// </summary>
    /// <typeparam name="T">The model class used for storing response data to the query.</typeparam>
    /// <typeparam name="V">The class.</typeparam>
    /// <remarks>
    /// The 'V' generic parameter is required for a fluent interface to ensure subclasses
    /// return their own class type.
    /// </remarks>
    public abstract class StackExchangeAPIQueryBuilder<T, V> 
    where T : class 
    where V : StackExchangeAPIQueryBuilder<T, V> {

        public static int MAX_PARAMETER_COUNT = 100;

        private static string BASE_QUERY_URL = "http://api.stackexchange.com";

        /// <summary>
        /// The API version.
        /// </summary>
        private string apiVersion;

        /// <summary>
        /// The API method.
        /// </summary>
        private string apiMethod;

        /// <summary>
        /// The API method extension.
        /// </summary>
        private string apiMethodExtension;

        /// <summary>
        /// The parameter values of the API method.
        /// </summary>
        private List<String> parameterValues;

        /// <summary>
        /// The filter applied to the query.
        /// </summary>
        private string filter;

        /// <summary>
        /// Get the API method of the query.
        /// </summary>
        public string ApiMethod { 
            get {
                return this.apiMethod;
            }
        }

        /// <summary>
        /// Get the API method extension of the query.
        /// </summary>
        public string ApiMethodExtension {
            get {
                return this.apiMethodExtension;
            }
        }

        /// <summary>
        /// Get the filter applied to the query.
        /// </summary>
        public string Filter {
            get {
                return this.filter;
            }
        }

        /// <summary>
        /// Reset the state of the query builder.
        /// </summary>
        public virtual void Reset() {
            this.apiVersion = null;
            this.apiMethod = null;
            this.apiMethodExtension = null;
            this.filter = null;
            this.parameterValues = null;
        }

        /// <summary>
        /// Build the query.
        /// </summary>
        /// <returns>The query.</returns>
        public abstract IQuery<T> GetQuery();

        /// <summary>
        /// Set the API version of the query.
        /// </summary>
        /// <param name="apiVersion">The API version.</param>
        /// <returns>The updated query builder.</returns>
        public V SetAPIVersion(string apiVersion) {
            if (apiVersion == null) {
                throw new ArgumentNullException("The api version cannot be null.");
            }
            
            this.apiVersion = HttpUtility.UrlEncode(apiVersion);
            return (V)this;
        }

        /// <summary>
        /// Set the API method of the query.
        /// </summary>
        /// <param name="apiMethod">The API method.</param>
        /// <returns>The updated query builder.</returns>
        public V SetAPIMethod(string apiMethod) {
            this.apiMethod = apiMethod;
            return (V)this;
        }

        /// <summary>
        /// Set the API method extension of the query.
        /// </summary>
        /// <param name="methodExtension">The API method extension.</param>
        /// <returns>The updated query builder.</returns>
        public V SetApiMethodExtension(string methodExtension) {
            this.apiMethodExtension = HttpUtility.UrlEncode(methodExtension);
            return (V)this;
        }

        /// <summary>
        /// Set the parameter values of the API method of the query.
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns>The updated query builder.</returns>
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

        /// <summary>
        /// Set the filter of the query.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The updated query builder.</returns>
        public V SetFilter(string filter) {
            this.filter = filter;
            return (V)this;
        }

        /// <summary>
        /// Generate the url for the query.
        /// </summary>
        /// <returns>The base url for the query.</returns>
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

        /// <summary>
        /// Generate the full API method of the query.
        /// </summary>
        /// <returns>
        /// The full API method (includes api method, parameters, and extension) of the query.
        /// </returns>
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
