using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on data associated with tag synonyms.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the Stack Exchange API classes for retrieving information
    /// from the Stack Exchange API servers.
    /// </remarks>
    [DataObject]
    public class TagSynonym {
    
        private static TagSynonymTableAdapter tagSynonymTableAdapter = new TagSynonymTableAdapter();

        /// <summary>
        /// Retrieve synonyms for a tag.
        /// </summary>
        /// <param name="tagName">The name of the tag.</param>
        /// <returns>A table of synonyms associated with the specified tag.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.TagSynonymDataTable SelectTagSynonyms(string tagName) {
            return tagSynonymTableAdapter.GetData(tagName);
        }

        /// <summary>
        /// Insert a syonyms for a tag.
        /// </summary>
        /// <param name="tagName">The name of the tag.</param>
        /// <param name="synonym">The name of the synonym.</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertTagSynonym(string tagName, string synonym) {
            return tagSynonymTableAdapter.Insert(synonym, tagName);
        }

        /// <summary>
        /// Update a synonym for a tag.
        /// </summary>
        /// <param name="tagName">The name of the tag.</param>
        /// <param name="synonym">The name of the synonym.</param>
        /// <param name="originalTagName">The original name of the tag.</param>
        /// <param name="originalSynonym">The original name of the synonym.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateTagSynonym(string tagName, string synonym, 
                string originalTagName, string originalSynonym) {
            return tagSynonymTableAdapter.Update(tagName, synonym, originalTagName, originalSynonym);
        }

        /// <summary>
        /// Delete a synonym for a tag.
        /// </summary>
        /// <param name="originalTagName">The original name of the tag.</param>
        /// <param name="originalSynonym">The original name of the synonym.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteTagSynonym(string originalTagName, string originalSynonym) {
            return tagSynonymTableAdapter.Delete(originalSynonym, originalTagName); 
        }
    }
}
