﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class StackExchangeAPIRequestInfo {

        private static String DEFAULT_API_METHOD = "";

        /// <summary>
        /// The base URL for all requests to the Stack Exchange API.
        /// </summary>
        private static String baseURL = "http://api.stackexchange.com";

        /// <summary>
        /// The Stack Exchange API version used.
        /// </summary>
        private static String APIVersion = "2.2";

        /// <summary>
        /// The API method used as specified by the Stack Exchange API documentation.
        /// </summary>
        /// <example>
        /// Every API method string begins with a "/". To query for all the
        /// answers on a Stack Exchange site, for example, the API method string 
        /// would be "/answers".
        /// </example>
        /// <remarks>
        /// The Stack Exchange API defines each of its methods as a string which is
        /// included as part of the URL defining the request to the API servers. For a
        /// list of all the available methods, see the Stack Exchange API documentation
        /// at http://api.stackexchange.com/docs
        /// </remarks>
        private String apiMethod;

        /// <summary>
        /// A collection of key-value pair mappings included as parameters to a query 
        /// sent to the Stack Exchange API servers.
        /// </summary>
        /// <remarks>
        /// The methods of the Stack Exchange API are categorised as either per-site methods
        /// or network methods. All per-site methods require an api site parameter, which 
        /// uniquely identifies the Stack Exchange site being queried. For more information
        /// and a listing of the api site parameters, see the Stack Exchange API documentation
        /// at http://api.stackexchange.com/docs
        /// </remarks>
        private Dictionary<String, String> parameters;

        // properties

        public String APIMethod {
            get {
                return this.apiMethod;
            }

            set {
                this.apiMethod = value;
            }
        }

        public Dictionary<String, String> Parameters {
            get {
                return this.parameters;
            }
        }

        // methods

        public StackExchangeAPIRequestInfo() {
            this.apiMethod = DEFAULT_API_METHOD;
            this.parameters = new Dictionary<String, String>();
        }

        public StackExchangeAPIRequestInfo(String apiMethod) {
            this.apiMethod = apiMethod;
            this.parameters = new Dictionary<String, String>();
        }

        public StackExchangeAPIRequestInfo(String apiMethod, 
                Dictionary<String, String> parameters) {
            this.apiMethod = apiMethod;
            this.parameters = parameters;
        }

        public override String ToString() {
            return String.Format("{0}/{1}/{2}?{3}", baseURL, APIVersion, 
                                    this.apiMethod, this.ParametersToString());
        }

        public String ToURL() {
            return this.ToString();
        }

        // helper methods

        private String ParametersToString() {
            const int INDEX_DELTA = 1;
            const int MIN_PARAMETER_COUNT = 0;
            String parameterString = "";

            // append parameters as key-value pairs for a HTTP GET request URL
            foreach (KeyValuePair<String, String> parameterPair in this.parameters) {
                parameterString += String.Format("{0}={1}&", parameterPair.Key, parameterPair.Value);
            }

            // remove trailing ampersand
            if (this.parameters.Count > MIN_PARAMETER_COUNT) {
                parameterString = parameterString.Remove(parameterString.Length - INDEX_DELTA);
            }

            return parameterString;
        }
    }
}
