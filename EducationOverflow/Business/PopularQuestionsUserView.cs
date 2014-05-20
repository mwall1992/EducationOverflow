using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class PopularQuestionsUserView {
        
        private static PopularQuestionsUserViewTableAdapter popularQuestionsTableAdapter = 
            new PopularQuestionsUserViewTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.PopularQuestionsUserViewDataTable SelectPopularQuestions() {
            return  popularQuestionsTableAdapter.GetData();
        }
    }
}
