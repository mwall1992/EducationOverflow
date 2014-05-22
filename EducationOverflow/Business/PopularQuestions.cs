using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class PopularQuestions {
        
        private static PopularQuestionsUserViewTableAdapter popularQuestionsTableAdapter = 
            new PopularQuestionsUserViewTableAdapter();

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
