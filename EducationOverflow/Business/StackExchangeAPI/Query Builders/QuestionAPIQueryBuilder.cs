using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class QuestionAPIQueryBuilder : StackExchangeParameterisedAPIQueryBuilder<Question> {

        public static int MAX_QUESTION_ID_COUNT = 100;

        private static string API_METHOD_NAME = "questions";

        protected List<string> tagNames;

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public QuestionAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override IQuery<Question> GetQuery() {
            return new StackExchangeAPIQuery<Question>(null);
        }

        public override void Reset() {
            base.Reset();
            this.tagNames = null;
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Ordering.DESCENDING;
        }

        public QuestionAPIQueryBuilder SetTagNames(List<string> tagNames) {
            this.tagNames = tagNames;
            return this;
        }

        public QuestionAPIQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }

        public QuestionAPIQueryBuilder SetCreationDateRange(SortState<Int64> dateRange) {
            this.creationDateRange = dateRange;
            return this;
        }

        public QuestionAPIQueryBuilder SetCreationDateOrdering(Ordering ordering) {
            this.creationDateOrdering = ordering;
            return this;
        }

        public QuestionAPIQueryBuilder SetSort(ISortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
