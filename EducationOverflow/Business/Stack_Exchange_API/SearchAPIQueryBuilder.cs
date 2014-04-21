using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SearchAPIQueryBuilder : StackExchangeSiteAPIQueryBuilder<Question> {

        private static string API_METHOD_NAME = "search";

        protected List<string> tagNames;

        protected List<string> ignoredTagNames;

        protected string inTitle;

        protected Page page;

        protected Range<Date> creationDateRange;

        protected Date.Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public SearchAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override List<Question> GetResponse() {
            return null;
        }

        public override void Reset() {
            base.Reset();
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Date.Ordering.DESCENDING;
        }

        public SearchAPIQueryBuilder SetTagNames(List<string> tagNames) {
            this.tagNames = tagNames;
            return this;
        }

        public SearchAPIQueryBuilder SetIgnoredTagNames(List<string> tagNames) {
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

        public SearchAPIQueryBuilder SetCreationDateRange(Range<Date> dateRange) {
            this.creationDateRange = dateRange;
            return this;
        }

        public SearchAPIQueryBuilder SetCreationDateOrdering(Date.Ordering ordering) {
            this.creationDateOrdering = ordering;
            return this;
        }

        public SearchAPIQueryBuilder SetSort(ISortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
