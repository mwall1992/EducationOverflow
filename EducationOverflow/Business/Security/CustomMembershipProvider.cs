using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business {
    
    public class CustomMembershipProvider : System.Web.Security.MembershipProvider {

        private static string APPLICATION_NAME = "educationoverflow";

        private static int MAX_INVALID_PASSWORD_ATTEMPTS = 5;

        private static int MIN_PASSWORD_LENGTH = 6;

        private static int PASSWORD_ATTEMPT_WINDOW = 10;

        private static int MIN_COUNT_NON_ALPHANUMERIC_CHARACTERS = 1;

        public override string ApplicationName {
            get {
                return CustomMembershipProvider.APPLICATION_NAME;
            }
            set {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword) {
            // SUMMARY:
            // Can be done.

            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer) {
            // SUMMARY:
            // Need to update database schema first. 
            // This method can be implemented.

            throw new NotImplementedException();
        }

        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status) {
            // SUMMARY:
            // Can be done.
            
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData) {
            // SUMMARY:
            // Can be done.

            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset {
            get {
                return true;
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
            // SUMMARY:
            // Can be done.

            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline() {
            // SUMMARY:
            // Need to update database schema first. 
            // This method can be implemented.

            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer) {
            throw new System.Configuration.Provider.ProviderException("Password retrieve is disabled.");
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline) {
            // SUMMARY:
            // Need to update database schema first. 
            // This method can be implemented.
            
            throw new NotImplementedException();
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
            // SUMMARY:
            // This method can be implemented by sourcing a regular expression
            // from elsewhere.
            //
            // N.B. Clarify with Anthony.

            get { throw new NotImplementedException(); }
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
            // SUMMARY:
            // Need to update database schema first. 
            // This method can be implemented.

            throw new NotImplementedException();
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user) {
            // SUMMARY:
            // Can be done.

            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password) {
            // SUMMARY:
            // Can be done.

            throw new NotImplementedException();
        }
    }
}
