using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    /// <summary>
    /// The DataObject used for retrieving a user's answer to a question.
    /// </summary>
    [DataObject]
    public class UserAnswerToQuestion {
        
        /// <summary>
        /// The table adapter used to retrieve a user's answer to questions.
        /// </summary>
        private static UserAnswerToQuestionTableAdapter answerTableAdapter = 
            new UserAnswerToQuestionTableAdapter();

        /// <summary>
        /// Retrieve a user's answer to a specific question.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="userAnswerId">The identifier of the answer.</param>
        /// <returns>A row containing information on the user's answer.</returns>
        /// <remarks>The user id is used for verification purposes.</remarks>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserAnswerToQuestionRow SelectUserAnswerToQuestion(
                long userId, long userAnswerId) {
            Data.EducationOverflow.UserAnswerToQuestionDataTable answerTable = answerTableAdapter.GetData(userAnswerId, userId);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.UserAnswerToQuestionRow>(answerTable);
        }
    }
}
