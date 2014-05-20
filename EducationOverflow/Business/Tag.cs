using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class Tag {

        private static TagTableAdapter tagTableAdapter = new TagTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.TagDataTable SelectTag() {
            return tagTableAdapter.GetData();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertTag(string name, string description, int count) {
            tagTableAdapter.Insert(name, description, count);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateTag(string name, string description, int count,
                string originalName) {
            tagTableAdapter.Update(name, description, count, originalName);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteTag(string originalName) {
            tagTableAdapter.Delete(originalName);
        }
    }
}
