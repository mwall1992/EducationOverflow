using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class UserPassword {
        
        private static UserPasswordTableAdapter passwordTableAdapter = 
            new UserPasswordTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserPasswordDataTable SelectUserPasswords() {
            return passwordTableAdapter.GetData();
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateUserPassword(string password, long originalUserId, long userId) {
            return passwordTableAdapter.Update(password, originalUserId, userId);
        }
    }
}
