using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations for tags.
    /// </summary>
    [DataObject]
    public class TagInfo {

        /// <summary>
        /// The table adapter used for tag information.
        /// </summary>
        private static TagsInfoUserViewTableAdapter tagsTableAdapter = new TagsInfoUserViewTableAdapter();

        /// <summary>
        /// Retrieve information for all tags.
        /// </summary>
        /// <returns>A table containing information on all tags.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.TagsInfoUserViewDataTable SelectTags() {
            return tagsTableAdapter.GetData();
        }
    }
}
