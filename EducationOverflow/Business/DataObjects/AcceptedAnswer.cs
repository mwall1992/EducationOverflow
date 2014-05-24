using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations on accepted answers 
    /// sourced from Stack Exchange.
    /// </summary>
    [DataObject]
    public class AcceptedAnswer {

        /// <summary>
        /// The table adapter for accepted answers.
        /// </summary>
        private static AcceptedAnswerTableAdapter acceptedAnswerTableAdapter = 
            new AcceptedAnswerTableAdapter();

        /// <summary>
        /// Retrieve the accepted answer for question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns>A row containing information on the accepted answer.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.AcceptedAnswerRow SelectAcceptedAnswer(long questionId) {
            Data.EducationOverflow.AcceptedAnswerDataTable answerDataTable = 
                acceptedAnswerTableAdapter.GetData(questionId);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.AcceptedAnswerRow>(answerDataTable);
        }
    }
}
