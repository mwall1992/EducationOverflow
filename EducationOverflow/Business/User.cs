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
        public static DataObjects.User SelectUser(int userId) {
            DataAccess.EducationOverflow.UserDataTable userDataTable = userTableAdapter.GetData(userId);
            DataAccess.EducationOverflow.UserRow userDataRow = 
                (DataAccess.EducationOverflow.UserRow)userDataTable.Rows[0];

            return new DataObjects.User() {
                FirstName = userDataRow.FirstName,
                LastName = userDataRow.LastName,
                DateOfBirth = userDataRow.DateOfBirth
            };
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertUser(string firstName, string lastName, DateTime dateOfBirth) {
            userTableAdapter.Insert(firstName, lastName, dateOfBirth);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateUser(string firstName, string lastName, DateTime dateOfBirth, 
                long originalUserId, long userId) {
            userTableAdapter.Update(firstName, lastName, dateOfBirth, originalUserId, userId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteUser(long originalUserId) {
            userTableAdapter.Delete(originalUserId);
        }
    }
}
