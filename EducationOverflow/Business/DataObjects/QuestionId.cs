using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on data associated with question identifiers.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the Stack Exchange API classes for retrieving information
    /// from the Stack Exchange API servers.
    /// </remarks>
    [DataObject]
    public class QuestionId {

        private static QuestionIdTableAdapter questionIdTableAdapter = 
            new QuestionIdTableAdapter();

        /// <summary>
        /// Retrieve identifying information for all questions.
        /// </summary>
        /// <returns>A table containing identifying information for every question.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionIdDataTable SelectQuestionId() {
            return questionIdTableAdapter.GetData();
        }

        /// <summary>
        /// Insert a question.
        /// </summary>
        /// <param name="apiQuestionId">The id associated with the question (provided by Stack Exchange).</param>
        /// <param name="apiSiteParameter">The site parameter associated with the question (provided by Stack Exchange).</param>
        /// <param name="title">The title of the question.</param>
        /// <param name="url">The URL of the question (via Stack Exchange).</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertQuestionId(int apiQuestionId, string apiSiteParameter, string title, string url) {
            return questionIdTableAdapter.Insert(apiQuestionId, apiSiteParameter, title, url);
        }

        /// <summary>
        /// Update a question.
        /// </summary>
        /// <param name="apiQuestionId">The id associated with the question (provided by Stack Exchange).</param>
        /// <param name="apiSiteParameter">The site parameter associated with the question (provided by Stack Exchange).</param>
        /// <param name="title">The title of the question.</param>
        /// <param name="url">The URL of the question (via Stack Exchange).</param>
        /// <param name="originalId">The original id for the question.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateQuestionId(int apiQuestionId, string apiSiteParameter, string title, string url,
                long originalId) {
            return questionIdTableAdapter.Update(apiQuestionId, apiSiteParameter, title, url, originalId);
        }

        /// <summary>
        /// Delete a question.
        /// </summary>
        /// <param name="originalId">The id of the question.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteQuestionId(long originalId) {
            return questionIdTableAdapter.Delete(originalId);
        }
    }
}
