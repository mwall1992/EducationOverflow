using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class QuestionSummary {

        private static QuestionSummaryViewTableAdapter questionsTableAdapter = 
            new QuestionSummaryViewTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionSummaryViewDataTable SelectQuestionSummaries() {
            return questionsTableAdapter.GetData();
        }
    }
}
