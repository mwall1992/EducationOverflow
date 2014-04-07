using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class Business {

        private static UserTableAdapter userTableAdapter = new UserTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserDataTable SelectUsers() {
            return userTableAdapter.GetData();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertUser(int userId, string firstName, string lastName, 
                string email, System.DateTime dateOfBirth) {
            userTableAdapter.Insert(userId, firstName, lastName, email, dateOfBirth);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateUser(string firstName, string lastName, string email, System.DateTime dateOfBirth, int originalUserId) {
            userTableAdapter.Update(firstName, lastName, email, dateOfBirth, originalUserId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteUser(int originalUserId) {
            userTableAdapter.Delete(originalUserId);
        }
    }
}
