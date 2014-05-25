using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class UserQuestionFeedback {

        /// <summary>
        /// The table adapter used for answers.
        /// </summary>
        private static UserQuestionFeedbackTableAdapter feedbackTableAdapter = 
            new UserQuestionFeedbackTableAdapter();

        /// <summary>
        /// Retrieve answers associated with a question.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        /// <returns>A table of answers associated with the question identifier.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserQuestionFeedbackDataTable SelectUserQuestionFeedback(long userId) {
            return feedbackTableAdapter.GetData(userId);
        }

        /// <summary>
        /// Insert an answer for a specific question.
        /// </summary>
        /// <param name="apiAnswerId">The identifier assigned to the answer by the Stack Exchange API.</param>
        /// <param name="body">The body of the question (including html tags).</param>
        /// <param name="upVotes">The number of up votes the answer received via Stack Exchange.</param>
        /// <param name="downVotes">The number of down votes the answer received via Stack Exchange.</param>
        /// <param name="isAccepted">Denotes whether the answer is accepted or not.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertUserQuestionFeedback(long questionId, long userId, bool liked,
                string summaryAdjective) {
            return feedbackTableAdapter.Insert(questionId, userId, liked, summaryAdjective);
        }

        /// <summary>
        /// Update an answer for a specific question
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="apiAnswerId">The identifier assigned to the answer by the Stack Exchange API.</param>
        /// <param name="body">The body of the question (including html tags).</param>
        /// <param name="upVotes">The number of up votes the answer received via Stack Exchange.</param>
        /// <param name="downVotes">The number of down votes the answer received via Stack Exchange.</param>
        /// <param name="isAccepted">Denotes whether the answer is accepted or not.</param>
        /// <param name="originalQuestionId">
        /// The question id of the question originally associated with the answer.
        /// </param>
        /// <param name="originalApiAnswerId">
        /// The id originally associated with the answer as provided by the Stack Exchange API.
        /// </param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserQuestionFeedback(long questionId, long userId, bool liked,
                string summaryAdjective, long originalQuestionId, long originalUserId) {
            return feedbackTableAdapter.Update(questionId, userId, liked, summaryAdjective, 
                originalQuestionId, originalUserId);
        }

        /// <summary>
        /// Delete an answer for a specific question.
        /// </summary>
        /// <param name="originalQuestionId">
        /// The question id of the question originally associated with the answer.
        /// </param>
        /// <param name="originalApiAnswerId">
        /// The id originally associated with the answer as provided by the Stack Exchange API.
        /// </param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteUserQuestionFeedback(long originalQuestionId, long originalUserId) {
            return feedbackTableAdapter.Delete(originalQuestionId, originalUserId);
        }
    }
}
