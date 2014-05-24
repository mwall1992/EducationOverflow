using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class QuestionFeedbackSummary {
        
        private static QuestionFeedbackSummaryViewTableAdapter questionFeedbackTableAdapter = 
            new QuestionFeedbackSummaryViewTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionFeedbackSummaryViewDataTable SelectQuestionFeedbackSummaries() {
            return questionFeedbackTableAdapter.GetData();
        }
    }
}
