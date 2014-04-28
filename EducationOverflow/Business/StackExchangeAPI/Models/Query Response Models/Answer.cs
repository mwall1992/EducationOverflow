using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class Answer {

        [DataMember(Name = "answer_id")]
        public Int32 AnswerId { get; set; }

        [DataMember(Name = "body")]
        public String Body { get; set; }

        [DataMember(Name = "body_markdown")]
        public string BodyWithMarkdown { get; set; }

        [DataMember(Name = "can_flag")]
        public bool CanFlag { get; set; }

        [DataMember(Name = "comment_count")]
        public Int32 CommentCount { get; set; }

        [DataMember(Name = "community_owned_date")]
        public Int64 CommunityOwnedDate { get; set; }

        [DataMember(Name = "creation_date")]
        public Int64 CreationDate { get; set; }

        [DataMember(Name = "down_vote_count")]
        public Int32 DownVoteCount { get; set; }

        [DataMember(Name = "is_accepted")]
        public bool IsAccepted { get; set; }

        [DataMember(Name = "last_activity_date")]
        public Int64 LastActivityDate { get; set; }

        [DataMember(Name = "last_edit_date")]
        public Int64 LastEditDate { get; set; }

        [DataMember(Name = "link")]
        public string Url { get; set; }

        [DataMember(Name = "locked_date")]
        public Int64 LockedDate { get; set; }

        [DataMember(Name = "question_id")]
        public Int32 QuestionId { get; set; }

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

        public Answer() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }
        
        // Helper Methods

        private void SetPlaceholderValues() {
            this.AnswerId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.Body = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.BodyWithMarkdown = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.CanFlag = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.CommentCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.CommunityOwnedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.CreationDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.DownVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.IsAccepted = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.LastActivityDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.LastEditDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.Url = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.LockedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.QuestionId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.Score = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.ShareUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.Tags = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.Title = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.UpVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
        }
    }
}
