using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class QuestionFeedback {

        /// <summary>
        /// The table adapter used for question feedback.
        /// </summary>
        private static QuestionFeedbackTableAdapter questionFeedbackTableAdapter =
            new QuestionFeedbackTableAdapter();

        /// <summary>
        /// Retrieve all question feedback.
        /// </summary>
        /// <returns>A table containing information on all question feedback.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionFeedbackDataTable SelectQuestionFeedback() {
            return questionFeedbackTableAdapter.GetData();
        }

        /// <summary>
        /// Insert qustion feedback for a user.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="liked">Denotes if the user liked (true) or disliked (false) the question.</param>
        /// <param name="summaryAdjective">The summary adjective for the question.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertQuestionFeedback(long questionId, long userId, bool liked, string summaryAdjective) {
            return questionFeedbackTableAdapter.Insert(questionId, userId, liked, summaryAdjective);
        }

        /// <summary>
        /// Update question feedback for a user.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="userId">The user id.</param>
        /// <param name="liked">Denotes if the user liked (true) or disliked (false) the question.</param>
        /// <param name="summaryAdjective">The summary adjective for the question.</param>
        /// <param name="originalQuestionId">The original question id.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateQuestionFeedback(long questionId, long userId, bool liked, string summaryAdjective, 
                long originalQuestionId, long originalUserId) {
            return questionFeedbackTableAdapter.Update(questionId, userId, liked, summaryAdjective, 
                originalQuestionId, originalUserId);
        }

        /// <summary>
        /// Delete question feedback for a user.
        /// </summary>
        /// <param name="originalQuestionId">The original question id.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteQuestionFeedback(long originalQuestionId, long originalUserId) {
            return questionFeedbackTableAdapter.Delete(originalQuestionId, originalUserId);
        }
    }
}
