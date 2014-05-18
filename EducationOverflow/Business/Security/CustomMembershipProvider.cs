﻿using System;
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
            DataObjects.UserMembership membership = UserMembership.SelectUserMembership(username);

            try {
                if (this.ValidateUser(username, oldPassword) && membership != null) {
                    int affectedRows = UserMembership.UpdateUserMembership(membership.ApplicationName, membership.Username, 
                        newPassword, membership.Email, membership.IsLocked, membership.LastActivityDate, 
                        membership.UserId);
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
                    email, IS_LOCKED, DateTime.Now);
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
            DataObjects.UserMembership membership = UserMembership.SelectUserMembership(username);

            // TODO: REMOVE ALL USER INFORMATION! (via cascade)

            try {
                if (membership != null && deleteAllRelatedData) {
                    
                    // remove role information
                    List<string> roles = UserRoles.SelectUserRoles(username);
                    UserRoles.DeleteRolesFromUsers(roles.ToArray(), new long[] { membership.UserId });

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

        public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords) {
            // SUMMARY:
            // Can be done.
            
            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords) {
            // SUMMARY:
            // Can be done.

            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords) {
            const bool IS_APPROVED = true;
            List<DataObjects.UserMembership> allUserMembership = UserMembership.SelectAllUserMembership();
            totalRecords = allUserMembership.Count;

            System.Web.Security.MembershipUserCollection membershipCollection = new System.Web.Security.MembershipUserCollection();

            DataObjects.UserMembership currentMember;
            int startingIndex = pageSize * pageIndex;
            for (int i = startingIndex; i < pageSize; i++) {
                currentMember = allUserMembership[i];
                membershipCollection.Add(new System.Web.Security.MembershipUser(currentMember.UserId.ToString(), currentMember.Username, 
                    null, currentMember.Email, null, null, IS_APPROVED, currentMember.IsLocked, DateTime.MinValue, DateTime.MinValue, 
                    currentMember.LastActivityDate, DateTime.MinValue, DateTime.MinValue));
            }

            return membershipCollection;
        }

        public override int GetNumberOfUsersOnline() {
            const int NEGATIVE_MULTIPLER = -1;
            int onlineCount = 0;

            List<DataObjects.UserMembership> allUserMembership = UserMembership.SelectAllUserMembership();
            foreach (DataObjects.UserMembership membership in allUserMembership) {
                if (membership.LastActivityDate
                        >= DateTime.Now.AddMinutes(NEGATIVE_MULTIPLER * System.Web.Security.Membership.UserIsOnlineTimeWindow)) {
                    onlineCount++;
                }
            }

            return onlineCount;
        }

        public override string GetPassword(string username, string answer) {
            throw new System.Configuration.Provider.ProviderException("Password retrieve is disabled.");
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline) {
            System.Web.Security.MembershipUser membership = null;
            DataObjects.UserMembership retrievedMembership = UserMembership.SelectUserMembership(username);
            if (retrievedMembership != null) {
                membership = new System.Web.Security.MembershipUser(retrievedMembership.UserId.ToString(), 
                    retrievedMembership.Username, null, retrievedMembership.Email, null, null, true, 
                    retrievedMembership.IsLocked, DateTime.MinValue, DateTime.MinValue, 
                    retrievedMembership.LastActivityDate, DateTime.MinValue, DateTime.MinValue);

                if (userIsOnline) {
                    UserMembership.UpdateUserMembership(retrievedMembership.ApplicationName, retrievedMembership.Username,
                        retrievedMembership.Email, retrievedMembership.IsLocked, DateTime.Now, retrievedMembership.UserId);
                }
            }

            return membership;
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline) {
            // SUMMARY:
            // Need to update database schema first. 
            // This method can be implemented.
            
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email) {
            // SUMMARY:
            // Can be done.

            throw new NotImplementedException();
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
            const bool IS_LOCKED = false;
            bool isUnlocked = false;

            DataObjects.UserMembership membership = UserMembership.SelectUserMembership(userName);
            if (membership != null) {
                int affectedRows = UserMembership.UpdateUserMembership(membership.ApplicationName, membership.Username,
                    membership.Email, IS_LOCKED, membership.LastActivityDate, membership.UserId);
                isUnlocked = (affectedRows != INVALID_AFFECTED_ROWS);
            }

            return isUnlocked;
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user) {
            DataObjects.UserMembership membership = UserMembership.SelectUserMembership(user.UserName);
            if (membership == null) {
                throw new ProviderException("Invalid user was specified for updating.");
            }

            UserMembership.UpdateUserMembership(membership.UserId.ToString(), user.UserName, user.Email, 
                user.IsLockedOut, user.LastActivityDate, membership.UserId);
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
