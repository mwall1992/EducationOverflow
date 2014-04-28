using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SimilarAPIQueryBuilder : StackExchangeAPIQueryBuilder<Question> {

        private static string API_METHOD_NAME = "similar";

        protected List<string> tagNames;

        protected List<string> ignoredTagNames;

        protected string title;

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public SimilarAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
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

        public SimilarAPIQueryBuilder SetTagNames(List<string> tagNames) {
            this.tagNames = tagNames;
            return this;
        }

        public SimilarAPIQueryBuilder SetIgnoredTagNames(List<string> tagNames) {
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

        public SimilarAPIQueryBuilder SetSort(ISortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
