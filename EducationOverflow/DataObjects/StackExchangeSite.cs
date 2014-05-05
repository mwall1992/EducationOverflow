using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects {

    [System.ComponentModel.DataObject]
    public class StackExchangeSite {
        
        private string apiSiteParameter;

        private string name;

        private int totalAcceptedAnswers;

        [System.ComponentModel.DataObjectField(true)]
        public string APISiteParameter {
            get {
                return this.apiSiteParameter;
            }

            set {
                this.apiSiteParameter = value;
            }
        }

        [System.ComponentModel.DataObjectField(false)]
        public string Name {
            get {
                return this.name;
            }

            set {
                this.name = value;
            }
        }

        [System.ComponentModel.DataObjectField(false)]
        public int TotalAcceptedAnswers {
            get {
                return this.totalAcceptedAnswers;
            }

            set {
                this.totalAcceptedAnswers = value;
            }
        }
    }
}
