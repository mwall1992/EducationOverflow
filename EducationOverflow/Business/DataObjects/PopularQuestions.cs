using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    /// <summary>
    /// The DataObject class for performing read operations for popular questions.
    /// </summary>
    [DataObject]
    public class PopularQuestions {

        /// <summary>
        /// The table adapter used for popular questions.
        /// </summary>
        private static PopularQuestionsUserViewTableAdapter popularQuestionsTableAdapter =
            new PopularQuestionsUserViewTableAdapter();

        /// <summary>
        /// Retrieve popular questions.
        /// </summary>
        /// <param name="maxResultCount">The maximum number of questions to retrieve.</param>
        /// <returns>A table containing information on the most popular questions.</returns>
        /// <remarks>Retrieved questions are order from most popular to least popular.</remarks>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.PopularQuestionsUserViewDataTable SelectPopularQuestions(int maxResultCount) {
            Data.EducationOverflow.PopularQuestionsUserViewDataTable allResults = popularQuestionsTableAdapter.GetData();

            // extract necessary information
            Data.EducationOverflow.PopularQuestionsUserViewDataTable results =
                (Data.EducationOverflow.PopularQuestionsUserViewDataTable)allResults.Clone();
            for (int i = 0; i < maxResultCount && i < allResults.Count; i++) {
                results.ImportRow(allResults.Rows[i]);
            }

            return results;
        }
    }
}
