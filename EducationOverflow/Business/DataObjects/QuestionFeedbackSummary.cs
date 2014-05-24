using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations for a summary of all question feedback.
    /// </summary>
    [DataObject]
    public class QuestionFeedbackSummary {

        /// <summary>
        /// The table adapter used for summary information for question feedback.
        /// </summary>
        private static QuestionFeedbackSummaryViewTableAdapter questionFeedbackTableAdapter = 
            new QuestionFeedbackSummaryViewTableAdapter();

        /// <summary>
        /// Retrieve all question feedback from users.
        /// </summary>
        /// <returns>A table containing information on question feedback from all users.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionFeedbackSummaryViewDataTable SelectQuestionFeedbackSummaries() {
            return questionFeedbackTableAdapter.GetData();
        }
    }
}
