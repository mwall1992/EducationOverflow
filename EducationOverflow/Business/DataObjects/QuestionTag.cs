using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on tags associated with questions.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the Stack Exchange API classes for retrieving information
    /// from the Stack Exchange API servers.
    /// </remarks>
    [DataObject]
    public class QuestionTag {

        private static QuestionTagTableAdapter questionTagTableAdapter =
            new QuestionTagTableAdapter();

        /// <summary>
        /// Retrieve the tags associated with a question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <returns>A table of tags associated with the question.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionTagDataTable SelectQuestionTags(long questionId) {
            return questionTagTableAdapter.GetData(questionId);
        }

        /// <summary>
        /// Insert a tag for a question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="tagName">The name of the tag.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertQuestionTag(long questionId, string tagName) {
            return questionTagTableAdapter.Insert(questionId, tagName);
        }

        /// <summary>
        /// Update a tag for a question.
        /// </summary>
        /// <param name="questionId">The question id.</param>
        /// <param name="tagName">The tag name.</param>
        /// <param name="originalQuestionId">The original question id.</param>
        /// <param name="originalTagName">The original tag name.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateQuestionTag(long questionId, string tagName, 
                long originalQuestionId, string originalTagName) {
            return questionTagTableAdapter.Update(questionId, tagName, originalQuestionId, originalTagName);
        }

        /// <summary>
        /// Delete a tag for a question.
        /// </summary>
        /// <param name="originalQuestionId">The original question id.</param>
        /// <param name="originalTagName">The original tag name.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteQuestionTag(long originalQuestionId, string originalTagName) {
            return questionTagTableAdapter.Delete(originalQuestionId, originalTagName);
        }
    }
}
