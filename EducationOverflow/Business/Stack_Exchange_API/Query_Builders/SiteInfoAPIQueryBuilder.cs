using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SiteInfoAPIQueryBuilder : StackExchangeAPIQueryBuilder<SiteInfo> {

        private static string API_METHOD_NAME = "info";

        public SiteInfoAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override IQuery<SiteInfo> GetQuery() {
            return new StackExchangeAPIQuery<SiteInfo>(null);
        }

        public override void Reset() {
            base.Reset();
        }
    }
}
