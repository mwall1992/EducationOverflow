﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class QuestionFeedbackSummary {
        
        private static QuestionFeedbackSummaryViewTableAdapter questionFeedbackTableAdapter = 
            new QuestionFeedbackSummaryViewTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.QuestionFeedbackSummaryViewDataTable SelectQuestionFeedbackSummaries() {
            return questionFeedbackTableAdapter.GetData();

            //List<DataObjects.QuestionFeedbackSummary> questionFeedbackSummaries = 
            //    new List<DataObjects.QuestionFeedbackSummary>();
            //DataAccess.EducationOverflow.QuestionFeedbackSummaryViewDataTable questionFeedbackDataTable = 
            //    questionFeedbackTableAdapter.GetData();

            //foreach (DataAccess.EducationOverflow.QuestionFeedbackSummaryViewRow row in questionFeedbackDataTable.Rows) {
            //    questionFeedbackSummaries.Add(new DataObjects.QuestionFeedbackSummary() {
            //        Liked = row.Liked,
            //        SummaryAdjective = row.SummaryAdjective,
            //        UserId = row.UserId,
            //        FirstName = row.FirstName,
            //        LastName = row.LastName,
            //        ApiSiteParameter = row.APISiteParameter,
            //        QuestionTitle = row.Title,
            //        QuestionId = row.Id
            //    });
            //}

            //return questionFeedbackSummaries;
        }
    }
}