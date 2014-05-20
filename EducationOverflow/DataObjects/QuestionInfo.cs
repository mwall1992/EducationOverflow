using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {

    [DataObject]
    public class QuestionInfo {

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
    }
}
