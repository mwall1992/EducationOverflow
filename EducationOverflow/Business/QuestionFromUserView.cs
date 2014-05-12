using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.QuestionsUserViewTableAdapters;

namespace Business {
    
    public class QuestionFromUserView {

        private static QuestionsUserViewTableAdapter questionsTableAdapter = new QuestionsUserViewTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.QuestionSummary> SelectQuestionsFromUserView() {
            List<DataObjects.QuestionSummary> questions = new List<DataObjects.QuestionSummary>();
            Data.QuestionsUserView.QuestionsUserViewDataTable questionDataTable = questionsTableAdapter.GetData();

            foreach (Data.QuestionsUserView.QuestionsUserViewRow row in questionDataTable.Rows) {
                questions.Add(new DataObjects.QuestionSummary() {
                    Title = row.Title, 
                    Body = row.Body,
                    Likes = row.Likes,
                    Dislikes = row.Dislikes,
                    MostCommonSummaryAdjective = row.MostCommonSummaryAdjective
                });
            }

            return questions;
        }
    }
}
