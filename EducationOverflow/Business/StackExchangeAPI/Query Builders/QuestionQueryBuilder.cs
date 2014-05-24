using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {
    
    /// <summary>
    /// A concrete builder for queries to the Stack Exchange API which return question objects.
    /// For more information on 'question objects', consider the Stack Exchange API documentation:
    /// http://api.stackexchange.com/docs/types/question
    /// </summary>
    public class QuestionQueryBuilder : StackExchangeSiteQueryBuilder<Question, QuestionQueryBuilder> {

        /// <summary>
        /// The tags applied to the question(s) retrieved by the query.
        /// </summary>
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

        /// <summary>
        /// Set the tags applied to the question(s) retrieved by the query.
        /// </summary>
        /// <param name="tagNames">The tags applied to the question.</param>
        /// <returns>The updated query builder.</returns>
        public QuestionQueryBuilder SetTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }

            this.tagNames = tagNames;
            return this;
        }
    }
}
