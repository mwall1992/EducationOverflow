using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class TagAPIQueryBuilder : StackExchangeParameterisedAPIQueryBuilder<Tag> {

        private static string API_METHOD_NAME = "tags";

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public TagAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override IQuery<Tag> GetQuery() {
            return new StackExchangeAPIQuery<Tag>(null);
        }

        public override void Reset() {
            base.Reset();
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Ordering.DESCENDING;
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
