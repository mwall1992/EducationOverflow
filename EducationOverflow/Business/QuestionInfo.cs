using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    public class QuestionInfo {

        private static QuestionInfoTableAdapter questionInfoTableAdapter = new QuestionInfoTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertQuestionInfo(string questionUrl, string body, int upVotes, int downVotes) {
            questionInfoTableAdapter.Insert(questionUrl, body, upVotes, downVotes);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateQuestionInfo(string questionUrl, string body, int upVotes, int downVotes,
                string originalQuestionUrl) {
            questionInfoTableAdapter.Update(questionUrl, body, upVotes, downVotes, originalQuestionUrl);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteQuestionInfo(string questionUrl) {
            questionInfoTableAdapter.Delete(questionUrl);
        }
    }
}
