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
            string queryURL = string.Format("{0}{1}?", this.GetBaseQueryURL(), this.apiMethod);

            if (this.siteParameter != null) {
                queryURL = queryURL + string.Format("site={0}&", this.siteParameter);
            }

            return new StackExchangeAPIQuery<SiteInfo>(queryURL);
        }

        public override void Reset() {
            base.Reset();
        }
    }
}
