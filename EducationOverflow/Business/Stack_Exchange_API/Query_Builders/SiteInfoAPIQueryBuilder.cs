using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SiteInfoAPIQueryBuilder : StackExchangeAPIQueryBuilder {

        private static string API_METHOD_NAME = "info";

        public SiteInfoAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override StackExchangeAPIQuery GetQuery() {
            return new StackExchangeAPIQuery(null, typeof(SiteInfo));
        }

        public override void Reset() {
            base.Reset();
        }
    }
}
