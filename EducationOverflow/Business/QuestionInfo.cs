using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class QuestionInfo {

        private static QuestionInfoTableAdapter questionInfoTableAdapter = 
            new QuestionInfoTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionInfoDataTable SelectQuestionInfo() {
            return questionInfoTableAdapter.GetData();

            //List<DataObjects.QuestionInfo> questions = new List<DataObjects.QuestionInfo>();
            //DataAccess.EducationOverflow.QuestionInfoDataTable questionInfoDataTable =
            //    questionInfoTableAdapter.GetData();

            //foreach (DataAccess.EducationOverflow.QuestionInfoRow row in questionInfoDataTable.Rows) {
            //    questions.Add(new DataObjects.QuestionInfo() {
            //        Id = row.QuestionId,
            //        Body = row.Body,
            //        UpVotes = row.UpVotes,
            //        DownVotes = row.DownVotes
            //    });
            //}

            //return questions;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertQuestionInfo(string body, int upVotes, int downVotes) {
            questionInfoTableAdapter.Insert(body, upVotes, downVotes);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateQuestionInfo(string body, int upVotes, int downVotes, long questionId) {
            questionInfoTableAdapter.Update(body, upVotes, downVotes, questionId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteQuestionInfo(long questionId) {
            questionInfoTableAdapter.Delete(questionId);
        }
    }
}
