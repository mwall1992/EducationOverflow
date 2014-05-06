using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {

    public abstract class StackExchangeSiteQueryBuilder<T, V> : StackExchangeAPIQueryBuilder<T, V> 
    where T : class
    where V : StackExchangeSiteQueryBuilder<T, V> {

        private string siteParameter;

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

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

        public V SetSite(string siteParameter) {
            this.siteParameter = HttpUtility.UrlEncode(siteParameter);
            return (V)this;
        }

        public V SetPage(Page page) {
            this.page = page;
            return (V)this;
        }

        public V SetCreationDateRange(SortState<Int64> dateRange) {
            this.creationDateRange = dateRange;
            return (V)this;
        }

        public V SetCreationDateOrdering(Ordering ordering) {
            this.creationDateOrdering = ordering;
            return (V)this;
        }

        public V SetSort(INamedSortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return (V)this;
        }
    }
}
