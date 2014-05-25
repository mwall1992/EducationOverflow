using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EducationOverflow.Content.Member_Pages {
    
    public partial class Question : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            
            // handle initial page load
            if (!IsPostBack) {

                // retrieve page state information
                long? questionId = this.RetrieveQuestionId();
                long? userId = this.RetrieveUserId();

                // populate the web form for the question information
                if (questionId != null) {
                    Data.EducationOverflow.QuestionAnswerInfoRow infoRow =
                        Business.AnswerInfo.SelectAnswerInfo((long)questionId);

                    generatedTitle.InnerText = (string)infoRow["Title"];
                    question.InnerHtml = (string)infoRow["Body"];

                    // populate the web form for a user's answer
                    long? userAnswerId = this.RetrieveUserAnswerId();
                    if (userAnswerId != null) {

                        
                        Data.EducationOverflow.UserAnswerToQuestionRow answer =
                            Business.UserAnswerToQuestion.SelectUserAnswerToQuestion((long)userId, 
                                (long)userAnswerId);

                        // populate answer and notes sections
                        if (answer != null) {
                            myAnswerTextBox.Text = answer.Body;
                            NotesTextBox.Text = answer.Notes;

                            if (answer.IsAnswered) {
                                HintButton.Visible = false;
                                SaveButton.Visible = false;
                                SolutionButton.Visible = false;
                                SolutionLabel.Text =
                                    Business.AcceptedAnswer.SelectAcceptedAnswer((long)questionId).Body;
                            }

                        } else {
                            const int MIN_ANSWERS_FOR_HINT = 2;
                            HintButton.Enabled = ((int)infoRow["AnswerCount"] >= MIN_ANSWERS_FOR_HINT);
                        }

                    }
                }
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e) {
            
            // attempt to save the state of the answer in the data tier
            try {
                SaveButton.Visible = false;

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

                // insert the answer information into the data tier
                Business.Queries.InsertUserAnswerForQuestion((long)this.RetrieveUserId(), (long)this.RetrieveQuestionId(), 
                    myAnswerTextBox.Text, NotesTextBox.Text, isAnswered, hintsTable);

                SaveSuccessLabel.Visible = true;
            } catch {
                SaveFailedLabel.Visible = true;
            }
        }

        protected void HintButton_Click(object sender, EventArgs e) {
            RepeaterItemCollection repeaterItems = HintRepeater.Items;

            // reveal the next hint
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
            try {
                // retrieve the solution
                SolutionButton.Visible = false;
                string solutionText =
                    Business.AcceptedAnswer.SelectAcceptedAnswer((long)this.RetrieveQuestionId()).Body;
                
                // set the solution field
                if (solutionText != null) {
                    SolutionLabel.Text = solutionText;
                } else {
                    SolutionLabel.Text = "No answer was found.";
                }
            } catch {
                SolutionLabel.Text = "No answer was found.";
            }
        }

        protected void ReportQuestionButton_Click(object sender, EventArgs e) {
            
            // attempt to send question report back to the data tier
            try {
                ReportedReasonList.Enabled = false;
                ReportDescription.Enabled = false;
                ReportQuestionButton.Enabled = false;

                Business.ReportedQuestion.InsertReportedQuestion((long)this.RetrieveQuestionId(), 
                    (long)this.RetrieveUserId(), Convert.ToInt32(ReportedReasonList.SelectedValue), 
                    ReportDescription.Text);

                ReportSuccessLabel.Visible = true;
            } catch {
                ErrorLabel.Visible = true;
            }
        }

        protected void FeedbackButton_Click(object sender, EventArgs e) {
            
            // attempt to send feedback to the data tier
            try {
                LikedCheckBox.Enabled = false;
                AdjectiveList.Enabled = false;
                FeedbackButton.Enabled = false;

                Business.QuestionFeedback.InsertQuestionFeedback((long)this.RetrieveQuestionId(), 
                    (long)this.RetrieveUserId(), LikedCheckBox.Checked, AdjectiveList.SelectedValue);

                FeedbackSuccessLabel.Visible = true;
            } catch {
                ErrorLabelFeedback.Visible = true;
            }
        }

        protected void HintRepeater_PreRender(object sender, EventArgs e) {            

            if (!IsPostBack) {
                
                // retrieve page state information
                long? userAnswerId = this.RetrieveUserAnswerId();
                long? userId = this.RetrieveUserId();

                // populate hints seach of web form for answer
                if (userAnswerId != null) {

                    // populate hints section
                    Data.EducationOverflow.OrderHintsForUserAnswerDataTable hintsTable =
                        Business.OrderHintsForUserAnswer.SelectHintsForUserAnswer((long)userId, (long)userAnswerId);

                    RepeaterItemCollection repeaterItems = HintRepeater.Items;

                    // determine which repeater items must be visible (i.e. which hints are shown).
                    RepeaterItem currentRepeaterItem;
                    for (int i = 0; i < hintsTable.Rows.Count; i++) {
                        currentRepeaterItem = repeaterItems[i];
                        Control hintContainer = currentRepeaterItem.FindControl("HintContainer");

                        long apiAnswerId = Convert.ToInt64(
                            ((HiddenField)hintContainer.FindControl("APIAnswerIdField")).Value
                        );
                        long usedHintRowApiId =
                            ((Data.EducationOverflow.OrderHintsForUserAnswerRow)hintsTable.Rows[i]).APIAnswerId;

                        if (apiAnswerId == usedHintRowApiId) {
                            hintContainer.Visible = true;
                        }
                    }
                }
            }
        }

        // Helper Methods

        /// <summary>
        /// Retrieve the id for the current user.
        /// </summary>
        /// <returns>The id for the current user.</returns>
        private long? RetrieveUserId() {
            long? userId = null;
            
            System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();
            if (user != null) {
                userId = Convert.ToInt64(user.ProviderUserKey);
            }

            return userId;
        }

        /// <summary>
        /// Retrieve the question id for the page.
        /// </summary>
        /// <returns>The question id.</returns>
        private long? RetrieveQuestionId() {
            const string QUESTION_ID_PARAMETER = "QuestionId";
            long? questionId = null;

            string retrievedQuestionId = Request.QueryString[QUESTION_ID_PARAMETER];
            if (retrievedQuestionId != null) {
                questionId = Convert.ToInt64(retrievedQuestionId);
            }

            return questionId;
        }

        /// <summary>
        /// Retrieve the answer id for the page.
        /// </summary>
        /// <returns>The user's answer id.</returns>
        /// <remarks>
        /// A user answer id does not need to be included to the query for this page.
        /// </remarks>
        private long? RetrieveUserAnswerId() {
            const string USER_ANSWER_ID_PARAMETER = "AnswerId";
            long? userAnswerId = null;

            string retrievedId = Request.QueryString[USER_ANSWER_ID_PARAMETER];
            if (retrievedId != null) {
                userAnswerId = Convert.ToInt64(retrievedId);
            }

            return userAnswerId;
        }
    }
}