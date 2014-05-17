using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    public class UserMembershipInfo {

        private static UserMembershipInfoTableAdapter membershipTableAdapter = 
            new UserMembershipInfoTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.UserMembershipInfo SelectUserMembershipInfo(string username) {
            DataAccess.EducationOverflow.UserMembershipInfoDataTable userMemberDataTable =
                membershipTableAdapter.GetData(username);

            DataObjects.UserMembershipInfo memberInfo = null;
            if (userMemberDataTable.Count > 0) {

                DataAccess.EducationOverflow.UserMembershipInfoRow memberInfoRow =
                    (DataAccess.EducationOverflow.UserMembershipInfoRow)userMemberDataTable.Rows[0];

                memberInfo = new DataObjects.UserMembershipInfo() {
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
