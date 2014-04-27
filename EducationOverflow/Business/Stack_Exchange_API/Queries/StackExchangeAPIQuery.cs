using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class StackExchangeAPIQuery : IQuery {
        
        private string queryUrl;

        private Type responseModelType;

        public StackExchangeAPIQuery(string queryUrl, Type modelType) {
            this.queryUrl = queryUrl;
            this.responseModelType = modelType;
        }

        public string GetURL() {
            return this.queryUrl;
        }

        public void SetURL(string url) {
            this.queryUrl = url;
        }

        public Type ResponseModelType {
            get {
                return this.responseModelType;
            }

            set {
                this.responseModelType = value;
            }
        }
    }
}
