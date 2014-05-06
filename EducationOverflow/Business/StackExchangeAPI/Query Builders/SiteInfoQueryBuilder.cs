using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SiteInfoQueryBuilder : StackExchangeSiteQueryBuilder<SiteInfo, SiteInfoQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "info";

        public SiteInfoQueryBuilder() {
            this.SetAPIMethod(DEFAULT_API_METHOD_NAME);
        }

        public override IQuery<SiteInfo> GetQuery() {
            return new StackExchangeAPIQuery<SiteInfo>(this.GetBaseQueryUrl());
        }
    }
}
