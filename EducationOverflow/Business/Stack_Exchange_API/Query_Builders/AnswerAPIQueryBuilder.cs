using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class AnswerAPIQueryBuilder : StackExchangeAPIQueryBuilder {

        public static int MAX_ANSWER_ID_COUNT = 100;

        private static string API_METHOD_NAME = "answers";

        protected List<Int32> answerIds;

        protected Page page;

        protected Range<Date> creationDateRange;

        protected Date.Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public AnswerAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override StackExchangeAPIQuery GetQuery() {
            return new StackExchangeAPIQuery(null, typeof(Answer));
        }

        public override void Reset() {
            base.Reset();
            this.answerIds = null;
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Date.Ordering.DESCENDING;
        }

        public AnswerAPIQueryBuilder SetAnswerIds(List<Int32> answerIds) {
            if (answerIds.Count > MAX_ANSWER_ID_COUNT) {
                throw new ArgumentException(
                    string.Format("The number of answer ids specified is {0}. " 
                                    + "The maximum number of answer ids allowed is {1}.", 
                                    answerIds.Count, MAX_ANSWER_ID_COUNT)
                );
            }

            this.answerIds = answerIds;
            return this;
        }

        public AnswerAPIQueryBuilder SetPage(Page page) {
            this.page = page;
            return this;
        }

        public AnswerAPIQueryBuilder SetCreationDateRange(Range<Date> dateRange) {
            this.creationDateRange = dateRange;
            return this;
        }

        public AnswerAPIQueryBuilder SetCreationDateOrdering(Date.Ordering ordering) {
            this.creationDateOrdering = ordering;
            return this;
        }

        public AnswerAPIQueryBuilder SetSort(ISortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
