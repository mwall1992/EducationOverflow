using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class QuestionHint {
        
        private static HintForQuestionTableAdapter questionHintTableAdapter = 
            new HintForQuestionTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.HintForQuestionRow SelectHintForQuestion(long questionId, long[] ignoredAPIAnswerIds) {

            Data.EducationOverflow.ApiAnswerIdsDataTable apiAnswerIdsTable =
                new Data.EducationOverflow.ApiAnswerIdsDataTable();
            foreach (long id in ignoredAPIAnswerIds) {
                apiAnswerIdsTable.AddApiAnswerIdsRow(id);
            }

            Data.EducationOverflow.HintForQuestionDataTable dataTable = questionHintTableAdapter.GetData(apiAnswerIdsTable, questionId);

            Data.EducationOverflow.HintForQuestionRow row = null;
            if (dataTable.Rows.Count != 0) {
                row = (Data.EducationOverflow.HintForQuestionRow)dataTable.Rows[0];
            }

            return row;
        }
    }
}
