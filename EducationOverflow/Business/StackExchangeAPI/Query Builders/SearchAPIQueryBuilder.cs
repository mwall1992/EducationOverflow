using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SearchAPIQueryBuilder : StackExchangeAPIQueryBuilder<Question, SearchAPIQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "search";

        protected List<string> tagNames;

        protected List<string> ignoredTagNames;

        protected string inTitle;

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public SearchAPIQueryBuilder() {
            this.apiMethod = DEFAULT_API_METHOD_NAME;
        }

        public override IQuery<Question> GetQuery() {
            return new StackExchangeAPIQuery<Question>(null);
        }

        public override void Reset() {
            base.Reset();
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Ordering.DESCENDING;
        }

        public SearchAPIQueryBuilder SetTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }

            this.tagNames = tagNames;
            return this;
        }

        public SearchAPIQueryBuilder SetIgnoredTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }

            this.ignoredTagNames = tagNames;
            return this;
        }

        public SearchAPIQueryBuilder SetSearchTitle(string title) {
            this.inTitle = title;
            return this;
        }

        public SearchAPIQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }

        public SearchAPIQueryBuilder SetCreationDateRange(SortState<Int64> dateRange) {
            this.creationDateRange = dateRange;
            return this;
        }

        public SearchAPIQueryBuilder SetCreationDateOrdering(Ordering ordering) {
            this.creationDateOrdering = ordering;
            return this;
        }

        public SearchAPIQueryBuilder SetSort(ISortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
