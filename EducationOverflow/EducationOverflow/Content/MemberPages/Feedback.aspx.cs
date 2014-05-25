using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EducationOverflow.Content.MemberPages {
    public partial class Feedback : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {

                // retrieve user information
                System.Web.Security.MembershipUser user = System.Web.Security.Membership.GetUser();
                long userId = Convert.ToInt64(user.ProviderUserKey);

                // construct parameters for data source
                System.Web.UI.WebControls.Parameter userIdParameter =
                    new System.Web.UI.WebControls.Parameter("userId", System.Data.DbType.Int64, userId.ToString());

                // set data source parameter(s)
                UserQuestionFeedbackDataSource.SelectParameters["userId"] = userIdParameter;
                //ReportedQuestionsDataSource.DeleteParameters["userId"] = userIdParameter;
            }
        }
    }
}