using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {
    
    [DataObject]
    public class QuestionFeedbackSummary {

        private bool liked;
        [DataObjectField(false)]
        public bool Liked {
            get {
                return this.liked;
            }

            set {
                this.liked = value;
            }
        }

        private string summaryAdjective;
        [DataObjectField(false)]
        public string SummaryAdjective {
            get {
                return this.summaryAdjective;
            }

            set {
                this.summaryAdjective = value;
            }
        }

        private long userId;
        [DataObjectField(true)]
        public long UserId {
            get {
                return this.userId;
            }

            set {
                this.userId = value;
            }
        }

        private string firstName;
        [DataObjectField(false)]
        public string FirstName {
            get {
                return this.firstName;
            }

            set {
                this.firstName = value;
            }
        }

        private string lastName;
        [DataObjectField(false)]
        public string LastName {
            get {
                return this.lastName;
            }

            set {
                this.lastName = value;
            }
        }

        private string apiSiteParameter;
        [DataObjectField(false)]
        public string ApiSiteParameter {
            get {
                return this.apiSiteParameter;
            }

            set {
                this.apiSiteParameter = value;
            }
        }

        private string questionTitle;
        [DataObjectField(false)]
        public string QuestionTitle {
            get {
                return this.questionTitle;
            }

            set {
                this.questionTitle = value;
            }
        }

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
    }
}
