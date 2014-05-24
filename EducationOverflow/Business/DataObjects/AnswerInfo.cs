using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations on answer information (for user consumption).
    /// </summary>
    [DataObject]
    public class AnswerInfo {

        /// <summary>
        /// The table adapter used for answer information for a specific question.
        /// </summary>
        private static QuestionAnswerInfoTableAdapter questionAnswerTableAdapter =
            new QuestionAnswerInfoTableAdapter();

        /// <summary>
        /// Retrieve answer information for a specific question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns>A row containing information on the answer.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionAnswerInfoRow SelectAnswerInfo(long questionId) {
            Data.EducationOverflow.QuestionAnswerInfoDataTable answerInfoTable =
                questionAnswerTableAdapter.GetData(questionId);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.QuestionAnswerInfoRow>(answerInfoTable);
        }
    }
}
