using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations on summarised question information.
    /// </summary>
    [DataObject]
    public class QuestionSummary {

        /// <summary>
        /// The table adapter used for summarised question information.
        /// </summary>
        private static QuestionSummaryViewTableAdapter questionsTableAdapter =
            new QuestionSummaryViewTableAdapter();

        /// <summary>
        /// Retrieve summary information for all questions.
        /// </summary>
        /// <returns>A table containing summary information on all questions.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionSummaryViewDataTable SelectQuestionSummaries() {
            return questionsTableAdapter.GetData();
        }
    }
}
