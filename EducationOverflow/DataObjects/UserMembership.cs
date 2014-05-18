using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {

    [DataObject]
    public class UserMembership {

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

        private bool? isApproved;
        [DataObjectField(false)]
        public bool? IsApproved {
            get {
                return this.isApproved;
            }

            set {
                this.isApproved = value;
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

        private DateTime? lastPasswordChangeDate;
        [DataObjectField(false)]
        public DateTime? LastPasswordChangeDate {
            get {
                return this.lastPasswordChangeDate;
            }

            set {
                this.lastPasswordChangeDate = value;
            }
        }

        private DateTime? creationDate;
        [DataObjectField(false)]
        public DateTime? CreationDate {
            get {
                return this.creationDate;
            }

            set {
                this.creationDate = value;
            }
        }

        private DateTime? lastLockedOutDate;
        [DataObjectField(false)]
        public DateTime? LastLockedOutDate {
            get {
                return this.lastLockedOutDate;
            }

            set {
                this.lastLockedOutDate = value;
            }
        }

        private string comment;
        [DataObjectField(false)]
        public string Comment {
            get {
                return this.comment;
            }

            set {
                this.comment = value;
            }
        }

        private string passwordQuestion;
        [DataObjectField(false)]
        public string PasswordQuestion {
            get {
                return this.passwordQuestion;
            }

            set {
                this.passwordQuestion = value;
            }
        }

        private string passwordAnswer;
        [DataObjectField(false)]
        public string PasswordAnswer {
            get {
                return this.passwordAnswer;
            }

            set {
                this.passwordAnswer = value;
            }
        }
    }
}
