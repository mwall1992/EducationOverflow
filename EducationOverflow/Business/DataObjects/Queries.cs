using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing a variety of uncategorised update and insert operations.
    /// </summary>
    [DataObject]
    public class Queries {

        /// <summary>
        /// The table adapter used for uncategorised queries.
        /// </summary>
        private static QueriesTableAdapter queriesTableAdapter = 
            new QueriesTableAdapter();

        /// <summary>
        /// Update the password for a user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="newPassword">The new password for the user.</param>
        /// <returns>The number of rows affected by the update.</returns>
        /// <remarks>
        /// Any validation required for this operation must be performed prior to 
        /// calling this method.
        /// </remarks>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserPassword(long userId, string newPassword) {
            return queriesTableAdapter.UserPasswordUpdate(newPassword, userId);
        }

        /// <summary>
        /// Update the last activity date of a user.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="lastActivityDate">The last activity date.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserActivityDate(long userId, DateTime lastActivityDate) {
            return queriesTableAdapter.UserActivityDateUpdate(lastActivityDate, userId);
        }

        /// <summary>
        /// Unlock a user's account.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>The number of rows affected by this update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UnlockUser(long userId) {
            return queriesTableAdapter.UnlockUserUpdate(userId);
        }

        /// <summary>
        /// Insert a user's answer for a question.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <param name="questionId">The id of the question.</param>
        /// <param name="answerBody">The answer body.</param>
        /// <param name="answerNotes">The notes body.</param>
        /// <param name="isAnswered">Denotes if the question is answered (true) or not (false).</param>
        /// <param name="hintsTable">A table of hints used by the user in answering the question.</param>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertUserAnswerForQuestion(long userId, long questionId, string answerBody, 
                string answerNotes, bool isAnswered, Data.EducationOverflow.HintsDataTable hintsTable) {
            queriesTableAdapter.InsertUserAnswerForQuestion(userId, questionId, answerBody, answerNotes, 
                isAnswered, hintsTable);
        }
    }
}
