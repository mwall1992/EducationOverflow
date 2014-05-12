using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {
    
    [DataObject]
    public class QuestionSummary {

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

        private int likes;
        [DataObjectField(false)]
        public int Likes {
            get {
                return this.likes;
            }

            set {
                this.likes = value;
            }
        }

        private int dislikes;
        [DataObjectField(false)]
        public int Dislikes {
            get {
                return this.dislikes;
            }

            set {
                this.dislikes = value;
            }
        }

        private string mostCommonSummaryAdjective;
        [DataObjectField(false)]
        public string MostCommonSummaryAdjective {
            get {
                return this.mostCommonSummaryAdjective;
            }

            set {
                this.mostCommonSummaryAdjective = value;
            }
        }
    }
}
