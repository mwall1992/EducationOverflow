using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    public class StackExchangeAPIQuery<T> : IQuery<T> where T : class {
        
        private string queryUrl;

        public StackExchangeAPIQuery(string queryUrl) {
            this.queryUrl = queryUrl;
        }

        public string GetURL() {
            return this.queryUrl;
        }

        public void SetURL(string url) {
            this.queryUrl = url;
        }
    }
}
