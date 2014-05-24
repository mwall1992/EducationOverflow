using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on tags associated with reported questions.
    /// </summary>
    [DataObject]
    public class ReportedQuestion {

        /// <summary>
        /// The table adapter used for question reports.
        /// </summary>
        private static ReportedQuestionTableAdapter reportedQuestionTableAdapter = 
            new ReportedQuestionTableAdapter();

        /// <summary>
        /// Retrieve all reported questions.
        /// </summary>
        /// <returns>A table containing information on every reported questions.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.ReportedQuestionDataTable SelectReportedQuestion() {
            return reportedQuestionTableAdapter.GetData();
        }

        /// <summary>
        /// Insert a question report for a user.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="reasonId">The reason id.</param>
        /// <param name="description">The report description.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertReportedQuestion(long questionId, long userId, int reasonId, string description) {
            return reportedQuestionTableAdapter.Insert(questionId, userId, reasonId, description);
        }

        /// <summary>
        /// Update a question report for a user.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="reasonId">The reason id.</param>
        /// <param name="description">The report description.</param>
        /// <param name="originalQuestionId">The original question id.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateReportedQuestion(long questionId, long userId, int reasonId, string description,
                long originalQuestionId, long originalUserId) {
            return reportedQuestionTableAdapter.Update(questionId, userId, reasonId, description, 
                originalQuestionId, originalUserId);
        }

        /// <summary>
        /// Delete a question report for a user.
        /// </summary>
        /// <param name="originalQuestionId">The original question id.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteReportedQuestion(long originalQuestionId, long originalUserId) {
            return reportedQuestionTableAdapter.Delete(originalQuestionId, originalUserId);
        }
    }
}
