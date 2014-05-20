﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {

    [DataObject]
    public class Answer {

        private long questionId;
        [DataObjectField(true)]
        public long QuestionId {
            get {
                return this.questionId;
            }

            set {
                this.questionId = value;
            }
        }

        private long apiAnswerId;
        [DataObjectField(true)]
        public long ApiAnswerId {
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
