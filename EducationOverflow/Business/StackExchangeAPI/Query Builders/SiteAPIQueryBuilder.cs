﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SiteAPIQueryBuilder : StackExchangeAPIQueryBuilder<Site, SiteAPIQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "sites";

        protected Page page;

        public SiteAPIQueryBuilder() {
            this.apiMethod = DEFAULT_API_METHOD_NAME;
        }

        public override IQuery<Site> GetQuery() {
            string queryURL = string.Format("{0}{1}?", this.GetBaseQueryURL(), DEFAULT_API_METHOD_NAME);

            if (this.page != null) {
                queryURL = string.Format("{0}{1}&", queryURL, this.page.ToString());
            }

            if (this.filter != null) {
                queryURL = string.Concat(queryURL, this.GetFilterString());
            }

            return new StackExchangeAPIQuery<Site>(queryURL);
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
