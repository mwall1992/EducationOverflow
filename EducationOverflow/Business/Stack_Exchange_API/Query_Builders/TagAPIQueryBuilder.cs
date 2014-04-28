using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class TagAPIQueryBuilder : StackExchangeAPIQueryBuilder {

        private static string API_METHOD_NAME = "tags";

        protected List<string> tagNames;

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public TagAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override StackExchangeAPIQuery GetQuery() {
            return new StackExchangeAPIQuery(null, typeof(Tag));
        }

        public override void Reset() {
            base.Reset();
            this.tagNames = null;
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Ordering.DESCENDING;
        }

        public TagAPIQueryBuilder SetTagNames(List<string> tagNames) {
            this.tagNames = tagNames;
            return this;
        }

        public TagAPIQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }

        public TagAPIQueryBuilder SetCreationDateRange(SortState<Int64> dateRange) {
            this.creationDateRange = dateRange;
            return this;
        }

        public TagAPIQueryBuilder SetCreationDateOrdering(Ordering ordering) {
            this.creationDateOrdering = ordering;
            return this;
        }

        public TagAPIQueryBuilder SetSort(ISortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
