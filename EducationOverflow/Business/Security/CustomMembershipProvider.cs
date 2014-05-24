using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration.Provider;

namespace Business {
    
    /// <summary>
    /// The membership provider used for the Education Overflow Web application.
    /// </summary>
    /// <remarks>
    /// For detailed documentation of overriden methods in this class, consult 
    /// the class documentation for System.Web.Security.MembershipProvide. Comments 
    /// have been included in this class only to document special implementation details.
    /// </remarks>
    public class CustomMembershipProvider : System.Web.Security.MembershipProvider {

        private static int MAX_INVALID_PASSWORD_ATTEMPTS = 5;

        private static int MIN_PASSWORD_LENGTH = 6;

        private static int PASSWORD_ATTEMPT_WINDOW = 10;

        private static int MIN_COUNT_NON_ALPHANUMERIC_CHARACTERS = 1;

        /// <summary>
        /// Get and set the application name associated with the membership provider.
        /// </summary>
        /// <remarks>
        /// The Education Overflow Web application does not currently use application
        /// names. As such, this property throws an exception if a value is set which is not
        /// equal to the current application name.
        /// </remarks>
        public override string ApplicationName {
            get {
                return CustomProvider.ApplicationName;
            }

            set {
                if (!value.Equals(CustomProvider.ApplicationName)) {
                    throw new ArgumentException("Modification of the Application Name is not supported.");
                }
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword) {
            const int INVALID_AFFECTED_ROWS = 0;
            bool passwordChanged = false;
            Data.EducationOverflow.UserMembershipRow membership = 
                UserMembership.SelectUserMembership(username);

            // attempt to change the user's password
            try {
                if (this.ValidateUser(username, oldPassword) && membership != null) {
                    int affectedRows = Queries.UpdateUserPassword(membership.UserId, EncryptUserPassword(newPassword));
                    passwordChanged = (affectedRows != INVALID_AFFECTED_ROWS);
                }
            } catch {
                passwordChanged = false;
            }

            return passwordChanged;
        }

        /// <summary>
        /// Updates the password question and answer for the membership user in the membership data store.
        /// </summary>
        /// <param name="username">The username for the membership user.</param>
        /// <param name="password">The current password for the membership user.</param>
        /// <param name="newPasswordQuestion">The new password question value for the membership user.</param>
        /// <param name="newPasswordAnswer">The new password answer value for the membership user.</param>
        /// <returns>false</returns>
        /// <remarks>
        /// A security question and answer is not required for this membership provider. Hence, security questions
        /// and answers cannot be changed.
        /// </remarks>
        public override bool ChangePasswordQuestionAndAnswer(string username, string password, 
                string newPasswordQuestion, string newPasswordAnswer) {
            return false;
        }

        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, 
                string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, 
                out System.Web.Security.MembershipCreateStatus status) {
            const int VALID_INSERTED_ROWS = 1;

            // initialise known constants for creating a new user
            const bool IS_LOCKED = false;
            DateTime CURRENT_TIME = DateTime.Now;
            DateTime? lastPasswordChangeDate = null;
            DateTime? lastLockedOutDate = null;
            const string COMMENT = null;
            const string PASSWORD_QUESTION = null;
            const string PASSWORD_ANSWER = null;

            // attempt to create user
            long? userId = null;
            try {
                int insertedRows = UserMembership.InsertUserMembership(this.ApplicationName, username, 
                    EncryptUserPassword(password), email, IS_LOCKED, CURRENT_TIME, isApproved, 
                    lastPasswordChangeDate, CURRENT_TIME, lastLockedOutDate, COMMENT, PASSWORD_QUESTION, 
                    PASSWORD_ANSWER);

                // determine if user information was created
                Data.EducationOverflow.UserMembershipRow memberRow = UserMembership.SelectUserMembership(username);
                if (insertedRows == VALID_INSERTED_ROWS && memberRow != null) {
                    userId = memberRow.UserId;
                    status = System.Web.Security.MembershipCreateStatus.Success;
                } else {
                    status = System.Web.Security.MembershipCreateStatus.ProviderError;
                }
            } catch {
                status = System.Web.Security.MembershipCreateStatus.ProviderError;
            }

            // initialise user membership object 
            string providerKey = (userId == null) ? null : userId.ToString();
            isApproved = (status == System.Web.Security.MembershipCreateStatus.Success);
            System.Web.Security.MembershipUser createdUser = 
                new System.Web.Security.MembershipUser(this.Name, username, providerUserKey,
                    email, PASSWORD_QUESTION, COMMENT, isApproved, IS_LOCKED, CURRENT_TIME, CURRENT_TIME, CURRENT_TIME,
                    CURRENT_TIME, DateTime.MinValue);

            return createdUser;
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData) {
            throw new NotSupportedException("Deleting users is disabled.");
        }

