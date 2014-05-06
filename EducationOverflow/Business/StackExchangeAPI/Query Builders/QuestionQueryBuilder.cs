using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {

    // Builder design pattern (fluent interface) - Concrete Builder

    public class QuestionQueryBuilder : StackExchangeSiteQueryBuilder<Question, QuestionQueryBuilder> {

        protected List<string> tagNames;

        public override IQuery<Question> GetQuery() {
            string queryURL = this.GetBaseQueryUrl();

            if (this.tagNames != null && this.tagNames.Count > 0) {
                
                queryURL = queryURL + "tagged=";

                foreach (string tagName in this.tagNames) {
                    queryURL = queryURL + string.Format("{0};", tagName);
                }

                queryURL = queryURL + "&";
            }

            return new StackExchangeAPIQuery<Question>(queryURL);
        }

        public override void Reset() {
            base.Reset();
            this.tagNames = null;
        }

        public QuestionQueryBuilder SetTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }

            this.tagNames = tagNames;
            return this;
        }
    }
}
