using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SiteAPIQueryBuilder : StackExchangeAPIQueryBuilder {

        private static string API_METHOD_NAME = "sites";

        protected Page page;

        public SiteAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override StackExchangeAPIQuery GetQuery() {
            return new StackExchangeAPIQuery(null, typeof(Site));
        }

        public override void Reset() {
            base.Reset();
            this.page = null;
        }

        public SiteAPIQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }
    }
}
