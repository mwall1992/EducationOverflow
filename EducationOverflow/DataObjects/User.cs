using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {

    [DataObject]
    public class User {

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

        private System.DateTime dateOfBirth;
        [DataObjectField(false)]
        public System.DateTime DateOfBirth {
            get {
                return this.dateOfBirth;
            }

            set {
                this.dateOfBirth = value;
            }
        }
    }
}
