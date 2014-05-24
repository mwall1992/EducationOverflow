using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class QuestionAnswerInfo {

        private static QuestionAnswerInfoTableAdapter questionAnswerTableAdapter = 
            new QuestionAnswerInfoTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionAnswerInfoRow SelectQuestionAnswerInfo(long questionId) {
            return (Data.EducationOverflow.QuestionAnswerInfoRow)questionAnswerTableAdapter.GetData(questionId).Rows[0];
        }
    }
}
