using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations for adjectives used to 
    /// summarise questions.
    /// </summary>
    [DataObject]
    public class QuestionSummaryAdjective {

        /// <summary>
        /// The table adapter used for retrieving summary adjectives.
        /// </summary>
        private static QuestionSummaryAdjectiveTableAdapter adjectiveTableAdapter = 
            new QuestionSummaryAdjectiveTableAdapter();

        /// <summary>
        /// Retrieve all summary adjectives for describing a question.
        /// </summary>
        /// <returns>A table containing all the summary adjectives.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionSummaryAdjectiveDataTable SelectSummaryAdjectives() {
            return adjectiveTableAdapter.GetData();
        }
    }
}
