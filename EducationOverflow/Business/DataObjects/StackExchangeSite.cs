using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on tags associated with Stack Exchange sites.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the Stack Exchange API classes for retrieving information
    /// from the Stack Exchange API servers.
    /// </remarks>
    [DataObject]
    public class StackExchangeSite {

        /// <summary>
        /// The table adapter used for Stack Exchange site information.
        /// </summary>
        private static StackExchangeSiteTableAdapter siteTableAdapter = new StackExchangeSiteTableAdapter();

        /// <summary>
        /// Retrieve all the Stack Exchange sites.
        /// </summary>
        /// <returns>A table containing information on all the Stack Exchange sites.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.StackExchangeSiteDataTable SelectStackExchangeSites() {
            return siteTableAdapter.GetData();
        }

        /// <summary>
        /// Insert a Stack Exchange site.
        /// </summary>
        /// <param name="apiSiteParameter">The id assigned to the site by the Stack Exchange API.</param>
        /// <param name="name">The name of the Stack Exchange Site.</param>
        /// <param name="totalAcceptedAnswers">The total number of accepted answers on the Stack Exchange Site.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertStackExchangeSite(string apiSiteParameter, string name, int totalAcceptedAnswers) {
            return siteTableAdapter.Insert(apiSiteParameter, name, totalAcceptedAnswers);
        }

        /// <summary>
        /// Update a Stack Exchange site.
        /// </summary>
        /// <param name="apiSiteParameter">The id assigned to the site by the Stack Exchange API.</param>
        /// <param name="name">The name of the Stack Exchange Site.</param>
        /// <param name="totalAcceptedAnswers">The total number of accepted answers on the Stack Exchange Site.</param>
        /// <param name="originalAPISiteParameter">The original id assigned to the site by the Stack Exchange API.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUser(string apiSiteParameter, string name, int totalAcceptedAnswers, 
                string originalAPISiteParameter) {
            return siteTableAdapter.Update(apiSiteParameter, name, totalAcceptedAnswers, originalAPISiteParameter);
        }

        /// <summary>
        /// Delete a Stack Exchange site.
        /// </summary>
        /// <param name="originalAPISiteParameter">The original id assigned to the site by the Stack Exchange API.</param>
        /// <returns>The number of rows affected by the deletion.</param>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteUser(string originalAPISiteParameter) {
            return siteTableAdapter.Delete(originalAPISiteParameter);
        }
    }
}
