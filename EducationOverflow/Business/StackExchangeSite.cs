using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using DataAccess.EducationOverflowTableAdapters;

namespace Business {

    [DataObject]
    public class StackExchangeSite {

        private static StackExchangeSiteTableAdapter siteTableAdapter = new StackExchangeSiteTableAdapter();

        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Data.EducationOverflow.StackExchangeSiteDataTable SelectStackExchangeSites() {
            return siteTableAdapter.GetData();
        }

        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void InsertStackExchangeSite(string apiSiteParameter, string name, int totalAcceptedAnswers) {
            siteTableAdapter.Insert(apiSiteParameter, name, totalAcceptedAnswers);
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateUser(string apiSiteParameter, string name, int totalAcceptedAnswers, 
                string originalAPISiteParameter) {
            siteTableAdapter.Update(apiSiteParameter, name, totalAcceptedAnswers, originalAPISiteParameter);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public static void DeleteUser(string originalAPISiteParameter) {
            siteTableAdapter.Delete(originalAPISiteParameter);
        }
    }
}
