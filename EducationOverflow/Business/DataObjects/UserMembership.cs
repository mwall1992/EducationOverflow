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
    [DataObject]
    public class UserMembership {

        private static UserMembershipTableAdapter membershipTableAdapter =
            new UserMembershipTableAdapter();

        private static UserMembershipWithoutPasswordTableAdapter membershipWithoutPasswordTableAdapter = 
            new UserMembershipWithoutPasswordTableAdapter();

        private static AllUserMembershipTableAdapter allUserMembershipTableAdapter = 
            new AllUserMembershipTableAdapter();

        private static UserMembershipForEmailTableAdapter userMembershipForEmailTableAdapter =
            new UserMembershipForEmailTableAdapter();

        private static UserMembershipMatchingEmailTableAdapter userMembershipMatchingEmailTableAdapter =
             new UserMembershipMatchingEmailTableAdapter();

        private static UserMembershipMatchingUsernameTableAdapter membershipMatchingUsernameTableAdapter = 
            new UserMembershipMatchingUsernameTableAdapter();

        private static UserMembershipForUserIdTableAdapter membershipForUserIdTableAdapter = 
            new UserMembershipForUserIdTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipRow SelectUserMembership(string username) {
            Data.EducationOverflow.UserMembershipDataTable membershipDataTable = membershipTableAdapter.GetData(username);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.UserMembershipRow>(membershipDataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipForUserIdRow SelectUserMembershipForUserId(long userId) {
            Data.EducationOverflow.UserMembershipForUserIdDataTable membershipDataTable = 
                membershipForUserIdTableAdapter.GetData(userId);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.UserMembershipForUserIdRow>(membershipDataTable);
        }

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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.AllUserMembershipDataTable SelectAllUserMembership() {
            return allUserMembershipTableAdapter.GetData();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipForEmailRow SelectUserMembershipWithEmail(string email) {
            Data.EducationOverflow.UserMembershipForEmailDataTable membershipDataTable = 
                userMembershipForEmailTableAdapter.GetData(email);
            return DataSetUtilities.GetFirstRow<Data.EducationOverflow.UserMembershipForEmailRow>(membershipDataTable);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipMatchingEmailDataTable SelectUserMembershipMatchingEmail(
                string email, string domain) {
            return userMembershipMatchingEmailTableAdapter.GetData(email, domain);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserMembershipMatchingUsernameDataTable SelectUserMembershipMatchingUsername(
                string username) {
            return membershipMatchingUsernameTableAdapter.GetData(username);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertUserMembership(string applicationName, string username, string password, 
                string email, bool isLocked, DateTime lastActivityDate,
                bool? isApproved, DateTime? lastPasswordChangeDate, DateTime? creationDate,
                DateTime? lastLockedOutDate, string comment, string passwordQuestion, string passwordAnswer) {
            return membershipTableAdapter.Insert(applicationName, username, password, email, isLocked, 
                lastActivityDate, isApproved, lastPasswordChangeDate, creationDate, lastLockedOutDate, 
                comment, passwordQuestion, passwordAnswer);
        }

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

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteUserMembership(long originalUserId) {
            return membershipTableAdapter.Delete(originalUserId);
        }
    }
}
