using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class QuestionFeedbackDetails {
        
        private static QuestionFeedbackDetailsTableAdapter questionFeedbackDetailsTableAdapter = 
            new QuestionFeedbackDetailsTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionFeedbackDetailsRow SelectQuestionFeedbackDetails(long userId, long questionId) {
            return (Data.EducationOverflow.QuestionFeedbackDetailsRow)questionFeedbackDetailsTableAdapter.GetData(questionId, userId).Rows[0];
        }
    }
}
