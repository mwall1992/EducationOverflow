using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {

    /// <summary>
    /// An abstract builder for site-based queries to the Stack Exchange servers. This class
    /// has a fluent interface.
    /// </summary>
    /// <typeparam name="T">The model class used for storing response data to the query.</typeparam>
    /// <typeparam name="V">The class.</typeparam>
    /// <remarks>
    /// The 'V' generic parameter is required for a fluent interface to ensure subclasses
    /// return their own class type.
    /// </remarks>
    public abstract class StackExchangeSiteQueryBuilder<T, V> : StackExchangeAPIQueryBuilder<T, V> 
    where T : class
    where V : StackExchangeSiteQueryBuilder<T, V> {

        /// <summary>
        /// The site parameter applied to the query.
        /// </summary>
        private string siteParameter;

        /// <summary>
        /// The page parameter applied to the query.
        /// </summary>
        protected Page page;

        /// <summary>
        /// The creation date range applied to the entity retrieved by the query.
        /// </summary>
        protected ISortState creationDateRange;

        /// <summary>
        /// The ordering applied to the creation date.
        /// </summary>
        protected Ordering creationDateOrdering;

        /// <summary>
        /// The named sort state applied to the query.
        /// </summary>
        protected INamedSortState sortCriteria;

        protected override string GetBaseQueryUrl() {
            string queryUrl = base.GetBaseQueryUrl();

            if (this.page != null) {
                queryUrl = string.Format("{0}{1}&", queryUrl, this.page.ToString());
            }

            if (this.creationDateRange != null) {
                if (this.creationDateRange.MinBound != null) {
                    queryUrl = string.Format("{0}fromdate={1}&", queryUrl, this.creationDateRange.MinBound);
                }

                if (this.creationDateRange.MaxBound != null) {
                    queryUrl = string.Format("{0}todate={1}&", queryUrl, this.creationDateRange.MaxBound);
                }
            }

            if (this.creationDateOrdering == Ordering.DESCENDING) {
                queryUrl = queryUrl + "order=desc&";
            } else if (this.creationDateOrdering == Ordering.ASCENDING) {
                queryUrl = queryUrl + "order=asc&";
            }

            if (this.sortCriteria != null) {
                queryUrl = string.Format("{0}sort={1}&", queryUrl, this.sortCriteria.Name);

                if (this.sortCriteria.MinBound != null) {
                    queryUrl = string.Format("{0}min={1}&", queryUrl, this.sortCriteria.MinBound);
                }

                if (this.sortCriteria.MaxBound != null) {
                    queryUrl = string.Format("{0}max={1}&", queryUrl, this.sortCriteria.MaxBound);
                }
            }

            if (this.siteParameter != null) {
                queryUrl = string.Format("{0}site={1}&", queryUrl, this.siteParameter);
            }

            return queryUrl;
        }

        public override void Reset() {
            base.Reset();
            this.siteParameter = null;
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Ordering.DESCENDING;
            this.sortCriteria = null;
        }

        /// <summary>
        /// Set the site of the query.
        /// </summary>
        /// <param name="siteParameter">The site parameter.</param>
        /// <returns>The updated query builder.</returns>
        /// <remarks>
        /// Site-based queries require a site parameter. See the Stack 
        /// Exchange API documentation for more information:
        /// http://api.stackexchange.com/docs
        /// </remarks>
        public V SetSite(string siteParameter) {
            this.siteParameter = HttpUtility.UrlEncode(siteParameter);
            return (V)this;
        }

        /// <summary>
        /// Set the page of the query.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns>The updated query builder.</returns>
        public V SetPage(Page page) {
            this.page = page;
            return (V)this;
        }

        /// <summary>
        /// Set the creation date range of the entity retrieved by the query.
        /// </summary>
        /// <param name="dateRange">The creation date range.</param>
        /// <returns>The updated query builder.</returns>
        public V SetCreationDateRange(SortState<Int64> dateRange) {
            this.creationDateRange = dateRange;
            return (V)this;
        }

        /// <summary>
        /// Set the ordering applied to the creation date range of the entity
        /// retrieved by the query.
        /// </summary>
        /// <param name="ordering">The creation date ordering.</param>
        /// <returns>The updated query builder.</returns>
        public V SetCreationDateOrdering(Ordering ordering) {
            this.creationDateOrdering = ordering;
            return (V)this;
        }

        /// <summary>
        /// Set a named sort state for the query.
        /// </summary>
        /// <param name="sortCriteria">The named sort state.</param>
        /// <returns>The updated query builder.</returns>
        /// <remarks>Each query can have only one named sort state at most.</remarks>
        public V SetSort(INamedSortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return (V)this;
        }
    }
}
