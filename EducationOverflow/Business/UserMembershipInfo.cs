using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    public class UserMembershipInfo {

        private static UserMembershipTableAdapter membershipTableAdapter =
            new UserMembershipTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.UserMembership SelectUserMembershipInfo(string username) {
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

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateUserMembershipInfo(string username, string applicationName, string email) {
           
        }
    }
}
