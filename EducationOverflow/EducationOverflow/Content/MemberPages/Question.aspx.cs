using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EducationOverflow.Content.Member_Pages {
    
    public partial class Question : System.Web.UI.Page {
        
        private static string QUESTION_ID_PARAMETER = "QuestionId";

        protected void Page_Init(object sender, EventArgs e) {
            HintRepeater.DataSource = new Data.EducationOverflow.HintForQuestionDataTable();
            HintRepeater.DataBind();
        }

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

                HintRepeater.DataSource = new Data.EducationOverflow.HintForQuestionDataTable();
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            
        }

        protected void HintButton_Click(object sender, EventArgs e) {
            
            // retrieve existing hints
            Data.EducationOverflow.HintForQuestionDataTable hintDataTable = 
                (Data.EducationOverflow.HintForQuestionDataTable)HintRepeater.DataSource; 
            int existingHintCount = (hintDataTable == null) ? 0 : hintDataTable.Rows.Count;

            long[] existingHintIds = new long[existingHintCount];
            for (int i = 0; i < existingHintCount; i++) {
                existingHintIds[i] = 
                    ((Data.EducationOverflow.HintForQuestionRow)hintDataTable.Rows[i]).APIAnswerId;
            }

            // retrieve hint data
            long questionId = Convert.ToInt64(Request.QueryString[QUESTION_ID_PARAMETER]);
            Data.EducationOverflow.HintForQuestionRow hintRow = 
                Business.QuestionHint.SelectHintForQuestion(questionId, existingHintIds);

            // bind data to repeater
            if (hintDataTable == null) {
                hintDataTable = new Data.EducationOverflow.HintForQuestionDataTable();
            }

            hintDataTable.ImportRow(hintRow);
            HintRepeater.DataSource = hintDataTable;
            HintRepeater.DataBind();


            //HintRepeater.DataSource = dataTable;
            //HintRepeater.DataBind();
            

            //RepeaterItemCollection repeaterItems = HintRepeater.Items;

            //RepeaterItem currentRepeaterItem;
            //for (int i = 0; i < repeaterItems.Count; i++) {
            //    currentRepeaterItem = repeaterItems[i];
            //    Control hintContainer = currentRepeaterItem.FindControl("HintContainer");
                
            //    if (!hintContainer.Visible) {
            //        hintContainer.Visible = true;

            //        if (i == repeaterItems.Count - 1) {
            //            HintButton.Visible = false;
            //        }

            //        break;
            //    }
            //}
        }

        protected void SolutionButton_Click(object sender, EventArgs e) {
            SolutionButton.Visible = false;
            SolutionLabel.Text =
                Business.AcceptedAnswer.SelectAcceptedAnswer(Convert.ToInt64(Request.QueryString[QUESTION_ID_PARAMETER])).Body;
        }

        protected void ReportQuestionButton_Click(object sender, EventArgs e) {
            long questionId = Convert.ToInt64(Request.QueryString[QUESTION_ID_PARAMETER]);
            System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();
            Business.ReportedQuestion.InsertReportedQuestion(questionId, Convert.ToInt64(user.ProviderUserKey), 
                Convert.ToInt32(ReportedReasonList.SelectedValue), ReportDescription.Text);
        }
    }
}