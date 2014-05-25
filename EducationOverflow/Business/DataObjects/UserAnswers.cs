using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class UserAnswers {
        
        private static UserAnswersTableAdapter userAnswersTableAdapter = 
            new UserAnswersTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.UserAnswersDataTable SelectUserAnswers(long userId) {
            return userAnswersTableAdapter.GetData(userId);
        }
    }
}
