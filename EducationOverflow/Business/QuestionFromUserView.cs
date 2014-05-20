using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class QuestionFromUserView {

        private static QuestionsUserViewTableAdapter questionsTableAdapter = new QuestionsUserViewTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionsUserViewDataTable SelectQuestionsFromUserView() {
            return questionsTableAdapter.GetData();
        }
    }
}
