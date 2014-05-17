using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DataObjects {

    [DataObject]
    public class Role {

        private string name;
        [DataObjectField(true)]
        public string Name {
            get {
                return this.name;
            }

            set {
                this.name = value;
            }
        }

        private string description;
        [DataObjectField(false)]
        public string Description {
            get {
                return this.description;
            }

            set {
                this.description = value;
            }
        }
    }
}
