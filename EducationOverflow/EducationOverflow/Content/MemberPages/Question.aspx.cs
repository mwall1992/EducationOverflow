using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EducationOverflow.Content.Member_Pages {
    
    public partial class Question : System.Web.UI.Page {
        
        private static string QUESTION_ID_PARAMETER = "QuestionId";
        private static string USER_ANSWER_ID_PARAMETER = "AnswerId";

        protected void Page_Load(object sender, EventArgs e) {
            
            // handle initial page load
            if (!IsPostBack) {

                // retrieve question data
                string questionId = Request.QueryString[QUESTION_ID_PARAMETER];
                long questionIdNumber = Convert.ToInt64(questionId);
                Data.EducationOverflow.QuestionAnswerInfoRow infoRow =
                    Business.AnswerInfo.SelectAnswerInfo(questionIdNumber);

                // retrieve user information
                System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();
                long userId = Convert.ToInt64(user.ProviderUserKey);

                // populate web form
                generatedTitle.InnerText = (string)infoRow["Title"];
                question.InnerHtml = (string)infoRow["Body"];

                // set state of controls
                string userAnswerId;
                if ((userAnswerId = Request.QueryString[USER_ANSWER_ID_PARAMETER]) != null) {
                    Data.EducationOverflow.UserAnswerToQuestionRow answer =
                        Business.UserAnswerToQuestion.SelectUserAnswerToQuestion(userId, Convert.ToInt64(userAnswerId));
                        if (answer != null) {
                            myAnswerTextBox.Text = answer.Body;
                            NotesTextBox.Text = answer.Notes;

                            if (answer.IsAnswered) {
                                HintButton.Visible = false;
                                SaveButton.Visible = false;
                                SolutionButton.Visible = false;
                                SolutionLabel.Text =
                                    Business.AcceptedAnswer.SelectAcceptedAnswer(questionIdNumber).Body;
                            }
                        }
                } else {
                    const int MIN_ANSWERS_FOR_HINT = 2;
                    HintButton.Enabled = ((int)infoRow["AnswerCount"] >= MIN_ANSWERS_FOR_HINT);
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            long questionId = Convert.ToInt64(Request.QueryString[QUESTION_ID_PARAMETER]);
            
            // retrieve user information
            System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();
            long userId = Convert.ToInt64(user.ProviderUserKey);

            // retrieve hint information
            Data.EducationOverflow.HintsDataTable hintsTable = new Data.EducationOverflow.HintsDataTable();
            RepeaterItemCollection repeaterItems = HintRepeater.Items;

            RepeaterItem currentRepeaterItem;
            for (int i = 0; i < repeaterItems.Count; i++) {
                currentRepeaterItem = repeaterItems[i];
                Control hintContainer = currentRepeaterItem.FindControl("HintContainer");

                
                if (hintContainer.Visible) {
                    Data.EducationOverflow.HintsRow hintsRow = hintsTable.NewHintsRow();
                    hintsRow.ApiAnswerId = Convert.ToInt64(((HiddenField)hintContainer.FindControl("APIAnswerIdField")).Value);
                    hintsRow.DateViewed = Convert.ToDateTime(((HiddenField)hintContainer.FindControl("HintDateViewed")).Value);
                    hintsTable.Rows.Add(hintsRow);
                }
            }


            bool isAnswered = !SolutionButton.Visible;

            Business.Queries.InsertUserAnswerForQuestion(userId, questionId, myAnswerTextBox.Text, 
                NotesTextBox.Text, isAnswered, hintsTable);

            SaveButton.Visible = false;
        }

        protected void HintButton_Click(object sender, EventArgs e) {
            RepeaterItemCollection repeaterItems = HintRepeater.Items;

            RepeaterItem currentRepeaterItem;
            for (int i = 0; i < repeaterItems.Count; i++) {
                currentRepeaterItem = repeaterItems[i];
                Control hintContainer = currentRepeaterItem.FindControl("HintContainer");

                if (!hintContainer.Visible) {
                    ((HiddenField)hintContainer.FindControl("HintDateViewed")).Value = DateTime.Now.ToString();
                    hintContainer.Visible = true;

                    if (i == repeaterItems.Count - 1) {
                        HintButton.Visible = false;
                    }

                    break;
                }
            }
        }

        protected void SolutionButton_Click(object sender, EventArgs e) {
            SolutionButton.Visible = false;
            SolutionLabel.Text =
                Business.AcceptedAnswer.SelectAcceptedAnswer(Convert.ToInt64(Request.QueryString[QUESTION_ID_PARAMETER])).Body;
        }

        protected void ReportQuestionButton_Click(object sender, EventArgs e) {
            try {
                ReportedReasonList.Enabled = false;
                ReportDescription.Enabled = false;
                ReportQuestionButton.Enabled = false;

                long questionId = Convert.ToInt64(Request.QueryString[QUESTION_ID_PARAMETER]);
                System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();
                Business.ReportedQuestion.InsertReportedQuestion(questionId, Convert.ToInt64(user.ProviderUserKey),
                    Convert.ToInt32(ReportedReasonList.SelectedValue), ReportDescription.Text);
            } catch {
                ErrorLabel.Visible = true;
            }
        }
    }
}