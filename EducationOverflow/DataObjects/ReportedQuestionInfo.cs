using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {
    
    [DataObject]
    public class ReportedQuestionInfo {

        private string optionalDescription;
        [DataObjectField(false)]
        public string OptionalDescription {
            get {
                return this.optionalDescription;
            }

            set {
                this.optionalDescription = value;
            }
        }

        private string predefinedDescription;
        [DataObjectField(false)]
        public string PredefinedDescription {
            get {
                return this.predefinedDescription;
            }

            set {
                this.predefinedDescription = value;
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

        private string siteName;
        [DataObjectField(false)]
        public string SiteName {
            get {
                return this.siteName;
            }

            set {
                this.siteName = value;
            }
        }

        private string url;
        [DataObjectField(false)]
        public string Url {
            get {
                return this.url;
            }

            set {
                this.url = value;
            }
        }
    }
}
