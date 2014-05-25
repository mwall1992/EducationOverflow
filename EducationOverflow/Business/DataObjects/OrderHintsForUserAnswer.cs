using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class OrderHintsForUserAnswer {
    
        private static OrderHintsForUserAnswerTableAdapter hintsTableAdapter = 
            new OrderHintsForUserAnswerTableAdapter();
    
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.OrderHintsForUserAnswerDataTable SelectHintsForUserAnswer(
                long userId, long userAnswerId) {
            return hintsTableAdapter.GetData(userAnswerId, userId);
        }
    }
}
