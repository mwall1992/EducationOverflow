using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    public class QuestionURL {

        private static QuestionUrlTableAdapter questionUrlTableAdapter = new QuestionUrlTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.Question> SelectQuestionURL() {
            List<DataObjects.Question> questions = new List<DataObjects.Question>();
            DataAccess.EducationOverflow.QuestionUrlDataTable questionUrlDataTable = questionUrlTableAdapter.GetData();

            foreach (DataAccess.EducationOverflow.QuestionUrlRow row in questionUrlDataTable.Rows) {
                questions.Add(new DataObjects.Question() {
                    URL = row.URL,
                    ApiQuestionId = row.APIQuestionId,
                    Title = row.Title,
                    ApiSiteParameter = row.APISiteParameter
                });
            }

            return questions;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertQuestionURL(int apiQuestionId, string apiSiteParameter, string title, string url) {
            questionUrlTableAdapter.Insert(apiQuestionId, apiSiteParameter, title, url);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateQuestionURL(int apiQuestionId, string apiSiteParameter, string title, string url,
                string originalUrl) {
            questionUrlTableAdapter.Update(apiQuestionId, apiSiteParameter, title, url, originalUrl);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteQuestionURL(string originalQuestionUrl) {
            questionUrlTableAdapter.Delete(originalQuestionUrl);
        }
    }
}
