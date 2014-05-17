using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {

    [DataObject]
    public class UserMembershipInfo {

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

        private string applicationName;
        [DataObjectField(false)]
        public string ApplicationName {
            get {
                return this.applicationName;
            }

            set {
                this.applicationName = value;
            }
        }

        private string email;
        [DataObjectField(false)]
        public string Email {
            get {
                return this.email;
            }

            set {
                this.email = value;
            }
        }

        private bool isLocked;
        [DataObjectField(false)]
        public bool IsLocked {
            get {
                return this.isLocked;
            }

            set {
                this.isLocked = value;
            }
        }

        private DateTime lastActivityDate;
        [DataObjectField(false)]
        public DateTime LastActivityDate {
            get {
                return this.lastActivityDate;
            }

            set {
                this.lastActivityDate = value;
            }
        }
    }
}
