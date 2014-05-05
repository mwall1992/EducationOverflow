using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.QuestionTagTableAdapters;

namespace Business {
    
    public class QuestionTag {

        private static QuestionTagTableAdapter questionTagTableAdapter = 
            new QuestionTagTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<string> SelectQuestionTags(string questionUrl) {
            List<string> tags = new List<string>();

            Data.QuestionTag.QuestionTagDataTable questionTagDataTable =
                questionTagTableAdapter.GetData(questionUrl);
            foreach (Data.QuestionTag.QuestionTagRow row in questionTagDataTable.Rows) {
                tags.Add(row.TagName);
            }

            return tags;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertQuestionTag(string questionUrl, string tagName) {
            try {
                questionTagTableAdapter.Insert(questionUrl, tagName);
            } catch (Exception e) {
                // stub
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateQuestionTag(string questionUrl, string tagName, 
                string originalQuestionUrl, string originalTagName) {
            questionTagTableAdapter.Update(questionUrl, tagName, originalQuestionUrl, originalTagName);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteQuestionTag(string originalQuestionUrl, string originalTagName) {
            questionTagTableAdapter.Delete(originalQuestionUrl, originalTagName);
        }
    }
}
