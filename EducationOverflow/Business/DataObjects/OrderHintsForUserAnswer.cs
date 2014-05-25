using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations on hints used in answering a question.
    /// </summary>
    [DataObject]
    public class OrderHintsForUserAnswer {

        /// <summary>
        /// The table adapter used for retrieving hints for taken by users in answering questions.
        /// </summary>
        private static OrderHintsForUserAnswerTableAdapter hintsTableAdapter = 
            new OrderHintsForUserAnswerTableAdapter();
    
        /// <summary>
        /// Retrieve all the used hints a user has taken in answering a question.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="userAnswerId">The user answer id.</param>
        /// <returns>A table containing all the hints taken by a user in answering a specific question.</returns>
        /// <remarks>The hints are ordered based on API Answer Id (from Stack Exchange).</remarks>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.OrderHintsForUserAnswerDataTable SelectHintsForUserAnswer(
                long userId, long userAnswerId) {
            return hintsTableAdapter.GetData(userAnswerId, userId);
        }
    }
}
