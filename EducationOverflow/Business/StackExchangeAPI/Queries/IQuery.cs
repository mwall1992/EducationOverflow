using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// An interface for queries to generic web resources.
    /// </summary>
    /// <typeparam name="T">The model class used for storing response data to the query.</typeparam>
    public interface IQuery<T> where T : class {

        /// <summary>
        /// Get the URL the query will be sent to.
        /// </summary>
        /// <returns>The URL the query will be sent to.</returns>
        string GetURL();
    }
}
