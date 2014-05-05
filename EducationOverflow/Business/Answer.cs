using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.AnswersTableAdapters;

namespace Business {
    
    public class Answer {

        private static AnswerTableAdapter answerTableAdapter = new AnswerTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.Answer> SelectAnswers() {
            List<DataObjects.Answer> answers = new List<DataObjects.Answer>();
            Data.Answers.AnswerDataTable answerDataTable = answerTableAdapter.GetData();

            foreach (Data.Answers.AnswerRow row in answerDataTable.Rows) {
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
            answerTableAdapter.Insert(questionUrl, apiAnswerId, body, upVotes, downVotes, isAccepted);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateAnswer(string questionUrl, int apiAnswerId, string body,
                int upVotes, int downVotes, bool isAccepted, string originalQuestionUrl, int originalApiAnswerId) {
            answerTableAdapter.Update(questionUrl, apiAnswerId, body, upVotes, downVotes, isAccepted, 
                originalQuestionUrl, originalApiAnswerId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteAnswer(string originalQuestionUrl, int originalApiAnswerId) {
            answerTableAdapter.Delete(originalQuestionUrl, originalApiAnswerId);
        }
    }
}
