using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {
    
    [DataContract]
    public class Question {

        [DataMember(Name = "accepted_answer_id")]
        public Int32 acceptedAnswerId;

        [DataMember(Name = "answer_count")]
        public Int32 answerCount;

        [DataMember(Name = "body")]
        public string body;

        [DataMember(Name = "body_markdown")]
        public string bodyWithMarkdown;

        [DataMember(Name = "bounty_amount")]
        public Int32 bountyAmount;

        [DataMember(Name = "bounty_closes_date")]
        public Int64 bountyClosesDate;

        [DataMember(Name = "can_close")]
        public bool canClose;

        [DataMember(Name = "can_flag")]
        public bool canFlag;

        [DataMember(Name = "close_vote_count")]
        public Int32 closeVoteCount;

        [DataMember(Name = "closed_date")]
        public Int64 closedDate;

        [DataMember(Name = "closed_reason")]
        public string closedReason;

        [DataMember(Name = "community_owned_date")]
        public Int64 communityOwnedDate;

        [DataMember(Name = "creation_date")]
        public Int64 creationDate;

        [DataMember(Name = "delete_vote_count")]
        public Int32 deleteVoteCount;

        [DataMember(Name = "down_vote_count")]
        public Int32 downVoteCount;

        [DataMember(Name = "favorite_count")]
        public Int32 favouriteCount;

        [DataMember(Name = "is_answered")]
        public bool isAnswered;

        [DataMember(Name = "last_activity_date")]
        public Int64 lastActivityDate;

        [DataMember(Name = "last_edit_date")]
        public Int64 lastEditDate;

        [DataMember(Name = "link")]
        public string url;

        [DataMember(Name = "locked_date")]
        public Int64 lockedDate;

        [DataMember(Name = "protected_date")]
        public Int64 protectedDate;

        [DataMember(Name = "question_id")]
        public Int32 questionId;

        [DataMember(Name = "reopen_vote_count ")]
        public Int32 reopenVoteCount;

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

        [DataMember(Name = "view_count")]
        public Int32 viewCount;

        public Question() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        private void SetPlaceholderValues() {
            this.acceptedAnswerId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.answerCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.body = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.bodyWithMarkdown = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.bountyAmount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.bountyClosesDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.canClose = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.canFlag = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.closedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.closedReason = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.closeVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.communityOwnedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.creationDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.deleteVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.downVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.favouriteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.isAnswered = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.lastActivityDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.lastEditDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.lockedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.protectedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.questionId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.reopenVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.score = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.shareUrl = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.tags = (string[])StackExchangeAPI.DEFAULT_OBJ_VALUE;
            this.title = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.upVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.url = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.viewCount = StackExchangeAPI.DEFAULT_INT_VALUE;
        }
    }
}
