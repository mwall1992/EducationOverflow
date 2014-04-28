using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class SiteInfo {

        [DataMember(Name = "answers_per_minute")]
        public double AnswersPerMinute { get; set; }

        [DataMember(Name = "api_revision")]
        public string ApiRevision { get; set; }

        [DataMember(Name = "badges_per_minute")]
        public double BadgesPerMinute { get; set; }

        [DataMember(Name = "new_active_users")]
        public Int32 NewActiveUsers { get; set; }

        [DataMember(Name = "questions_per_minute")]
        public double QuestionsPerMinute { get; set; }

        [DataMember(Name = "total_accepted")]
        public Int32 TotalAccepted { get; set; }

        [DataMember(Name = "total_answers")]
        public Int32 TotalAnswers { get; set; }

        [DataMember(Name = "total_badges")]
        public Int32 TotalBadges { get; set; }

        [DataMember(Name = "total_comments")]
        public Int32 TotalComments { get; set; }

        [DataMember(Name = "total_questions")]
        public Int32 TotalQuestions { get; set; }

        [DataMember(Name = "total_unanswered")]
        public Int32 TotalUnanswered { get; set; }

        [DataMember(Name = "total_users")]
        public Int32 TotalUsers { get; set; }

        [DataMember(Name = "total_votes")]
        public Int32 TotalVotes { get; set; }

        public SiteInfo() {
            this.SetPlaceholderValues();
        }

        // N.B. the constructor is not called during deserialisation.

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context) {
            this.SetPlaceholderValues();
        }

        private void SetPlaceholderValues() {
            this.AnswersPerMinute = StackExchangeAPI.DEFAULT_DOUBLE_VALUE;
            this.ApiRevision = StackExchangeAPI.DEFAULT_STRING_VALUE;
            this.BadgesPerMinute = StackExchangeAPI.DEFAULT_DOUBLE_VALUE;
            this.NewActiveUsers = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.QuestionsPerMinute = StackExchangeAPI.DEFAULT_DOUBLE_VALUE;
            this.TotalAccepted = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.TotalAnswers = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.TotalBadges = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.TotalComments = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.TotalQuestions = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.TotalUnanswered = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.TotalUsers = StackExchangeAPI.DEFAULT_INT_VALUE;
            this.TotalVotes = StackExchangeAPI.DEFAULT_INT_VALUE;
        }
    }
}
