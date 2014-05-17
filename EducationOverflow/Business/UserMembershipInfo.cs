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
            DataAccess.EducationOverflow.UserMembershipInfoDataTable membershipInfoDataTable = 
                membershipTableAdapter.GetData(username);
            DataAccess.EducationOverflow.UserMembershipInfoRow membershipRow = 
                (DataAccess.EducationOverflow.UserMembershipInfoRow)membershipInfoDataTable.Rows[0];

            return new DataObjects.UserMembershipInfo() {
                UserId = membershipRow.UserId,
                Username = membershipRow.Username,
                Email = membershipRow.Email,
                ApplicationName = membershipRow.ApplicationName
            };
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateUserMembershipInfo(string username, string applicationName, string email) {
            // stub
        }
    }
}
