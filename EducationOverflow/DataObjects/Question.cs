using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {
    
    [DataObject]
    public class Question {
        
        private string url;
        [DataObjectField(true)]
        public string URL {
            get {
                return this.url;
            }

            set {
                this.url = value;
            }
        }

        private int apiQuestionId;
        [DataObjectField(false)]
        public int ApiQuestionId {
            get {
                return this.apiQuestionId;
            }

            set {
                this.apiQuestionId = value;
            }
        }

        private string title;
        [DataObjectField(false)]
        public string Title {
            get {
                return this.title;
            }

            set {
                this.title = value;
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

        private string upVotes;
        [DataObjectField(false)]
        public string UpVotes {
            get {
                return this.upVotes;
            }

            set {
                this.upVotes = value;
            }
        }

        private string downVotes;
        [DataObjectField(false)]
        public string DownVotes {
            get {
                return this.downVotes;
            }

            set {
                this.downVotes = value;
            }
        }
    }
}
