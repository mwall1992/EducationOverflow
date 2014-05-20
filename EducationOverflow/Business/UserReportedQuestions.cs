using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    public class UserReportedQuestions {

        private static UserReportedQuestionsTableAdapter reportedQuestionsTableAdapter =
            new UserReportedQuestionsTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.ReportedQuestionInfo> SelectQuestionsFromUserView(int userId) {
            List<DataObjects.ReportedQuestionInfo> reportedQuestions = new List<DataObjects.ReportedQuestionInfo>();
            DataAccess.EducationOverflow.UserReportedQuestionsDataTable reportedQuestionsDataTable =
                reportedQuestionsTableAdapter.GetData(userId);

            foreach (DataAccess.EducationOverflow.UserReportedQuestionsRow row in reportedQuestionsDataTable.Rows) {
                reportedQuestions.Add(new DataObjects.ReportedQuestionInfo() {
                    OptionalDescription = row.OptionalDescription,
                    PredefinedDescription = row.PredefinedDescription,
                    Title = row.Title,
                    SiteName = row.Title,
                    QuestionId = row.Id
                });
            }

            return reportedQuestions;
        }
    }
}
