using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class QuestionAPIQueryBuilder : StackExchangeAPIQueryBuilder {

        public static int MAX_QUESTION_ID_COUNT = 100;

        private static string API_METHOD_NAME = "questions";

        protected List<Int32> questionIds;

        protected List<string> tagNames;

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

        protected ISortState sortCriteria;

        public QuestionAPIQueryBuilder() {
            this.apiMethod = API_METHOD_NAME;
        }

        public override StackExchangeAPIQuery GetQuery() {
            return new StackExchangeAPIQuery(null, typeof(Question));
        }

        public override void Reset() {
            base.Reset();
            this.questionIds = null;
            this.tagNames = null;
            this.page = null;
            this.creationDateRange = null;
            this.creationDateOrdering = Ordering.DESCENDING;
        }

        public QuestionAPIQueryBuilder SetQuestionIds(List<Int32> questionIds) {
            if (questionIds.Count > MAX_QUESTION_ID_COUNT) {
                throw new ArgumentException(
                    string.Format("The number of question ids specified is {0}. " 
                                    + "The maximum number of question ids allowed is {1}.",
                                    questionIds.Count, MAX_QUESTION_ID_COUNT)
                );
            }

            this.questionIds = questionIds;
            return this;
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
