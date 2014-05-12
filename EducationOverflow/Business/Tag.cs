﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    public class Tag {

        private static TagTableAdapter tagTableAdapter = new TagTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.Tag> SelectTag() {
            List<DataObjects.Tag> tags = new List<DataObjects.Tag>();
            DataAccess.EducationOverflow.TagDataTable tagDataTable = tagTableAdapter.GetData();

            foreach (DataAccess.EducationOverflow.TagRow row in tagDataTable.Rows) {
                tags.Add(new DataObjects.Tag() {
                    Name = row.Name,
                    Description = row.Description,
                    Count = row.Count
                });
            }

            return tags;
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertTag(string name, string description, int count) {
            try {
                tagTableAdapter.Insert(name, description, count);
            } catch (Exception e) {
                // stub
            }
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
