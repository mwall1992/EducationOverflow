using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations for reasons for 
    /// reporting on a question.
    /// </summary>
    [DataObject]
    public class ReportedQuestionReason {

        /// <summary>
        /// The table adapter used for reasons for reporting questions.
        /// </summary>
        private static ReportedQuestionReasonTableAdapter reportedQuestionReasonTableAdapter = 
            new ReportedQuestionReasonTableAdapter();

        /// <summary>
        /// Retrieve reasons for reporting a question.
        /// </summary>
        /// <returns>A table containing reasons for reporting a question.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.ReportedQuestionReasonDataTable SelectReportedQuestionReasons() {
            return reportedQuestionReasonTableAdapter.GetData();
        }
    }
}
