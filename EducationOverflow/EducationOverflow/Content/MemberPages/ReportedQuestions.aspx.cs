﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EducationOverflow.Content.Member_Pages {
    public partial class ReportQuestion : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            // retrieve user information
            System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();
            long userId = Convert.ToInt64(user.ProviderUserKey);

            // set data source parameter(s)
            ReportedQuestionsDataSource.SelectParameters["userId"].DefaultValue = userId.ToString();
            ReportedQuestionsDataSource.DeleteParameters["userId"].DefaultValue = userId.ToString();
        }

        protected void Page_Load(object sender, EventArgs e) {
            
        }
    }
}