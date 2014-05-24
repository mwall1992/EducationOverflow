using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on data associated with answers.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the Stack Exchange API classes for retrieving information
    /// from the Stack Exchange API servers.
    /// </remarks>
    [DataObject]
    public class Answer {

        private static AnswerTableAdapter answerTableAdapter = new AnswerTableAdapter();

        /// <summary>
        /// Retrieve answers associated with a question.
        /// </summary>
        /// <param name="questionId">The question identifier.</param>
        /// <returns>A table of answers associated with the question identifier.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.AnswerDataTable SelectAnswers(long questionId) {
            return answerTableAdapter.GetData(questionId);
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
        public static int InsertAnswer(long apiAnswerId, string body, int upVotes, 
                int downVotes, bool isAccepted) {
            return answerTableAdapter.Insert(apiAnswerId, body, upVotes, downVotes, isAccepted);
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
        public static int UpdateAnswer(long questionId, long apiAnswerId, string body, int upVotes, 
                int downVotes, bool isAccepted, long originalQuestionId, long originalApiAnswerId) {
            return answerTableAdapter.Update(apiAnswerId, body, upVotes, downVotes, isAccepted, 
                originalQuestionId, originalApiAnswerId, questionId);
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
        public static int DeleteAnswer(long originalQuestionId, long originalApiAnswerId) {
            return answerTableAdapter.Delete(originalQuestionId, originalApiAnswerId);
        }
    }
}
