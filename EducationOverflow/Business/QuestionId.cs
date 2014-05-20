using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class QuestionId {

        private static QuestionIdTableAdapter questionIdTableAdapter = 
            new QuestionIdTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionIdDataTable SelectQuestionId() {
            return questionIdTableAdapter.GetData();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertQuestionId(int apiQuestionId, string apiSiteParameter, string title, string url) {
            questionIdTableAdapter.Insert(apiQuestionId, apiSiteParameter, title, url);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateQuestionId(int apiQuestionId, string apiSiteParameter, string title, string url,
                long originalId) {
            questionIdTableAdapter.Update(apiQuestionId, apiSiteParameter, title, url, originalId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteQuestionId(long originalId) {
            questionIdTableAdapter.Delete(originalId);
        }
    }
}
