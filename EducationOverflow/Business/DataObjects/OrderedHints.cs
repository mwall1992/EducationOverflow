using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations on hints for questions.
    /// </summary>
    [DataObject]
    public class OrderedHints {

        /// <summary>
        /// The table adapter used for hints for questions.
        /// </summary>
        private static OrderedHintsTableAdapter hintsTableAdapter = 
            new OrderedHintsTableAdapter();

        /// <summary>
        /// Retrieve hints for a specific question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns>A table containing hints for the specified question.</returns>
        /// <remarks>The hints are ordered based on API Answer Id (from Stack Exchange).</remarks>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.OrderedHintsDataTable SelectOrderedHints(long questionId) {
            return hintsTableAdapter.GetData(questionId);
        }
    }
}
