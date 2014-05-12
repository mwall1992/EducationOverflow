using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.UserInfoTableAdapters;

namespace Business {

    public class UserInfo {

        private static UserTableAdapter userTableAdapter = new UserTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.UserInfo SelectQuestionsFromUserView(int userId) {
            List<DataObjects.UserInfo> userInfo = new List<DataObjects.UserInfo>();

            Data.UserInfo.UserDataTable userDataTable = userTableAdapter.GetData(userId);
            Data.UserInfo.UserRow userDataRow = (Data.UserInfo.UserRow)userDataTable.Rows[0];

            return new DataObjects.UserInfo() {
                FirstName = userDataRow.FirstName,
                LastName = userDataRow.LastName,
                Email = userDataRow.Email,
                DateOfBirth = userDataRow.DateOfBirth
            };
        }
    }
}