        public override bool EnablePasswordReset {
            get {
                return false;
            }
        }

        public override bool EnablePasswordRetrieval {
            get {
                return false;
            }
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, 
                int pageIndex, int pageSize, out int totalRecords) {
            const bool IS_APPROVED = true;
            
            //  validate email
            const int EMAIL_NAME_INDEX = 0;
            const int EMAIL_DOMAIN_INDEX = 1;
            const int EMAIL_COMPONENT_COUNT = 2;
            string[] emailComponents = emailToMatch.Split(new char[] { '@' });

            if (emailComponents.Length != EMAIL_COMPONENT_COUNT) {
                throw new ArgumentException("The specified email must include a single '@'");
            }

            // retrieved matched users
            Data.EducationOverflow.UserMembershipMatchingEmailDataTable matchedUserMembership = 
                UserMembership.SelectUserMembershipMatchingEmail(emailComponents[EMAIL_NAME_INDEX], 
                    emailComponents[EMAIL_DOMAIN_INDEX]);
            totalRecords = matchedUserMembership.Count;

            System.Web.Security.MembershipUserCollection membershipCollection = 
                new System.Web.Security.MembershipUserCollection();

            // parse retrieved users into data model
            Data.EducationOverflow.UserMembershipMatchingEmailRow currentMember;
            int startingIndex = pageSize * pageIndex;
            for (int i = startingIndex; i < pageSize; i++) {
                currentMember = (Data.EducationOverflow.UserMembershipMatchingEmailRow)matchedUserMembership.Rows[i];
                membershipCollection.Add(new System.Web.Security.MembershipUser(this.Name, 
                    currentMember.Username, currentMember.UserId, currentMember.Email, null, null, IS_APPROVED, 
                    currentMember.IsLocked, DateTime.MinValue, DateTime.MinValue, currentMember.LastActivityDate, 
                    DateTime.MinValue, DateTime.MinValue));
            }

            return membershipCollection;
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, 
                int pageIndex, int pageSize, out int totalRecords) {
            const bool IS_APPROVED = true;

            // retrieve matched users
            Data.EducationOverflow.UserMembershipMatchingUsernameDataTable matchedUserMembership =
                UserMembership.SelectUserMembershipMatchingUsername(usernameToMatch);
            totalRecords = matchedUserMembership.Count;

            // parse retrieved users into data model
            System.Web.Security.MembershipUserCollection membershipCollection =
                new System.Web.Security.MembershipUserCollection();

            Data.EducationOverflow.UserMembershipMatchingUsernameRow currentMember;
            int startingIndex = pageSize * pageIndex;
            for (int i = startingIndex; i < pageSize; i++) {
                currentMember = (Data.EducationOverflow.UserMembershipMatchingUsernameRow)matchedUserMembership.Rows[i];
                membershipCollection.Add(new System.Web.Security.MembershipUser(this.Name,
                    currentMember.Username, currentMember.UserId, currentMember.Email, null, null, IS_APPROVED, 
                    currentMember.IsLocked, DateTime.MinValue, DateTime.MinValue, currentMember.LastActivityDate, 
                    DateTime.MinValue, DateTime.MinValue));
            }

            return membershipCollection;
        }

        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
            const bool IS_APPROVED = true;

