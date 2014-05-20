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

            //List<DataObjects.QuestionSummary> questions = new List<DataObjects.QuestionSummary>();
            //DataAccess.EducationOverflow.QuestionsUserViewDataTable questionDataTable = questionsTableAdapter.GetData();

            //foreach (DataAccess.EducationOverflow.QuestionsUserViewRow row in questionDataTable.Rows) {
            //    questions.Add(new DataObjects.QuestionSummary() {
            //        Title = row.Title, 
            //        Body = row.Body,
            //        Likes = row.Likes,
            //        Dislikes = row.Dislikes,
            //        MostCommonSummaryAdjective = row.MostCommonSummaryAdjective
            //    });
            //}

            //return questions;
        }
    }
}
