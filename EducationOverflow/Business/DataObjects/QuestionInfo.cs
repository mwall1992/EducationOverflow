using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on question information.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the Stack Exchange API classes for retrieving information
    /// from the Stack Exchange API servers.
    /// </remarks>
    [DataObject]
    public class QuestionInfo {

        /// <summary>
        /// The table adapter used for question information.
        /// </summary>
        private static QuestionInfoTableAdapter questionInfoTableAdapter = 
            new QuestionInfoTableAdapter();

        /// <summary>
        /// Retrieve all question information.
        /// </summary>
        /// <returns>A data table of all question information.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionInfoDataTable SelectQuestionInfo() {
            return questionInfoTableAdapter.GetData();
        }

        // TODO: redo data set - table adapter.

        /// <summary>
        /// Insert information for question.
        /// </summary>
        /// <param name="body"></param>
        /// <param name="upVotes"></param>
        /// <param name="downVotes"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertQuestionInfo(string body, int upVotes, int downVotes) {
            return questionInfoTableAdapter.Insert(body, upVotes, downVotes);
        }

        /// <summary>
        /// Update information for a question.
        /// </summary>
        /// <param name="body">The body of a question (including HTML tags).</param>
        /// <param name="upVotes">The number of up votes the question has (on Stack Exchange).</param>
        /// <param name="downVotes">The number of down votes the question has (on Stack Exchange).</param>
        /// <param name="questionId">The id for the question.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateQuestionInfo(string body, int upVotes, int downVotes, long questionId) {
            return questionInfoTableAdapter.Update(body, upVotes, downVotes, questionId);
        }

        /// <summary>
        /// Delete information for a question.
        /// </summary>
        /// <param name="questionId">The id for the question.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteQuestionInfo(long questionId) {
            return questionInfoTableAdapter.Delete(questionId);
        }
    }
}
