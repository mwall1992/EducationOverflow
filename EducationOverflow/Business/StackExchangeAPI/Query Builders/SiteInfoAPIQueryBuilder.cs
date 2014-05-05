using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SiteInfoAPIQueryBuilder : StackExchangeAPIQueryBuilder<SiteInfo, SiteInfoAPIQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "info";

        public SiteInfoAPIQueryBuilder() {
            this.apiMethod = DEFAULT_API_METHOD_NAME;
        }

        public override IQuery<SiteInfo> GetQuery() {
            return new StackExchangeAPIQuery<SiteInfo>(null);
        }

        public override void Reset() {
            base.Reset();
        }
    }
}
