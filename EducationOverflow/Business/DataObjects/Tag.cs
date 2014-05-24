using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing CRUD operations on data associated with tags.
    /// </summary>
    /// <remarks>
    /// This class is commonly used by the Stack Exchange API classes for retrieving information
    /// from the Stack Exchange API servers.
    /// </remarks>
    [DataObject]
    public class Tag {

        private static TagTableAdapter tagTableAdapter = new TagTableAdapter();

        /// <summary>
        /// Retrieve all the tags.
        /// </summary>
        /// <returns>A table of all the tags.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.TagDataTable SelectTag() {
            return tagTableAdapter.GetData();
        }

        /// <summary>
        /// Insert a tag.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="description">A description of the tag.</param>
        /// <param name="count">The usage count of the tag (on Stack Exchange).</param>
        /// <returns>The number of rows affected by the insertion.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static int InsertTag(string name, string description, int count) {
            return tagTableAdapter.Insert(name, description, count);
        }

        /// <summary>
        /// Update a tag.
        /// </summary>
        /// <param name="name">The name of the tag.</param>
        /// <param name="description">A description of the tag.</param>
        /// <param name="count">The usage count of the tag (on Stack Exchange).</param>
        /// <param name="originalName">The original name of the tag.</param>
        /// <returns>The number of rows affected by the update.</returns>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateTag(string name, string description, int count,
                string originalName) {
            return tagTableAdapter.Update(name, description, count, originalName);
        }

        /// <summary>
        /// Delete a tag.
        /// </summary>
        /// <param name="originalName">The original name of the tag.</param>
        /// <returns>The number of rows affected by the deletion.</returns>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static int DeleteTag(string originalName) {
            return tagTableAdapter.Delete(originalName);
        }
    }
}
