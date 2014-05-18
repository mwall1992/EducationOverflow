using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {
    
    [DataObject]
    public class UserIdentifier {

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

        private string username;
        [DataObjectField(false)]
        public string Username {
            get {
                return this.username;
            }

            set {
                this.username = value;
            }
        }
    }
}
