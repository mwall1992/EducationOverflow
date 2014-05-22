using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class ReportedQuestion {
        
        private static ReportedQuestionTableAdapter reportedQuestionTableAdapter = 
            new ReportedQuestionTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.ReportedQuestionDataTable SelectReportedQuestion() {
            return reportedQuestionTableAdapter.GetData();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertReportedQuestion(long questionId, long userId, int reasonId, string description) {
            return reportedQuestionTableAdapter.Insert(questionId, userId, reasonId, description);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateReportedQuestion(long questionId, long userId, int reasonId, string description,
                long originalQuestionId, long originalUserId) {
            return reportedQuestionTableAdapter.Update(questionId, userId, reasonId, description, 
                originalQuestionId, originalUserId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteReportedQuestion(long originalQuestionId, long originalUserId) {
            return reportedQuestionTableAdapter.Delete(originalQuestionId, originalUserId);
        }
    }
}
