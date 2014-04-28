using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {
    
    [DataContract]
    public class Question {

        [DataMember(Name = "accepted_answer_id")]
        public Int32 AcceptedAnswerId { get; set; }

        [DataMember(Name = "answer_count")]
        public Int32 AnswerCount { get; set; }

        [DataMember(Name = "answers")]
        public Answer[] Answers { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "body_markdown")]
        public string BodyWithMarkdown { get; set; }

        [DataMember(Name = "bounty_amount")]
        public Int32 BountyAmount { get; set; }

        [DataMember(Name = "bounty_closes_date")]
        public Int64 BountyClosesDate { get; set; }

        [DataMember(Name = "can_close")]
        public bool CanClose { get; set; }

        [DataMember(Name = "can_flag")]
        public bool CanFlag { get; set; }

        [DataMember(Name = "close_vote_count")]
        public Int32 CloseVoteCount { get; set; }

        [DataMember(Name = "closed_date")]
        public Int64 ClosedDate { get; set; }

        [DataMember(Name = "closed_reason")]
        public string ClosedReason { get; set; }

        [DataMember(Name = "community_owned_date")]
        public Int64 CommunityOwnedDate { get; set; }

        [DataMember(Name = "creation_date")]
        public Int64 CreationDate { get; set; }

        [DataMember(Name = "delete_vote_count")]
        public Int32 DeleteVoteCount { get; set; }

        [DataMember(Name = "down_vote_count")]
        public Int32 DownVoteCount { get; set; }

        [DataMember(Name = "favorite_count")]
        public Int32 FavouriteCount { get; set; }

        [DataMember(Name = "is_answered")]
        public bool IsAnswered { get; set; }

        [DataMember(Name = "last_activity_date")]
        public Int64 LastActivityDate { get; set; }

        [DataMember(Name = "last_edit_date")]
        public Int64 LastEditDate { get; set; }

        [DataMember(Name = "link")]
        public string Url { get; set; }

        [DataMember(Name = "locked_date")]
        public Int64 LockedDate { get; set; }

        [DataMember(Name = "protected_date")]
        public Int64 ProtectedDate { get; set; }

        [DataMember(Name = "question_id")]
        public Int32 QuestionId { get; set; }

        [DataMember(Name = "reopen_vote_count ")]
        public Int32 ReopenVoteCount { get; set; }

        [DataMember(Name = "score")]
        public Int32 Score { get; set; }

        [DataMember(Name = "share_link")]
        public string ShareUrl { get; set; }

        [DataMember(Name = "tags")]
        public string[] Tags { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "up_vote_count")]
        public Int32 UpVoteCount { get; set; }

        [DataMember(Name = "view_count")]
        public Int32 ViewCount { get; set; }

        public Question() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        private void SetPlaceholderValues() {
            this.AcceptedAnswerId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.AnswerCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.Body = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.BodyWithMarkdown = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.BountyAmount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.BountyClosesDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.CanClose = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.CanFlag = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.ClosedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.ClosedReason = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.CloseVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.CommunityOwnedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.CreationDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.DeleteVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.DownVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.FavouriteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.IsAnswered = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.LastActivityDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.LastEditDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.LockedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.ProtectedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.QuestionId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.ReopenVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.Score = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.ShareUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.Tags = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.Title = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.UpVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.Url = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.ViewCount = StackExchangeAPI.DEFAULT_INT_VALUE;
        }
    }
}
