using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on data associated with user membership.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the custom membership provider class for managing membership 
    /// information.
    /// </remarks>
    [DataObject]
    public class UserMembership {

        /// <summary>
        /// The table adapter used for individual membership information (including passwords).
        /// </summary>
        private static UserMembershipTableAdapter membershipTableAdapter =
            new UserMembershipTableAdapter();

        /// <summary>
        /// The table adapter used for individual membership information (not including passwords).
        /// </summary>
        private static UserMembershipWithoutPasswordTableAdapter membershipWithoutPasswordTableAdapter = 
            new UserMembershipWithoutPasswordTableAdapter();

        /// <summary>
        /// The table adapter used for membership information for all users.
        /// </summary>
        private static AllUserMembershipTableAdapter allUserMembershipTableAdapter = 
            new AllUserMembershipTableAdapter();

        /// <summary>
        /// The table adapter used for individual membership information with matched emails.
        /// </summary>
        private static UserMembershipForEmailTableAdapter userMembershipForEmailTableAdapter =
            new UserMembershipForEmailTableAdapter();

        /// <summary>
        /// The table adapter used for membership information with matching emails.
        /// </summary>
        private static UserMembershipMatchingEmailTableAdapter userMembershipMatchingEmailTableAdapter =
             new UserMembershipMatchingEmailTableAdapter();

        /// <summary>
        /// The table adapter used for membership information with matching usernames.
        /// </summary>
        private static UserMembershipMatchingUsernameTableAdapter membershipMatchingUsernameTableAdapter = 
            new UserMembershipMatchingUsernameTableAdapter();

        /// <summary>
        /// The table adapter used for individual membership information for a user id.
        /// </summary>
        private static UserMembershipForUserIdTableAdapter membershipForUserIdTableAdapter = 
            new UserMembershipForUserIdTableAdapter();

        /// <summary>
        /// Retrieve membership information associated with a specific username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>A row containing membership information for the specified user.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipRow SelectUserMembership(string username) {
            Data.EducationOverflow.UserMembershipDataTable membershipDataTable = membershipTableAdapter.GetData(username);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.UserMembershipRow>(membershipDataTable);
        }

        /// <summary>
        /// Retrieve membership information associated with a user id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>A row containing information for the specified user.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipForUserIdRow SelectUserMembershipForUserId(long userId) {
            Data.EducationOverflow.UserMembershipForUserIdDataTable membershipDataTable = 
                membershipForUserIdTableAdapter.GetData(userId);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.UserMembershipForUserIdRow>(membershipDataTable);
        }

        /// <summary>
        /// Retrieve the password associated with a specific username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>The specified user's password.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static string SelectPassword(string username) {
            string password = null;
            
            Data.EducationOverflow.UserMembershipDataTable userMemberDataTable =
                membershipTableAdapter.GetData(username);
            Data.EducationOverflow.UserMembershipRow membershipRow = 
                DataSetUtilities.GetFirstRow<Data.EducationOverflow.UserMembershipRow>(userMemberDataTable);
            
            if (membershipRow != null) {
                password = membershipRow.Password;
            }

            return password;
        }

        /// <summary>
        /// Retrieve membership information for all users.
        /// </summary>
        /// <returns>A table containing membership information for all users.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.AllUserMembershipDataTable SelectAllUserMembership() {
            return allUserMembershipTableAdapter.GetData();
        }

        /// <summary>
        /// Retrieve membership information for a user with a specific email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>A row containing information for a user with the specified email.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipForEmailRow SelectUserMembershipWithEmail(string email) {
            Data.EducationOverflow.UserMembershipForEmailDataTable membershipDataTable = 
                userMembershipForEmailTableAdapter.GetData(email);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.UserMembershipForEmailRow>(membershipDataTable);
        }

        /// <summary>
        /// Retrieve membership information for all users with a matching email.
        /// </summary>
        /// <param name="email">The portion of the email address before the @ symbol.</param>
        /// <param name="domain">The portion of the email address after the @ symbol.</param>
        /// <returns>
        /// A table containing information for all users whose email addresses match the specified email.
        /// </returns>
        /// <remarks>
        /// For information on what counts as a matching email, see the MembershipProvider class documentation.
        /// </remarks>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipMatchingEmailDataTable SelectUserMembershipMatchingEmail(
                string email, string domain) {
            return userMembershipMatchingEmailTableAdapter.GetData(email, domain);
        }

        /// <summary>
        /// Retrieve membership information for all users with a matching username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>
        /// A table containing information for all users whose username matches the specified username.
        /// </returns>
        /// <remarks>
        /// For information on what counts as a matching username, see the MembershipProvider class documentation.
        /// </remarks>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipMatchingUsernameDataTable SelectUserMembershipMatchingUsername(
                string username) {
            return membershipMatchingUsernameTableAdapter.GetData(username);
        }

        /// <summary>
        /// Insert user membership information.
        /// </summary>
        /// <param name="applicationName">The name of the application the user is associated with.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The user's email.</param>
        /// <param name="isLocked">Denotes if the user's account is locked (true) or not (false).</param>
        /// <param name="lastActivityDate">The last date the user was active.</param>
        /// <param name="isApproved">Denotes if the user's account has been approved.</param>
        /// <param name="lastPasswordChangeDate">The last date the user's password was changed.</param>
        /// <param name="creationDate">The date the user was created.</param>
        /// <param name="lastLockedOutDate">The date the user was last locked out.</param>
        /// <param name="comment">A comment regarding the user.</param>
        /// <param name="passwordQuestion">The user's security question.</param>
        /// <param name="passwordAnswer">The user's answer to their security question.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertUserMembership(string applicationName, string username, string password, 
                string email, bool isLocked, DateTime lastActivityDate,
                bool? isApproved, DateTime? lastPasswordChangeDate, DateTime? creationDate,
                DateTime? lastLockedOutDate, string comment, string passwordQuestion, string passwordAnswer) {
            return membershipTableAdapter.Insert(applicationName, username, password, email, isLocked, 
                lastActivityDate, isApproved, lastPasswordChangeDate, creationDate, lastLockedOutDate, 
                comment, passwordQuestion, passwordAnswer);
        }

        /// <summary>
        /// Update the membership information for a user (including password).
        /// </summary>
        /// <param name="applicationName">The name of the application the user is associated with.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="email">The user's email.</param>
        /// <param name="isLocked">Denotes if the user's account is locked (true) or not (false).</param>
        /// <param name="lastActivityDate">The last date the user was active.</param>
        /// <param name="isApproved">Denotes if the user's account has been approved.</param>
        /// <param name="lastPasswordChangeDate">The last date the user's password was changed.</param>
        /// <param name="creationDate">The date the user was created.</param>
        /// <param name="lastLockedOutDate">The date the user was last locked out.</param>
        /// <param name="comment">A comment regarding the user.</param>
        /// <param name="passwordQuestion">The user's security question.</param>
        /// <param name="passwordAnswer">The user's answer to their security question.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserMembership(string applicationName, string username, string password, 
                string email, bool isLocked, DateTime lastActivityDate,
                bool? isApproved, DateTime? lastPasswordChangeDate, DateTime? creationDate,
                DateTime? lastLockedOutDate, string comment, string passwordQuestion, string passwordAnswer, 
                long originalUserId) {
            return membershipTableAdapter.Update(applicationName, username, password, email, isLocked, 
                lastActivityDate, isApproved, lastPasswordChangeDate, creationDate, lastLockedOutDate, 
                comment, passwordQuestion, passwordAnswer, originalUserId);
        }

        /// <summary>
        /// Update the membership information for a user (not including the user's password).
        /// </summary>
        /// <param name="applicationName">The name of the application the user is associated with.</param>
        /// <param name="username">The username.</param>
        /// <param name="email">The user's email.</param>
        /// <param name="isLocked">Denotes if the user's account is locked (true) or not (false).</param>
        /// <param name="lastActivityDate">The last date the user was active.</param>
        /// <param name="isApproved">Denotes if the user's account has been approved.</param>
        /// <param name="lastPasswordChangeDate">The last date the user's password was changed.</param>
        /// <param name="creationDate">The date the user was created.</param>
        /// <param name="lastLockedOutDate">The date the user was last locked out.</param>
        /// <param name="comment">A comment regarding the user.</param>
        /// <param name="passwordQuestion">The user's security question.</param>
        /// <param name="passwordAnswer">The user's answer to their security question.</param>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserMembership(string applicationName, string username,
                string email, bool isLocked, DateTime lastActivityDate, 
                bool? isApproved, DateTime? lastPasswordChangeDate, DateTime? creationDate, 
                DateTime? lastLockedOutDate, string comment, string passwordQuestion, string passwordAnswer,
                long originalUserId) {
            return membershipWithoutPasswordTableAdapter.Update(applicationName, username, email, isLocked, 
                lastActivityDate, isApproved, lastPasswordChangeDate, creationDate, lastLockedOutDate, 
                comment, passwordQuestion, passwordAnswer, originalUserId);
        }

        /// <summary>
        /// Delete user membership information.
        /// </summary>
        /// <param name="originalUserId">The original user id.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteUserMembership(long originalUserId) {
            return membershipTableAdapter.Delete(originalUserId);
        }
    }
}
