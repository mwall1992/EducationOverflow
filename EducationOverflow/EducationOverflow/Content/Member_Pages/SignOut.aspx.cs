using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;

namespace EducationOverflow {
    public partial class SignOut : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void SignOutButton_Click(object sender, EventArgs e) {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
        }
    }
}