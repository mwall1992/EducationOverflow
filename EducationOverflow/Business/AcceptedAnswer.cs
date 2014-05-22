using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class AcceptedAnswer {
        
        private static AcceptedAnswerTableAdapter acceptedAnswerTableAdapter = 
            new AcceptedAnswerTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.AcceptedAnswerRow SelectAcceptedAnswer(long questionId) {
            return (Data.EducationOverflow.AcceptedAnswerRow)acceptedAnswerTableAdapter.GetData(questionId).Rows[0];
        }
    }
}
