using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class UserReportedQuestions {

        private static UserReportedQuestionsTableAdapter reportedQuestionsTableAdapter =
            new UserReportedQuestionsTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserReportedQuestionsDataTable SelectQuestionsFromUserView(long userId) {
            return reportedQuestionsTableAdapter.GetData(userId);
        }
    }
}
