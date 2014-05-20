using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    public class QuestionTag {

        private static QuestionTagTableAdapter questionTagTableAdapter =
            new QuestionTagTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<string> SelectQuestionTags(long questionId) {
            List<string> tags = new List<string>();

            DataAccess.EducationOverflow.QuestionTagDataTable questionTagDataTable =
                questionTagTableAdapter.GetData(questionId);
            foreach (DataAccess.EducationOverflow.QuestionTagRow row in questionTagDataTable.Rows) {
                tags.Add(row.TagName);
            }

            return tags;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertQuestionTag(long questionId, string tagName) {
            questionTagTableAdapter.Insert(questionId, tagName);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateQuestionTag(long questionId, string tagName, 
                long originalQuestionId, string originalTagName) {
            questionTagTableAdapter.Update(questionId, tagName, originalQuestionId, originalTagName);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteQuestionTag(long originalQuestionId, string originalTagName) {
            questionTagTableAdapter.Delete(originalQuestionId, originalTagName);
        }
    }
}
