using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on data associated with user roles.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the custom membership provide class for managing 
    /// membership information.
    /// </remarks>
    [DataObject]
    public class UserPassword {
        
        private static UserPasswordTableAdapter passwordTableAdapter = 
            new UserPasswordTableAdapter();

            // TODO: is this necessary?

        /// <summary>
        /// Retrieve 
        /// </summary>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserPasswordDataTable SelectUserPasswords() {
            return passwordTableAdapter.GetData();
        }

        /// <summary>
        /// Update a password for a specific user.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <param name="userId">The user id.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserPassword(string password, long originalUserId, long userId) {
            return passwordTableAdapter.Update(password, originalUserId, userId);
        }
    }
}
