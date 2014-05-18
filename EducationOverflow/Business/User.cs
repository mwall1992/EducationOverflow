using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    public class User {

        private static UserTableAdapter userTableAdapter = new UserTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataObjects.User SelectQuestionsFromUserView(int userId) {
            List<DataObjects.User> userInfo = new List<DataObjects.User>();

            DataAccess.EducationOverflow.UserDataTable userDataTable = userTableAdapter.GetData(userId);
            DataAccess.EducationOverflow.UserRow userDataRow = 
                (DataAccess.EducationOverflow.UserRow)userDataTable.Rows[0];

            return new DataObjects.User() {
                FirstName = userDataRow.FirstName,
                LastName = userDataRow.LastName,
                DateOfBirth = userDataRow.DateOfBirth
            };
        }
    }
}
