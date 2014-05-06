using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class SimilarQueryBuilder : StackExchangeSiteQueryBuilder<Question, SimilarQueryBuilder> {

        private static string DEFAULT_API_METHOD_NAME = "similar";

        protected List<string> tagNames;

        protected List<string> ignoredTagNames;

        protected string title;

        public SimilarQueryBuilder() {
            this.SetAPIMethod(DEFAULT_API_METHOD_NAME);
        }

        public override IQuery<Question> GetQuery() {
            string queryURL = this.GetBaseQueryUrl();

            if (this.title != null) {
                queryURL = queryURL + string.Format("title={0}&", this.title);
            }

            if (this.tagNames != null && this.tagNames.Count > 0) {
                queryURL = string.Format("{0}tagged={1}&", queryURL,
                    RetrieveMultiValueQueryParameter(this.tagNames));
            }

            if (this.ignoredTagNames != null && this.ignoredTagNames.Count > 0) {
                queryURL = string.Format("{0}nottagged={1}&", queryURL,
                    RetrieveMultiValueQueryParameter(this.ignoredTagNames));
            }

            return new StackExchangeAPIQuery<Question>(queryURL);
        }

        public override void Reset() {
            base.Reset();
            this.tagNames = null;
            this.ignoredTagNames = null;
        }

        public SimilarQueryBuilder SetTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }

            this.tagNames = tagNames;
            return this;
        }

        public SimilarQueryBuilder SetIgnoredTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }
            
            this.ignoredTagNames = tagNames;
            return this;
        }

        public SimilarQueryBuilder SetTitle(string title) {
            this.title = title;
            return this;
        }

        // helper method

        private static string RetrieveMultiValueQueryParameter(List<string> values) {
            string queryParameter = "";

            foreach (string value in values) {
                queryParameter = string.Format("{0}{1};", queryParameter, value);
            }

            return queryParameter;
        }
    }
}