            // retrieve users
            Data.EducationOverflow.AllUserMembershipDataTable allUserMembership = UserMembership.SelectAllUserMembership();
            totalRecords = allUserMembership.Count;

            // parse retrieved users into data model
            System.Web.Security.MembershipUserCollection membershipCollection = new System.Web.Security.MembershipUserCollection();

            Data.EducationOverflow.AllUserMembershipRow currentMember;
            int startingIndex = pageSize * pageIndex;
            for (int i = startingIndex; i < pageSize; i++) {
                currentMember = (Data.EducationOverflow.AllUserMembershipRow)allUserMembership.Rows[i];
                membershipCollection.Add(new System.Web.Security.MembershipUser(this.Name, currentMember.Username, 
                    currentMember.UserId, currentMember.Email, null, null, IS_APPROVED, currentMember.IsLocked, 
                    DateTime.MinValue, DateTime.MinValue, currentMember.LastActivityDate, DateTime.MinValue, 
                    DateTime.MinValue));
            }

            return membershipCollection;
        }

        public override int GetNumberOfUsersOnline() {
            const int NEGATIVE_MULTIPLER = -1;
            int onlineCount = 0;

            Data.EducationOverflow.AllUserMembershipDataTable allUserMembership = UserMembership.SelectAllUserMembership();
            foreach (Data.EducationOverflow.AllUserMembershipRow membership in allUserMembership) {
                if (membership.LastActivityDate
                        >= DateTime.Now.AddMinutes(NEGATIVE_MULTIPLER * System.Web.Security.Membership.UserIsOnlineTimeWindow)) {
                    onlineCount++;
                }
            }

            return onlineCount;
        }

        public override string GetPassword(string username, string answer) {
            throw new System.Configuration.Provider.ProviderException("Password retrieval is disabled.");
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline) {
            System.Web.Security.MembershipUser membership = null;
            Data.EducationOverflow.UserMembershipRow retrievedMembership = UserMembership.SelectUserMembership(username);
            
            if (retrievedMembership != null) {
                membership = new System.Web.Security.MembershipUser("CustomMembershipProvider", 
                    retrievedMembership.Username, retrievedMembership.UserId, retrievedMembership.Email, null, null, true, 
                    retrievedMembership.IsLocked, DateTime.MinValue, DateTime.MinValue, 
                    retrievedMembership.LastActivityDate, DateTime.MinValue, DateTime.MinValue);

                if (userIsOnline) {
                    Queries.UpdateUserActivityDate(retrievedMembership.UserId, DateTime.Now);
                }
            }

            return membership;
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
            System.Web.Security.MembershipUser membership = null;
            Data.EducationOverflow.UserMembershipForUserIdRow retrievedMembership = 
                UserMembership.SelectUserMembershipForUserId((long)providerUserKey);

            if (retrievedMembership != null) {
                membership = new System.Web.Security.MembershipUser(this.Name,
                    retrievedMembership.Username, retrievedMembership.UserId, retrievedMembership.Email, null, null, true,
                    retrievedMembership.IsLocked, DateTime.MinValue, DateTime.MinValue,
                    retrievedMembership.LastActivityDate, DateTime.MinValue, DateTime.MinValue);

                if (userIsOnline) {
                    Queries.UpdateUserActivityDate(retrievedMembership.UserId, DateTime.Now);
                }
            }

            return membership;
        }

        public override string GetUserNameByEmail(string email) {
            string username = "";
            Data.EducationOverflow.UserMembershipForEmailRow membership = 
                UserMembership.SelectUserMembershipWithEmail(email);

            if (membership != null) {
                username = membership.Username;
            }

            return username;
        }

        public override int MaxInvalidPasswordAttempts {
            get {
                return CustomMembershipProvider.MAX_INVALID_PASSWORD_ATTEMPTS;
            }
        }

