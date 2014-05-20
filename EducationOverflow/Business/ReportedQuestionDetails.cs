using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class ReportedQuestionDetails {
        
        private static ReportedQuestionDetailsTableAdapter reportedQuestionDetailsTableAdapter = 
            new ReportedQuestionDetailsTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.ReportedQuestionDetailsRow SelectReportedQuestionDetails(long userId, long questionId) {
            return (Data.EducationOverflow.ReportedQuestionDetailsRow)reportedQuestionDetailsTableAdapter.GetData(userId, questionId).Rows[0];
        }
    }
}
