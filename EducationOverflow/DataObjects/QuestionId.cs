using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {

    [DataObject]
    public class QuestionId {

        private long id;
        [DataObjectField(true)]
        public long Id {
            get {
                return this.id;
            }

            set {
                this.id = value;
            }
        }

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

        private long apiQuestionId;
        [DataObjectField(false)]
        public long ApiQuestionId {
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
    }
}
