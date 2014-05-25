using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject used for retrieving all of a user's answers.
    /// </summary>
    [DataObject]
    public class UserAnswers {
        
        /// <summary>
        /// The table adapter used to retrieve a user's answers.
        /// </summary>
        private static UserAnswersTableAdapter userAnswersTableAdapter = 
            new UserAnswersTableAdapter();

        /// <summary>
        /// Retrieve all of a user's answers.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>A table containing information on all of a user's answers.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserAnswersDataTable SelectUserAnswers(long userId) {
            return userAnswersTableAdapter.GetData(userId);
        }
    }
}
