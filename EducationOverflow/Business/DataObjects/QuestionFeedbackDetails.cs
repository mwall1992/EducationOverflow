using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations for question feedback details from users.
    /// </summary>
    [DataObject]
    public class QuestionFeedbackDetails {

        /// <summary>
        /// The table adapter used for the details of question feedback.
        /// </summary>
        private static QuestionFeedbackDetailsTableAdapter questionFeedbackDetailsTableAdapter = 
            new QuestionFeedbackDetailsTableAdapter();

        /// <summary>
        /// Retrieve question feedback from a user for a specific question.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="questionId">The question id.</param>
        /// <returns>A row containing information on the user's feedback on the question.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionFeedbackDetailsRow SelectQuestionFeedbackDetails(
                long userId, long questionId) {
            Data.EducationOverflow.QuestionFeedbackDetailsDataTable feedbackDataTable =
                questionFeedbackDetailsTableAdapter.GetData(questionId, userId);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.QuestionFeedbackDetailsRow>(feedbackDataTable);
        }

        /// <summary>
        /// Delete question feedback.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="questionId">The question id.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        /// <remarks>
        /// This method is included to allow admins to delete question feedback.
        /// </remarks>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteQuestionFeedback(long userId, long questionId) {
            return QuestionFeedback.DeleteQuestionFeedback(questionId, userId);
        }
    }
}
