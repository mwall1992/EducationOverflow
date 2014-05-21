using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EducationOverflow {
    public partial class Register : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void CreateUserWizard_CreatedUser(object sender, EventArgs e) {
            const string USER_ROLE = "user";
            const bool USER_IS_ONLINE = true;
            System.Web.Security.MembershipUser newUser = 
                (new Business.CustomMembershipProvider()).GetUser(CreateUserWizard.UserName, USER_IS_ONLINE);
            Business.UserRoles.InsertUserRole(USER_ROLE, (long)newUser.ProviderUserKey);
        }
    }
}