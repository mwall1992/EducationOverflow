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

            //List<DataObjects.StackExchangeSite> sites = new List<DataObjects.StackExchangeSite>();
            //DataAccess.EducationOverflow.StackExchangeSiteDataTable siteDataTable = siteTableAdapter.GetData();

            //foreach (DataAccess.EducationOverflow.StackExchangeSiteRow row in siteDataTable.Rows) {
            //    sites.Add(new DataObjects.StackExchangeSite() { 
            //        APISiteParameter = row.APISiteParameter, 
            //        Name = row.Name, TotalAcceptedAnswers = row.TotalAcceptedAnswers 
            //    }); 
            //}

            //return sites;
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
