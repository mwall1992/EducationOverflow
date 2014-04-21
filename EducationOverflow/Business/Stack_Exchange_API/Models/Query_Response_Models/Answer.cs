using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class Answer {

        [DataMember(Name = "answer_id")]
        public Int32 answerId;

        [DataMember(Name = "question_id")]
        public Int32 questionId;

        [DataMember(Name = "is_accepted")]
        public bool isAccepted;

        [DataMember(Name = "up_vote_count")]
        public Int32 upVoteCount;

        [DataMember(Name = "down_vote_count")]
        public Int32 downVoteCount;

        [DataMember(Name = "body")]
        public String body;

        [DataMember(Name = "community_owned_date")]
        public Int64 communityOwnedDate;

        [DataMember(Name = "creation_date")]
        public Int64 creationDate;

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetDefaults();
        }

        public Answer() {
            this.SetDefaults();
        }

        private void SetDefaults() {
            this.answerId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.questionId = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.isAccepted = StackExchangeAPI.DEFAULT_BOOL_VALUE;
            this.upVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.downVoteCount = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.body = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.communityOwnedDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
            this.creationDate = StackExchangeAPI.DEFAULT_DATE_VALUE;
        }
    }
}
