using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class User {

        private static UserTableAdapter userTableAdapter = new UserTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserRow SelectUser(long userId) {
            return (Data.EducationOverflow.UserRow)userTableAdapter.GetData(userId).Rows[0];
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
