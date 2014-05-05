using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class AnswerAPIQueryBuilder : StackExchangeParameterisedAPIQueryBuilder<Answer, AnswerAPIQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "answers";

        protected Page page;

        protected ISortState creationDateRange;

        protected Ordering creationDateOrdering;

        protected INamedSortState sortCriteria;

        public AnswerAPIQueryBuilder() {
            this.apiMethod = DEFAULT_API_METHOD_NAME;
        }

        public override IQuery<Answer> GetQuery() {
            string queryURL = string.Format("{0}{1}?", this.GetBaseQueryURL(), this.GetParameterisedAPIMethod());

            if (this.page != null) {
                queryURL = string.Format("{0}{1}&", queryURL, this.page.ToString());
            }

            if (this.creationDateRange != null) {
                if (this.creationDateRange.MinBound != null) {
                    queryURL = queryURL + string.Format("fromdate={0}&", this.creationDateRange.MinBound);
                }

                if (this.creationDateRange.MaxBound != null) {
                    queryURL = queryURL + string.Format("todate={0}&", this.creationDateRange.MaxBound);
                }
            }

            if (this.creationDateOrdering == Ordering.DESCENDING) {
                queryURL = queryURL + "order=desc&";
            } else if (this.creationDateOrdering == Ordering.ASCENDING) {
                queryURL = queryURL + "order=asc&";
            }

            if (this.sortCriteria != null) {
                queryURL = queryURL + string.Format("sort={0}&", this.sortCriteria.Name);

                if (this.sortCriteria.MinBound != null) {
                    queryURL = queryURL + string.Format("min={0}&", this.sortCriteria.MinBound);
                }

                if (this.sortCriteria.MaxBound != null) {
                    queryURL = queryURL + string.Format("max={0}&", this.sortCriteria.MaxBound);
                }
            }

            if (this.siteParameter != null) {
                queryURL = queryURL + string.Format("site={0}&", this.siteParameter);
            }

            if (this.filter != null) {
                queryURL = string.Concat(queryURL, this.GetFilterString());
            }

            return new StackExchangeAPIQuery<Answer>(queryURL);
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

        public AnswerAPIQueryBuilder SetSort(INamedSortState sortCriteria) {
            this.sortCriteria = sortCriteria;
            return this;
        }
    }
}
