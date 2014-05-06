using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SiteQueryBuilder : StackExchangeAPIQueryBuilder<Site, SiteQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "sites";

        protected Page page;

        public SiteQueryBuilder() {
            this.SetAPIMethod(DEFAULT_API_METHOD_NAME);
        }

        public override IQuery<Site> GetQuery() {
            string queryURL = this.GetBaseQueryUrl();

            if (this.page != null) {
                queryURL = string.Format("{0}{1}&", queryURL, this.page.ToString());
            }

            return new StackExchangeAPIQuery<Site>(queryURL);
        }

        public override void Reset() {
            base.Reset();
            this.page = null;
        }

        public SiteQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }
    }
}
