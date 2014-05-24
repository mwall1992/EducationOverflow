using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations for question reports for a specific user.
    /// </summary>
    [DataObject]
    public class UserReportedQuestions {

        /// <summary>
        /// The table adapter used for user question reports.
        /// </summary>
        private static UserReportedQuestionsTableAdapter reportedQuestionsTableAdapter =
            new UserReportedQuestionsTableAdapter();

        /// <summary>
        /// Retrieve question reports for a specific user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>A table containing information on the question reports for the specified user.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserReportedQuestionsDataTable SelectQuestionsFromUserView(long userId) {
            return reportedQuestionsTableAdapter.GetData(userId);
        }
    }
}
