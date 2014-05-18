using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    public class UserMembership {

        private static UserMembershipTableAdapter membershipTableAdapter =
            new UserMembershipTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.UserMembership SelectUserMembership(string username) {
            DataAccess.EducationOverflow.UserMembershipDataTable userMemberDataTable =
                membershipTableAdapter.GetData(username);

            DataObjects.UserMembership memberInfo = null;
            if (userMemberDataTable.Count > 0) {

                DataAccess.EducationOverflow.UserMembershipRow memberInfoRow =
                    (DataAccess.EducationOverflow.UserMembershipRow)userMemberDataTable.Rows[0];

                memberInfo = new DataObjects.UserMembership() {
                    UserId = memberInfoRow.UserId,
                    Username = memberInfoRow.Username,
                    ApplicationName = memberInfoRow.ApplicationName,
                    Email = memberInfoRow.Email,
                    IsLocked = memberInfoRow.IsLocked,
                    LastActivityDate = memberInfoRow.LastActivityDate
                };
            }

            return memberInfo;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertUserMembership(string applicationName, string username, string password, 
                string email, bool isLocked, DateTime lastActivityDate) {
            membershipTableAdapter.Insert(applicationName, username, password, email, isLocked, lastActivityDate);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateUserMembership(string applicationName, string username, string password, 
                string email, bool isLocked, DateTime lastActivityDate, long originalUserId) {
            membershipTableAdapter.Update(applicationName, username, password, email, isLocked, 
                lastActivityDate, originalUserId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteUserMembership(long originalUserId) {
            membershipTableAdapter.Delete(originalUserId);
        }
    }
}
