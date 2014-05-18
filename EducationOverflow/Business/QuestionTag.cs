using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    public class QuestionTag {

        private static QuestionTagsTableAdapter questionTagTableAdapter =
            new QuestionTagsTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<string> SelectQuestionTags(string questionUrl) {
            List<string> tags = new List<string>();

            DataAccess.EducationOverflow.QuestionTagsDataTable questionTagDataTable =
                questionTagTableAdapter.GetData(questionUrl);
            foreach (DataAccess.EducationOverflow.QuestionTagsRow row in questionTagDataTable.Rows) {
                tags.Add(row.TagName);
            }

            return tags;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertQuestionTag(string questionUrl, string tagName) {
            questionTagTableAdapter.Insert(questionUrl, tagName);
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
