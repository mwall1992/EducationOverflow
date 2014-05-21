using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class Queries {

        private static QueriesTableAdapter queriesTableAdapter = 
            new QueriesTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserPassword(long userId, string newPassword) {
            return queriesTableAdapter.UserPasswordUpdate(newPassword, userId);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserActivityDate(long userId, DateTime lastActivityDate) {
            return queriesTableAdapter.UserActivityDateUpdate(lastActivityDate, userId);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UnlockUser(long userId) {
            return queriesTableAdapter.UnlockUserUpdate(userId);
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertUserForId(long userId, string firstName, string lastName, DateTime dateOfBirth) {
            return queriesTableAdapter.InsertUserForId(userId, firstName, lastName, dateOfBirth.ToString());
        }
    }
}
