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
            const bool USER_IS_ONLINE = true;
            System.Web.Security.MembershipUser newUser = 
                (new Business.CustomMembershipProvider()).GetUser(CreateUserWizard.UserName, USER_IS_ONLINE);

            string firstName =
                ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("FirstNameTextBox")).Text;
            string lastName =
                ((TextBox)CreateUserWizard.CreateUserStep.ContentTemplateContainer.FindControl("LastNameTextBox")).Text;

            Business.Queries.InsertUserForId((long)newUser.ProviderUserKey, firstName, lastName, DateTime.Now);
        }
    }
}