using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class AnswerAPIQueryBuilder : StackExchangeParameterisedAPIQueryBuilder<Answer> {

        private static string API_METHOD_NAME = "answers";

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public AnswerAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override IQuery<Answer> GetQuery() {
            return new StackExchangeAPIQuery<Answer>(null);
        }

        public override void Reset() {
            base.Reset();
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Ordering.DESCENDING;
        }

        public AnswerAPIQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }

        public AnswerAPIQueryBuilder SetCreationDateRange(SortState<Int64> dateRange) {
            this.creationDateRange = dateRange;
            return this;
        }

        public AnswerAPIQueryBuilder SetCreationDateOrdering(Ordering ordering) {
            this.creationDateOrdering = ordering;
            return this;
        }

        public AnswerAPIQueryBuilder SetSort(ISortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
