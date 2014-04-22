using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class Answer {

        [DataMember(Name = "answer_id")]
        public Int32 answerId;

        [DataMember(Name = "body")]
        public String body;

        [DataMember(Name = "body_markdown")]
        public string bodyWithMarkdown;

        [DataMember(Name = "can_flag")]
        public bool canFlag;

        [DataMember(Name = "comment_count")]
        public Int32 commentCount;

        [DataMember(Name = "community_owned_date")]
        public Int64 communityOwnedDate;

        [DataMember(Name = "creation_date")]
        public Int64 creationDate;

        [DataMember(Name = "down_vote_count")]
        public Int32 downVoteCount;

        [DataMember(Name = "is_accepted")]
        public bool isAccepted;

        [DataMember(Name = "last_activity_date")]
        public Int64 lastActivityDate;

        [DataMember(Name = "last_edit_date")]
        public Int64 lastEditDate;

        [DataMember(Name = "link")]
        public string url;

        [DataMember(Name = "locked_date")]
        public Int64 lockedDate;

        [DataMember(Name = "question_id")]
        public Int32 questionId;

        [DataMember(Name = "score")]
        public Int32 score;

        [DataMember(Name = "share_link")]
        public string shareUrl;

        [DataMember(Name = "tags")]
        public string[] tags;

        [DataMember(Name = "title")]
        public string title;

        [DataMember(Name = "up_vote_count")]
        public Int32 upVoteCount;

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
            this.answerId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.body = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.bodyWithMarkdown = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.canFlag = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.commentCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.communityOwnedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.creationDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.downVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.isAccepted = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.lastActivityDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.lastEditDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.url = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.lockedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.questionId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.score = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.shareUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.tags = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.title = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.upVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
        }
    }
}
