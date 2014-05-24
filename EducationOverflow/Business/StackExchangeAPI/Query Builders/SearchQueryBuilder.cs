using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace StackExchangeAPI {

    /// <summary>
    /// A concrete builder for queries to the Stack Exchange API which use the similar api method.
    /// For more information on the similar api method, consider the Stack Exchange API documentation:
    /// http://api.stackexchange.com/docs
    /// </summary>
    public class SearchQueryBuilder : StackExchangeSiteQueryBuilder<Question, SearchQueryBuilder> {
        
        /// <summary>
        /// An enumeration of the search methods supported by the Stack Exchange API.
        /// </summary>
        public enum SearchType {
            Similar = 0,
            Search
        };

        /// <summary>
        /// The tags applied to the question(s) retrieved by the query.
        /// </summary>
        protected List<string> tagNames;

        /// <summary>
        /// The tags not applied to the question(s) retrieved by the query.
        /// </summary>
        protected List<string> ignoredTagNames;

        /// <summary>
        /// The string segment included in question(s) retrieved by the query.
        /// </summary>
        protected string title;

        /// <summary>
        /// Construct a search query builder for a given search method type.
        /// </summary>
        /// <param name="searchType">The search method type.</param>
        public SearchQueryBuilder(SearchType searchType) {
            string apiMethodName = null;
            if (searchType == SearchType.Search) {
                apiMethodName = "search";
            } else if (searchType == SearchType.Similar) {
                apiMethodName = "similar";
            } else {
                throw new ArgumentException("Invalid search type specified.");
            }

            this.SetAPIMethod(apiMethodName);
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

        /// <summary>
        /// Set the tags applied to the question(s) retrieved by the query.
        /// </summary>
        /// <param name="tagNames">The tags names.</param>
        /// <returns>The updated query builder.</returns>
        public SearchQueryBuilder SetTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }

            this.tagNames = tagNames;
            return this;
        }

        /// <summary>
        /// Set the tags not applied to the question(s) retrieved by the query.
        /// </summary>
        /// <param name="tagNames">The tag names.</param>
        /// <returns>The updated query builder.</returns>
        public SearchQueryBuilder SetIgnoredTagNames(List<string> tagNames) {
            for (int i = 0; i < tagNames.Count; i++) {
                tagNames[i] = HttpUtility.UrlEncode(tagNames[i]);
            }
            
            this.ignoredTagNames = tagNames;
            return this;
        }

        /// <summary>
        /// Set the string segment included in all question(s) retrieved by the query.
        /// </summary>
        /// <param name="title">The string segment.</param>
        /// <returns>The updated query builder.</returns>
        public SearchQueryBuilder SetTitle(string title) {
            this.title = title;
            return this;
        }


        // helper method


        /// <summary>
        /// Generate the string representation of multi-valued parameters (for the query URL).
        /// </summary>
        /// <param name="values">The list of values for a parameter.</param>
        /// <returns>The string representation of the parameter values.</returns>
        private static string RetrieveMultiValueQueryParameter(List<string> values) {
            string queryParameter = "";

            foreach (string value in values) {
                queryParameter = string.Format("{0}{1};", queryParameter, value);
            }

            return queryParameter;
        }
    }
}
