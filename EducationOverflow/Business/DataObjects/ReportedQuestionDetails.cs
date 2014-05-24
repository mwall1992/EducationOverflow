using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations for details on question reports.
    /// </summary>
    [DataObject]
    public class ReportedQuestionDetails {

        /// <summary>
        /// The table adapter used for details of question reports.
        /// </summary>
        private static ReportedQuestionDetailsTableAdapter reportedQuestionDetailsTableAdapter = 
            new ReportedQuestionDetailsTableAdapter();

        /// <summary>
        /// Retrieve a user's question report for a specific question.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="questionId">The question id.</param>
        /// <returns>A row containing information on the user's question report.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.ReportedQuestionDetailsRow SelectReportedQuestionDetails(long userId, long questionId) {
            Data.EducationOverflow.ReportedQuestionDetailsDataTable reportedQuestionsTable =
                reportedQuestionDetailsTableAdapter.GetData(userId, questionId);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.ReportedQuestionDetailsRow>(reportedQuestionsTable);
        }
    }
}
