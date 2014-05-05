using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {

    [DataObject]
    public class Answer {

        private string questionURL;
        [DataObjectField(true)]
        public string QuestionURL {
            get {
                return this.questionURL;
            }

            set {
                this.questionURL = value;
            }
        }

        private int apiAnswerId;
        [DataObjectField(true)]
        public int ApiAnswerId {
            get {
                return this.apiAnswerId;
            }

            set {
                this.apiAnswerId = value;
            }
        }

        private string body;
        [DataObjectField(false)]
        public string Body {
            get {
                return this.body;
            }

            set {
                this.body = value;
            }
        }

        private int downVotes;
        [DataObjectField(false)]
        public int DownVotes {
            get {
                return this.downVotes;
            }

            set {
                this.downVotes = value;
            }
        }

        private int upVotes;
        [DataObjectField(false)]
        public int UpVotes {
            get {
                return this.upVotes;
            }

            set {
                this.upVotes = value;
            }
        }

        private bool isAccepted;
        [DataObjectField(false)]
        public bool IsAccepted {
            get {
                return this.isAccepted;
            }

            set {
                this.isAccepted = value;
            }
        }
    }
}
