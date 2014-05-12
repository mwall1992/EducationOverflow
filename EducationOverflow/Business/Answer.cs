using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    public class Answer {

        private static AnswerTableAdapter answerTableAdapter = new AnswerTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.Answer> SelectAnswers(string questionUrl) {
            List<DataObjects.Answer> answers = new List<DataObjects.Answer>();
            DataAccess.EducationOverflow.AnswerDataTable answerDataTable = answerTableAdapter.GetData(questionUrl);

            foreach (DataAccess.EducationOverflow.AnswerRow row in answerDataTable.Rows) {
                answers.Add(new DataObjects.Answer() {
                    QuestionURL = row.QuestionURL, 
                    ApiAnswerId = row.APIAnswerId,
                    Body = row.Body,
                    DownVotes = row.DownVotes,
                    UpVotes = row.UpVotes,
                    IsAccepted = row.IsAccepted
                });
            }

            return answers;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertAnswer(string questionUrl, int apiAnswerId, string body, 
                int upVotes, int downVotes, bool isAccepted) {
            answerTableAdapter.Insert(body, upVotes, downVotes, isAccepted, apiAnswerId, questionUrl);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateAnswer(string body, int upVotes, int downVotes, bool isAccepted, 
                string originalQuestionUrl, int originalApiAnswerId) {
            answerTableAdapter.Update(body, upVotes, downVotes, isAccepted,
                originalApiAnswerId, originalQuestionUrl);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteAnswer(string originalQuestionUrl, int originalApiAnswerId) {
            answerTableAdapter.Delete(originalApiAnswerId, originalQuestionUrl);
        }
    }
}
