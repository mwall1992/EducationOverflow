using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class QuestionSummaryAdjective {
    
        private static QuestionSummaryAdjectiveTableAdapter adjectiveTableAdapter = 
            new QuestionSummaryAdjectiveTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionSummaryAdjectiveDataTable SelectSummaryAdjectives() {
            return adjectiveTableAdapter.GetData();
        }
    }
}
