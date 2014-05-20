using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class ReportedQuestionSummary {
        
        private static ReportedQuestionSummaryViewTableAdapter reportedQuestionSummaryTableAdapter = 
            new ReportedQuestionSummaryViewTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.ReportedQuestionSummaryViewDataTable SelectReportedQuestionSummaries() {
            return reportedQuestionSummaryTableAdapter.GetData();
        }
    }
}
