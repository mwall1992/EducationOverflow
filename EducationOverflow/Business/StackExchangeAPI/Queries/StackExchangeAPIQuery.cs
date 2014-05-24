using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// An interface for queries to the Stack Exchange API servers.
    /// </summary>
    /// <typeparam name="T">The model class used for storing response data to the query.</typeparam>
    public class StackExchangeAPIQuery<T> : IQuery<T> where T : class {
        
        private string queryUrl;

        /// <summary>
        /// Construct a query for the Stack Exchange API.
        /// </summary>
        /// <param name="queryUrl">The URL the query will be sent to.</param>
        public StackExchangeAPIQuery(string queryUrl) {
            this.queryUrl = queryUrl;
        }

        /// <summary>
        /// Get the URL for the query.
        /// </summary>
        /// <returns>The query URL.</returns>
        public string GetURL() {
            return this.queryUrl;
        }

        /// <summary>
        /// Set the URL for the query.
        /// </summary>
        /// <param name="url">The query URL.</param>
        public void SetURL(string url) {
            this.queryUrl = url;
        }
    }
}
