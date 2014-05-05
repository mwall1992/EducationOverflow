using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using StackExchangeAPI;

namespace EducationOverflow {
    
    public partial class Default : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

            /* Test Code */

            //List<string> tags = new List<string>() { "C#" };

            //var testQueryBuilder = new QuestionAPIQueryBuilder()
            //.SetSite("stackoverflow")
            //.SetPage(new StackExchangeAPI.Page(1, 100))
            //.SetTagNames(tags)
            //.SetAPIVersion("2.2")
            //.SetAPIMethod("testMethod")
            //.SetApiMethodExtension("testExtension");

            //IQuery<Question> siteQuery = testQueryBuilder.GetQuery();
        }
    }
}