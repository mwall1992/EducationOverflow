using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations for summaries of question reports.
    /// </summary>
    [DataObject]
    public class ReportedQuestionSummary {

        /// <summary>
        /// The table adapter used for summary information of question reports.
        /// </summary>
        private static ReportedQuestionSummaryViewTableAdapter reportedQuestionSummaryTableAdapter = 
            new ReportedQuestionSummaryViewTableAdapter();

        /// <summary>
        /// Retrieve summaries for all question reports.
        /// </summary>
        /// <returns>A table containing summary data for all question reports.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.ReportedQuestionSummaryViewDataTable SelectReportedQuestionSummaries() {
            return reportedQuestionSummaryTableAdapter.GetData();
        }
    }
}