        public override int MinRequiredNonAlphanumericCharacters {
            get {
                return CustomMembershipProvider.MIN_COUNT_NON_ALPHANUMERIC_CHARACTERS;
            }
        }

        public override int MinRequiredPasswordLength {
            get {
                return CustomMembershipProvider.MIN_PASSWORD_LENGTH;
            }
        }

        public override int PasswordAttemptWindow {
            get {
                return CustomMembershipProvider.PASSWORD_ATTEMPT_WINDOW;
            }
        }

        public override System.Web.Security.MembershipPasswordFormat PasswordFormat {
            get {
                return System.Web.Security.MembershipPasswordFormat.Encrypted;
            }
        }

        /// <summary>
        /// Retrieve the regular expression used for determining password strength.
        /// </summary>
        /// <remarks>
        /// The returned regular expression is sourced from:
        /// http://stackoverflow.com/questions/447638/a-sensible-passwordstrengthregularexpression
        /// </remarks>
        public override string PasswordStrengthRegularExpression {
            get { 
                return "^.*(?=.{" + this.MinRequiredPasswordLength + ",})(?=.*\\d).*$"; 
            }
        }

        public override bool RequiresQuestionAndAnswer {
            get {
                return false;
            }
        }

        public override bool RequiresUniqueEmail {
            get {
                return true;
            }
        }

        public override string ResetPassword(string username, string answer) {
            throw new NotSupportedException("Password reset is disabled.");
        }

        public override bool UnlockUser(string userName) {
            const int VALID_AFFECTED_ROWS = 1;
            bool isUnlocked = false;

            Data.EducationOverflow.UserMembershipRow membership = 
                UserMembership.SelectUserMembership(userName);
            if (membership != null) {
                int affectedRows = Queries.UnlockUser(membership.UserId);
                isUnlocked = (affectedRows == VALID_AFFECTED_ROWS);
            }

            return isUnlocked;
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user) {
            
            // determine if user exists
            Data.EducationOverflow.UserMembershipRow membership = 
                UserMembership.SelectUserMembership(user.UserName);
            if (membership == null) {
                throw new ProviderException("Invalid user was specified for updating.");
            }

            UserMembership.UpdateUserMembership(membership.UserId.ToString(), user.UserName, user.Email, 
                user.IsLockedOut, user.LastActivityDate, user.IsApproved, user.LastPasswordChangedDate, 
                user.CreationDate, user.LastLockoutDate, user.Comment, user.PasswordQuestion, 
                membership.PasswordAnswer, membership.UserId);
        }

        public override bool ValidateUser(string username, string password) {
            bool isValid = false;
            string storedPassword = UserMembership.SelectPassword(username);

            if (storedPassword != null) {
                isValid = DecryptUserPassword(storedPassword).Equals(password);
            }

            return isValid;
        }


        // Helper Methods
        

        /// <summary>
        /// Encrypt a password.
        /// </summary>
        /// <param name="passwordPlaintext">The plain text password.</param>
        /// <returns>Then encrypted password</returns>
        private string EncryptUserPassword(string passwordPlaintext) {
            byte[] passwordBytes = System.Text.Encoding.Unicode.GetBytes(passwordPlaintext);
            byte[] encryptedBytes = EncryptPassword(passwordBytes);
            return System.Text.Encoding.Unicode.GetString(encryptedBytes);
        }

        /// <summary>
        /// Decrypt an encrypted password.
        /// </summary>
        /// <param name="encryptedPassword">The encrypted password.</param>
        /// <returns>The plain text password.</returns>
        private string DecryptUserPassword(string encryptedPassword) {
            byte[] encryptedPasswordBytes = 
                System.Text.Encoding.Unicode.GetBytes(encryptedPassword);
            byte[] decryptedBytes = DecryptPassword(encryptedPasswordBytes);
            return System.Text.Encoding.Unicode.GetString(decryptedBytes);
        }
    }
}
