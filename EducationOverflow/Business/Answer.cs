using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class Answer {

        private static AnswerTableAdapter answerTableAdapter = new AnswerTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.AnswerDataTable SelectAnswers(long questionId) {
            return answerTableAdapter.GetData(questionId);

            //List<DataObjects.Answer> answers = new List<DataObjects.Answer>();
            //DataAccess.EducationOverflow.AnswerDataTable answerDataTable = 
            //    answerTableAdapter.GetData(questionId);

            //foreach (DataAccess.EducationOverflow.AnswerRow row in answerDataTable.Rows) {
            //    answers.Add(new DataObjects.Answer() {
            //        QuestionId = row.QuestionId, 
            //        ApiAnswerId = row.APIAnswerId,
            //        Body = row.Body,
            //        DownVotes = row.DownVotes,
            //        UpVotes = row.UpVotes,
            //        IsAccepted = row.IsAccepted
            //    });
            //}

            //return answers;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertAnswer(long apiAnswerId, string body, int upVotes, 
                int downVotes, bool isAccepted) {
            return answerTableAdapter.Insert(apiAnswerId, body, upVotes, downVotes, isAccepted);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateAnswer(long questionId, long apiAnswerId, string body, int upVotes, 
                int downVotes, bool isAccepted, long originalQuestionId, long originalApiAnswerId) {
            return answerTableAdapter.Update(apiAnswerId, body, upVotes, downVotes, isAccepted, 
                originalQuestionId, originalApiAnswerId, questionId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteAnswer(long originalQuestionId, long originalApiAnswerId) {
            answerTableAdapter.Delete(originalQuestionId, originalApiAnswerId);
        }
    }
}
