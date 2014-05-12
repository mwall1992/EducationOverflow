using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.UserReportedQuestionsTableAdapters;

namespace Business {
    
    public class UserReportedQuestions {

        private static UserReportedQuestionsSelectCommandTableAdapter reportedQuestionsTableAdapter = 
            new UserReportedQuestionsSelectCommandTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.ReportedQuestionInfo> SelectQuestionsFromUserView(int userId) {
            List<DataObjects.ReportedQuestionInfo> reportedQuestions = new List<DataObjects.ReportedQuestionInfo>();
            Data.UserReportedQuestions.UserReportedQuestionsSelectCommandDataTable reportedQuestionsDataTable =
                reportedQuestionsTableAdapter.GetData(userId);

            foreach (Data.UserReportedQuestions.UserReportedQuestionsSelectCommandRow row in reportedQuestionsDataTable.Rows) {
                reportedQuestions.Add(new DataObjects.ReportedQuestionInfo() {
                    OptionalDescription = row.OptionalDescription,
                    PredefinedDescription = row.PredefinedDescription,
                    Title = row.Title,
                    SiteName = row.Title,
                    Url = row.URL
                });
            }

            return reportedQuestions;
        }
    }
}
