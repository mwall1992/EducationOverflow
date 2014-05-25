using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {
    
    [DataObject]
    public class OrderedHints {
    
        private static OrderedHintsTableAdapter hintsTableAdapter = 
            new OrderedHintsTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.OrderedHintsDataTable SelectOrderedHints(long questionId) {
            return hintsTableAdapter.GetData(questionId);
        }
    }
}
