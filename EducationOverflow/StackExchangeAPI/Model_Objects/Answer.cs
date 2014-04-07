using System;
using System.Runtime.Serialization;

namespace StackExchangeAPI {

    [DataContract]
    public class Answer {

        [DataMember]
        private int answer_id = StackExchangeAPI.DEFAULT_INT_VALUE;

        [DataMember]
        private int question_id = StackExchangeAPI.DEFAULT_INT_VALUE;

        [DataMember]
        private bool is_accepted = StackExchangeAPI.DEFAULT_BOOL_VALUE;

        [DataMember]
        private int up_vote_count = StackExchangeAPI.DEFAULT_INT_VALUE;

        [DataMember]
        private int down_vote_count = StackExchangeAPI.DEFAULT_INT_VALUE;

        [DataMember]
        private String body = StackExchangeAPI.DEFAULT_STRING_VALUE;

        public int AnswerId {
            get {
                return this.answer_id;
            }
        }

        public int QuestionId {
            get {
                return this.question_id;
            }
        }

        public bool IsAccepted {
            get {
                return this.is_accepted;
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

        public String Body {
            get {
                return this.body;
            }
        }
    }
}
