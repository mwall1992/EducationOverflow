using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class UserAnswerToQuestion {
        
        private static UserAnswerToQuestionTableAdapter answerTableAdapter = 
            new UserAnswerToQuestionTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserAnswerToQuestionRow SelectUserAnswerToQuestion(
                long userId, long userAnswerId) {
            Data.EducationOverflow.UserAnswerToQuestionDataTable answerTable = answerTableAdapter.GetData(userAnswerId, userId);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.UserAnswerToQuestionRow>(answerTable);
        }
    }
}
