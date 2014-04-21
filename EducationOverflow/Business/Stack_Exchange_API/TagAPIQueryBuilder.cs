using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class TagAPIQueryBuilder : StackExchangeSiteAPIQueryBuilder<Tag> {

        private static string API_METHOD_NAME = "tags";

        protected List<string> tagNames;

        protected Page page;

        protected Range<Date> creationDateRange;

        protected Date.Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public TagAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override List<Tag> GetResponse() {
            return null;
        }

        public override void Reset() {
            base.Reset();
            this.tagNames = null;
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Date.Ordering.DESCENDING;
        }

        public TagAPIQueryBuilder SetTagNames(List<string> tagNames) {
            this.tagNames = tagNames;
            return this;
        }

        public TagAPIQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }

        public TagAPIQueryBuilder SetCreationDateRange(Range<Date> dateRange) {
            this.creationDateRange = dateRange;
            return this;
        }

        public TagAPIQueryBuilder SetCreationDateOrdering(Date.Ordering ordering) {
            this.creationDateOrdering = ordering;
            return this;
        }

        public TagAPIQueryBuilder SetSort(ISortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
