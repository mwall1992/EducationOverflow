using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    public class UserInfo {

        private static UserInfoTableAdapter userTableAdapter = new UserInfoTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.UserInfo SelectQuestionsFromUserView(int userId) {
            List<DataObjects.UserInfo> userInfo = new List<DataObjects.UserInfo>();

            DataAccess.EducationOverflow.UserInfoDataTable userDataTable = userTableAdapter.GetData(userId);
            DataAccess.EducationOverflow.UserInfoRow userDataRow = 
                (DataAccess.EducationOverflow.UserInfoRow)userDataTable.Rows[0];

            return new DataObjects.UserInfo() {
                FirstName = userDataRow.FirstName,
                LastName = userDataRow.LastName,
                Email = userDataRow.Email,
                DateOfBirth = userDataRow.DateOfBirth
            };
        }
    }
}
