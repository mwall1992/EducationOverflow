using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    /// <summary>
    /// A concrete builder for queries to the Stack Exchange API which return site objects.
    /// For more information on 'site objects', consider the Stack Exchange API documentation:
    /// http://api.stackexchange.com/docs/types/site
    /// </summary>
    public class SiteQueryBuilder : StackExchangeAPIQueryBuilder<Site, SiteQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "sites";

        /// <summary>
        /// The page parameter applied to the query.
        /// </summary>
        protected Page page;

        /// <summary>
        /// Construct a site query builder.
        /// </summary>
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

        /// <summary>
        /// Set the page parameter for the query.
        /// </summary>
        /// <param name="page">The page parameter.</param>
        /// <returns>The updated query builder.</returns>
        public SiteQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }
    }
}
