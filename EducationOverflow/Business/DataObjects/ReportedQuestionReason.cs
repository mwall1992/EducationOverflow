using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class ReportedQuestionReason {
        
        private static ReportedQuestionReasonTableAdapter reportedQuestionReasonTableAdapter = 
            new ReportedQuestionReasonTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.ReportedQuestionReasonDataTable SelectReportedQuestionReasons() {
            return reportedQuestionReasonTableAdapter.GetData();
        }
    }
}
