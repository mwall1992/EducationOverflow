using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class TagInfo {

        private static TagsInfoUserViewTableAdapter tagsTableAdapter = new TagsInfoUserViewTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.TagsInfoUserViewDataTable SelectTags() {
            return tagsTableAdapter.GetData();
        }
    }
}
