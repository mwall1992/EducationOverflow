using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration.Provider;

namespace Business {
    
    public class CustomMembershipProvider : System.Web.Security.MembershipProvider {

        private static int MAX_INVALID_PASSWORD_ATTEMPTS = 5;

        private static int MIN_PASSWORD_LENGTH = 6;

        private static int PASSWORD_ATTEMPT_WINDOW = 10;

        private static int MIN_COUNT_NON_ALPHANUMERIC_CHARACTERS = 1;

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
            Data.EducationOverflow.UserMembershipRow membership = UserMembership.SelectUserMembership(username);

            try {
                if (this.ValidateUser(username, oldPassword) && membership != null) {
                    int affectedRows = Queries.UpdateUserPassword(membership.UserId, newPassword);
                    passwordChanged = (affectedRows != INVALID_AFFECTED_ROWS);
                }
            } catch {
                passwordChanged = false;
            }

            return passwordChanged;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, 
                string newPasswordQuestion, string newPasswordAnswer) {
            return false;
        }

        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, 
                string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, 
                out System.Web.Security.MembershipCreateStatus status) {
                            
            const bool IS_LOCKED = false;
            const int INVALID_AFFECTED_ROWS = 0;
            DateTime CURRENT_TIME = DateTime.Now;
            
            long? userId = null;
            try {
                int affectedRows = UserMembership.InsertUserMembership(this.ApplicationName, username, password, 
                    email, IS_LOCKED, DateTime.Now, isApproved, null, DateTime.Now, null, null, null, null);
                userId = UserMembership.SelectUserMembership(username).UserId;

                status = (affectedRows != INVALID_AFFECTED_ROWS) ? System.Web.Security.MembershipCreateStatus.Success 
                                                                 : System.Web.Security.MembershipCreateStatus.ProviderError;
            } catch {
                status = System.Web.Security.MembershipCreateStatus.ProviderError;
            }

            string providerKey = (userId == null) ? null : userId.ToString();

            isApproved = (status == System.Web.Security.MembershipCreateStatus.Success);
            return new System.Web.Security.MembershipUser(providerKey, username, providerUserKey,
                    email, null, null, isApproved, IS_LOCKED, CURRENT_TIME, CURRENT_TIME, CURRENT_TIME,
                    CURRENT_TIME, DateTime.MinValue);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData) {
            const int INVALID_AFFFECTED_ROWS = 0;
            bool userDeleted = false;
            Data.EducationOverflow.UserMembershipRow membership = UserMembership.SelectUserMembership(username);

            // TODO: REMOVE ALL USER INFORMATION! (via cascade)

            try {
                if (membership != null && deleteAllRelatedData) {
                    
                    // remove role information
                    Data.EducationOverflow.UserRolesDataTable roles = UserRoles.SelectUserRoles(username);

                    string[] roleNames = new string[roles.Count];
                    for (int i = 0; i < roles.Count; i++) {
                        roleNames[i] = roles[i].RoleName;
                    }

                    UserRoles.DeleteRolesFromUsers(roleNames, new long[] { membership.UserId });

                    // remove user information
                    User.DeleteUser(membership.UserId);

                    // remove membership information
                    int affectedRows = UserMembership.DeleteUserMembership(membership.UserId);
                    userDeleted = (affectedRows != INVALID_AFFFECTED_ROWS);
                }
            } catch {
                userDeleted = false;
            }

            return userDeleted;
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
            
            const int EMAIL_NAME_INDEX = 0;
            const int EMAIL_DOMAIN_INDEX = 1;
            const int EMAIL_COMPONENT_COUNT = 2;
            string[] emailComponents = emailToMatch.Split(new char[] { '@' });

            if (emailComponents.Length != EMAIL_COMPONENT_COUNT) {
                throw new ArgumentException("The specified email must include a single '@'");
            }

            Data.EducationOverflow.UserMembershipMatchingEmailDataTable matchedUserMembership = 
                UserMembership.SelectUserMembershipMatchingEmail(emailComponents[EMAIL_NAME_INDEX], 
                    emailComponents[EMAIL_DOMAIN_INDEX]);
            totalRecords = matchedUserMembership.Count;

            System.Web.Security.MembershipUserCollection membershipCollection = 
                new System.Web.Security.MembershipUserCollection();

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

            Data.EducationOverflow.UserMembershipMatchingUsernameDataTable matchedUserMembership =
                UserMembership.SelectUserMembershipMatchingUsername(usernameToMatch);
            totalRecords = matchedUserMembership.Count;

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
            Data.EducationOverflow.AllUserMembershipDataTable allUserMembership = UserMembership.SelectAllUserMembership();
            totalRecords = allUserMembership.Count;

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

        public override string PasswordStrengthRegularExpression {
            // Source: http://stackoverflow.com/questions/447638/a-sensible-passwordstrengthregularexpression
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
            const int INVALID_AFFECTED_ROWS = 0;
            bool isUnlocked = false;

            Data.EducationOverflow.UserMembershipRow membership = UserMembership.SelectUserMembership(userName);
            if (membership != null) {
                int affectedRows = Queries.UnlockUser(membership.UserId);
                isUnlocked = (affectedRows != INVALID_AFFECTED_ROWS);
            }

            return isUnlocked;
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user) {
            Data.EducationOverflow.UserMembershipRow membership = UserMembership.SelectUserMembership(user.UserName);
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
                isValid = storedPassword.Equals(password);
            }

            return isValid;
        }
    }
}
