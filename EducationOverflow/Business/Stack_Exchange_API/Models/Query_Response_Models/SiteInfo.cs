using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class SiteInfo {

        [DataMember(Name = "answers_per_minute")]
        public double answersPerMinute;

        [DataMember(Name = "api_revision")]
        public string apiRevision;

        [DataMember(Name = "badges_per_minute")]
        public double badgesPerMinute;

        [DataMember(Name = "new_active_users")]
        public Int32 newActiveUsers;

        [DataMember(Name = "questions_per_minute")]
        public double questionsPerMinute;

        [DataMember(Name = "total_accepted")]
        public Int32 totalAccepted;

        [DataMember(Name = "total_answers")]
        public Int32 totalAnswers;

        [DataMember(Name = "total_badges")]
        public Int32 totalBadges;

        [DataMember(Name = "total_comments")]
        public Int32 totalComments;

        [DataMember(Name = "total_questions")]
        public Int32 totalQuestions;

        [DataMember(Name = "total_unanswered")]
        public Int32 totalUnanswered;

        [DataMember(Name = "total_users")]
        public Int32 totalUsers;

        [DataMember(Name = "total_votes")]
        public Int32 totalVotes;

        public SiteInfo() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        private void SetPlaceholderValues() {
            this.answersPerMinute = StackExchangeAPI.DEFAULT_DOUBLE_VALUE;
            this.apiRevision = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.badgesPerMinute = StackExchangeAPI.DEFAULT_DOUBLE_VALUE;
            this.newActiveUsers = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.questionsPerMinute = StackExchangeAPI.DEFAULT_DOUBLE_VALUE;
            this.totalAccepted = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.totalAnswers = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.totalBadges = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.totalComments = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.totalQuestions = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.totalUnanswered = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.totalUsers = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.totalVotes = StackExchangeAPI.DEFAULT_INT_VALUE;
        }
    }
}
