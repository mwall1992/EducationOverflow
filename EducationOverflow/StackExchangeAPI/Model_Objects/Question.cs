using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {
    
    [DataContract]
    public class Question {

        [DataMember]
        private int answer_count = StackExchangeAPI.DEFAULT_INT_VALUE;

        [DataMember]
        private int question_id = StackExchangeAPI.DEFAULT_INT_VALUE;

        [DataMember]
        private String body = StackExchangeAPI.DEFAULT_STRING_VALUE;

        [DataMember]
        private int up_vote_count = StackExchangeAPI.DEFAULT_INT_VALUE;

        [DataMember]
        private int down_vote_count = StackExchangeAPI.DEFAULT_INT_VALUE;

        [DataMember]
        private String title = StackExchangeAPI.DEFAULT_STRING_VALUE;

        public int AnswerCount {
            get {
                return this.answer_count;
            }
        }

        public int QuestionId {
            get {
                return this.question_id;
            }
        }

        public String Body {
            get {
                return this.body;
            }
        }

        public int UpVoteCount {
            get {
                return this.up_vote_count;
            }
        }

        public int DownVoteCount {
            get {
                return this.down_vote_count;
            }
        }

        public String Title {
            get {
                return this.title;
            }
        }
    }
}
