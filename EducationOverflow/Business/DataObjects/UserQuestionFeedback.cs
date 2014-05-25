using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on question feedback from specific users.
    /// </summary>
    /// <remarks>
    /// This class is used in the Feedback.aspx page.
    /// </remarks>
    [DataObject]
    public class UserQuestionFeedback {

        // <summary>
        // The table adapter used for user question feedback.
        // </summary>
        private static UserQuestionFeedbackTableAdapter feedbackTableAdapter = 
            new UserQuestionFeedbackTableAdapter();

        // <summary>
        // Retrieve feedback for questions from a given user.
        // </summary>
        // <param name="questionId">The user id.</param>
        // <returns>A table containing information on feedback from a specific user.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserQuestionFeedbackDataTable SelectUserQuestionFeedback(long userId) {
            return feedbackTableAdapter.GetData(userId);
        }

        /// <summary>
        /// Insert feedback for questions from a given user.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="liked">Denotes if the user liked (true) or disliked (false) the question.</param>
        /// <param name="summaryAdjective">The user's summary adjective for the question.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertUserQuestionFeedback(long questionId, long userId, bool liked,
                string summaryAdjective) {
            return Business.QuestionFeedback.InsertQuestionFeedback(questionId, userId, liked, summaryAdjective);
        }

        /// <summary>
        /// Update a user's feedback for a specific question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="liked">Denotes if the user liked (true) or disliked (false) the question.</param>
        /// <param name="summaryAdjective">The user's summary adjective for the question.</param>
        /// <param name="originalQuestionId">The original question id.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserQuestionFeedback(long questionId, long userId, bool liked,
                string summaryAdjective, long originalQuestionId, long originalUserId) {
            return Business.QuestionFeedback.UpdateQuestionFeedback(questionId, userId, liked, summaryAdjective, originalQuestionId, originalUserId);
        }

        /// <summary>
        /// Delete a user's feedback for a given question.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="originalQuestionId">The original question id.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteUserQuestionFeedback(long userId, long originalQuestionId) {
            return Business.QuestionFeedback.DeleteQuestionFeedback(originalQuestionId, userId);
        }
    }
}
