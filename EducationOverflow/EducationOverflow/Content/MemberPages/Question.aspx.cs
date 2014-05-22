﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EducationOverflow.Content.Member_Pages {
    
    public partial class Question : System.Web.UI.Page {
        
        private static string QUESTION_ID_PARAMETER = "QuestionId";

        protected void Page_Load(object sender, EventArgs e) {
            
            // handle initial page load
            if (!IsPostBack) {

                // retrieve question data
                string questionId = Request.QueryString[QUESTION_ID_PARAMETER];
                Data.EducationOverflow.QuestionAnswerInfoRow infoRow = 
                    Business.QuestionAnswerInfo.SelectQuestionAnswerInfo(Convert.ToInt64(questionId));

                // populate web form
                generatedTitle.InnerText = (string)infoRow["Title"];
                question.InnerHtml = (string)infoRow["Body"];

                // set state of controls
                const int MIN_ANSWERS_FOR_HINT = 2;
                HintButton.Enabled = ((int)infoRow["AnswerCount"] >= MIN_ANSWERS_FOR_HINT); 
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            
        }

        protected void HintButton_Click(object sender, EventArgs e) {
            HintsUpdatePanel.Update();
            HintsUpdatePanel.Visible = true;
            System.Threading.Thread.Sleep(3000);
        }

        protected void SolutionButton_Click(object sender, EventArgs e) {
            SolutionLabel.Text =
                Business.AcceptedAnswer.SelectAcceptedAnswer(Convert.ToInt64(Request.QueryString[QUESTION_ID_PARAMETER])).Body;
            SolutionUpdatePanel.Update();
            SolutionUpdatePanel.Visible = true;
            System.Threading.Thread.Sleep(3000);
        }

        protected void ReportQuestionButton_Click(object sender, EventArgs e) {
            long questionId = Convert.ToInt64(Request.QueryString[QUESTION_ID_PARAMETER]);
            System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();
            Business.ReportedQuestion.InsertReportedQuestion(questionId, Convert.ToInt64(user.ProviderUserKey), 
                Convert.ToInt32(ReportedReasonList.SelectedValue), ReportDescription.Text);
        }
    }
}