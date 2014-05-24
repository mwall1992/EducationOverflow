using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A concrete builder for queries to the Stack Exchange API which return tag objects.
    /// For more information on 'tag objects', consider the Stack Exchange API documentation:
    /// http://api.stackexchange.com/docs/types/info
    /// </summary>
    public class SiteInfoQueryBuilder : StackExchangeSiteQueryBuilder<SiteInfo, SiteInfoQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "info";
        
        /// <summary>
        /// Construct a site info query builder.
        /// </summary>
        public SiteInfoQueryBuilder() {
            this.SetAPIMethod(DEFAULT_API_METHOD_NAME);
        }

        public override IQuery<SiteInfo> GetQuery() {
            return new StackExchangeAPIQuery<SiteInfo>(this.GetBaseQueryUrl());
        }
    }
}
