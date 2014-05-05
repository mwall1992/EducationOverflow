using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SimilarAPIQueryBuilder : StackExchangeAPIQueryBuilder<Question, SimilarAPIQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "similar";

        protected List<string> tagNames;

        protected List<string> ignoredTagNames;

        protected string title;

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

        protected INamedSortState sortCriteria;

        public SimilarAPIQueryBuilder() {
            this.apiMethod = DEFAULT_API_METHOD_NAME;
        }

        public override IQuery<Question> GetQuery() {
            string queryURL = string.Format("{0}{1}{2}?", this.GetBaseQueryURL(), this.apiMethod, this.apiMethodExtension);

            if (this.page != null) {
                queryURL = string.Format("{0}{1}&", queryURL, this.page.ToString());
            }

            if (this.creationDateRange != null) {
                if (this.creationDateRange.MinBound != null) {
                    queryURL = queryURL + string.Format("fromdate={0}&", this.creationDateRange.MinBound);
                }

                if (this.creationDateRange.MaxBound != null) {
                    queryURL = queryURL + string.Format("todate={0}&", this.creationDateRange.MaxBound);
                }
            }

            if (this.creationDateOrdering == Ordering.DESCENDING) {
                queryURL = queryURL + "order=desc&";
            } else if (this.creationDateOrdering == Ordering.ASCENDING) {
                queryURL = queryURL + "order=asc&";
            }

            if (this.sortCriteria != null) {
                queryURL = queryURL + string.Format("sort={0}&", this.sortCriteria.Name);

                if (this.sortCriteria.MinBound != null) {
                    queryURL = queryURL + string.Format("min={0}&", this.sortCriteria.MinBound);
                }

                if (this.sortCriteria.MaxBound != null) {
                    queryURL = queryURL + string.Format("max={0}&", this.sortCriteria.MaxBound);
                }
            }

            if (this.title != null) {
                queryURL = queryURL + string.Format("title={0}&", this.title);
            }

            if (this.tagNames != null && this.tagNames.Count > 0) {

                queryURL = queryURL + "tagged=";

                foreach (string tagName in this.tagNames) {
                    queryURL = queryURL + string.Format("{0};", tagName);
                }

                queryURL = queryURL + "&";
            }

            if (this.ignoredTagNames != null && this.ignoredTagNames.Count > 0) {

                queryURL = queryURL + "nottagged=";

                foreach (string ignoredTagName in this.ignoredTagNames) {
                    queryURL = queryURL + string.Format("{0};", ignoredTagName);
                }

                queryURL = queryURL + "&";
            }

            if (this.siteParameter != null) {
                queryURL = queryURL + string.Format("site={0}&", this.siteParameter);
            }

            if (this.filter != null) {
                queryURL = string.Concat(queryURL, this.GetFilterString());
            }

            return new StackExchangeAPIQuery<Question>(queryURL);
        }

        public override void Reset() {
            base.Reset();
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Ordering.DESCENDING;
        }

        public SimilarAPIQueryBuilder SetTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }

            this.tagNames = tagNames;
            return this;
        }

        public SimilarAPIQueryBuilder SetIgnoredTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }
            
            this.ignoredTagNames = tagNames;
            return this;
        }

        public SimilarAPIQueryBuilder SetTitle(string title) {
            this.title = title;
            return this;
        }

        public SimilarAPIQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }

        public SimilarAPIQueryBuilder SetCreationDateRange(SortState<Int64> dateRange) {
            this.creationDateRange = dateRange;
            return this;
        }

        public SimilarAPIQueryBuilder SetCreationDateOrdering(Ordering ordering) {
            this.creationDateOrdering = ordering;
            return this;
        }

        public SimilarAPIQueryBuilder SetSort(INamedSortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
