﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    public class TagInfo {

        private static TagsInfoUserViewTableAdapter tagsTableAdapter = new TagsInfoUserViewTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<DataObjects.Tag> SelectQuestionsFromUserView() {
            List<DataObjects.Tag> tags = new List<DataObjects.Tag>();
            DataAccess.EducationOverflow.TagsInfoUserViewDataTable tagsDataTable = tagsTableAdapter.GetData();

            foreach (DataAccess.EducationOverflow.TagsInfoUserViewRow row in tagsDataTable.Rows) {
                tags.Add(new DataObjects.Tag() {
                    Name = row.Name,
                    Description = row.Description,
                    Count = row.SynonymCount
                });
            }

            return tags;
        }
    }
}